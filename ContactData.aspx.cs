using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using WebSite;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic;



public partial class ContactData : Page
{
    protected DataTable dtServiceData
    {
        get
        {
            if (Session["dtServiceData"] == null)
            {
                Session["dtServiceData"] = new DataTable();
            }
            return ((DataTable)Session["dtServiceData"]);
        }
        set { Session["dtServiceData"] = value; }
    }

    DBCenter _DBCenter = new DBCenter();
    CommonClass _CommonClass = new CommonClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.Name == "SuperAdmin")
            dtServiceData = _DBCenter.GetDataTable("SELECT * FROM MATCHMAKING WHERE 1=1 ");
        else
            dtServiceData = _DBCenter.GetDataTable("SELECT * FROM MATCHMAKING WHERE 1=1 AND GROUPNO='" + User.Identity.Name + "' OR CREATEUSER = '" + User.Identity.Name + "' ");

        foreach (DataRow dr in dtServiceData.Rows)
        {
           var Group = _CommonClass.GetUserByAccount(dr["GROUPNO"].ToString());
           var Menu = _CommonClass.GetMenuItem("ServiceName", dr["SERVICE"].ToString());

           if (Group != null)
               dr["GROUPNO"] = Group["CNAME"].ToString();
           if (Menu != null)
               dr["SERVICE"] = Menu["CLASSITEM"].ToString();
        }
        
        gvMain.DataSource = dtServiceData;
        gvMain.DataBind();
    }
}