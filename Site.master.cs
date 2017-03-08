using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    DBCenter _DBCenter = new DBCenter();

    protected void Page_Init(object sender, EventArgs e)
    {
        // 下面的程式碼有助於防禦 XSRF 攻擊
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // 使用 Cookie 中的 Anti-XSRF 權杖
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // 產生新的防 XSRF 權杖並儲存到 cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 設定 Anti-XSRF 權杖
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // 驗證 Anti-XSRF 權杖
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Anti-XSRF 權杖驗證失敗。");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        /*
         * MultiView1
         * 0:SuperAdmin
         * 1:GroupAdmin
         * 2:校內User
         * 3:校外User
         * 
         */

        #region 選單判斷

        String sSQL = "SELECT * FROM MEMBER WHERE ACCOUNT = '" + Context.User.Identity.Name + "' ";
        int rowCount = _DBCenter.GetDataTable(sSQL).Rows.Count;
        String sSQLGroup = "SELECT * FROM GROUP_DATA WHERE GROUPNO = '" + Context.User.Identity.Name + "' ";
        int rowCountGroup = _DBCenter.GetDataTable(sSQLGroup).Rows.Count;

        var MultiView1 = (MultiView)LoginView1.FindControl("MultiView1");//ID of control to load
   
        if (rowCount > 0)
        {
            MultiView1.ActiveViewIndex = 2; 
        }

        if (rowCountGroup > 0)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        if (Context.User.Identity.Name == "SuperAdmin")
            MultiView1.ActiveViewIndex = 0; 
        #endregion


    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}