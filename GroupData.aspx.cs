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

public partial class GroupData : Page
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
        dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_DATA WHERE 1=1 AND AUDIT='Y' ");
        gvMain.DataSource = dtGroupData;
        gvMain.DataBind();
    }
}