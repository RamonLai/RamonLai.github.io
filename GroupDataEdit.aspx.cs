using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class GroupDataEdit : Page
{
    protected DataTable dtGroupData
    {
        get
        {
            if (Session["dtGroupData"] == null)
            {
                Session["dtGroupData"] = new DataTable();
            }
            return ((DataTable)Session["dtGroupData"]);
        }
        set { Session["dtGroupData"] = value; }
    }

    DBCenter _DBCenter = new DBCenter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_DATA WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");
            if (dtGroupData.Rows.Count == 0)
                return;
            ttbGroupDesc.Text = dtGroupData.Rows[0]["DESCRIPTION"].ToString();
            ttbDetail.Text = dtGroupData.Rows[0]["DETAIL"].ToString();
        }
        AddControls();
        BindService();

    }

    private void AddControls()
    {
        DataTable dtItem = _DBCenter.GetDataTable("SELECT * FROM MENU_ITEM WHERE 1=1 AND CLASSNO='ServiceName' ");
        for (int i = 0; i < dtItem.Rows.Count; i++)
        {
            int index = (i + 1);

            CheckBox Ckb = new CheckBox();
            string ckbid = "ckb"  +dtItem.Rows[i]["CLASSVALUE"].ToString();
            Ckb.ID = ckbid;


            Label lbl = new Label();
            string id = "txt" + index;
            lbl.ID = id;
            lbl.Text = dtItem.Rows[i]["CLASSITEM"].ToString();

            panelZone.Controls.Add(Ckb);
            panelZone.Controls.Add(lbl);
            panelZone.Controls.Add(new LiteralControl("</br>"));
        
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_DATA WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");
        if (dtGroupData.Rows.Count == 0)
            return;

        int iReturn = _DBCenter.ExecuteSQL("Update GROUP_DATA SET DESCRIPTION='" + ttbGroupDesc.Text + "', DETAIL = '" + ttbDetail.Text + "' WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");
        if (iReturn > 0)
            Response.Write("<script>alert('儲存成功')</script>");

        dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_SERVICE WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");
        if (dtGroupData.Rows.Count > 0)
            _DBCenter.ExecuteSQL("DELETE FROM GROUP_SERVICE WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");

        List<string> lstCheck = GetControls();
        foreach (var service in lstCheck)
        {
            String sSQL = "INSERT INTO GROUP_SERVICE (GROUPNO,SERVICE,UPDATEUSER,UPDATETIME) values ";
            sSQL += " ('" + User.Identity.Name + "','" + service + "','" + User.Identity.Name + "','" + System.DateTime.Now.ToString() + "')";
            _DBCenter.ExecuteSQL(sSQL);
        }
    }


    private List<string> GetControls()
    {
        List<string> lstReturn = new List<string>();

        DataTable dtItem = _DBCenter.GetDataTable("SELECT * FROM MENU_ITEM WHERE 1=1 AND CLASSNO='ServiceName' ");
        for (int i = 0; i < dtItem.Rows.Count; i++)
        {
            var checkBox = panelZone.FindControl("ckb" + dtItem.Rows[i]["CLASSVALUE"].ToString()) as CheckBox;
            if (checkBox.Checked == true)
                lstReturn.Add(dtItem.Rows[i]["CLASSVALUE"].ToString());
        }

        return lstReturn;

    }


    private void BindService() 
    {
        dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_SERVICE WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' ");
        for (int i = 0; i < dtGroupData.Rows.Count; i++)
        {
            string _CLASSVALUE = dtGroupData.Rows[i]["SERVICE"].ToString();
           var checkBox = panelZone.FindControl("ckb" + _CLASSVALUE) as CheckBox;
           checkBox.Checked = true;
        }
    
    }
}