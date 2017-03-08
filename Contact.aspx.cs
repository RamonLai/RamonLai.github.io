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



public partial class Contact : Page
{

    protected DataTable dtGroupData
    {
        get
        {
            if (Session["Contact_dtGroupData"] == null)
            {
                Session["Contact_dtGroupData"] = new DataTable();
            }
            return ((DataTable)Session["Contact_dtGroupData"]);
        }
        set { Session["Contact_dtGroupData"] = value; }
    }

    DBCenter _DBCenter = new DBCenter();
    CommonClass _CommonClass = new CommonClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtGroupData = _DBCenter.GetDataTable("SELECT * FROM GROUP_DATA WHERE 1=1  ");
            if (dtGroupData.Rows.Count == 0)
                return;
          
            ddlGroupName.DataTextField = "CNAME";
            ddlGroupName.DataValueField = "GROUPNO";
            ddlGroupName.DataSource = dtGroupData;
            ddlGroupName.DataBind();
            ddlGroupName.Items.Insert(0, "");
            ddlGroupName.SelectedIndex = -1;
            //_CommonClass.SendMail2();
            //_CommonClass.SendEmail("lairamon@gmail.com","ASTITLE", "This is Test Mail");
           
        }
        var _GroupNo = ddlGroupName.SelectedValue.ToString();
        AddControls(_GroupNo);
        if (User.Identity.Name == null || User.Identity.Name == string.Empty)
            btnSave.Enabled = false;


    }
    protected void ddlGroupClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAll();
        var _GroupNo = ddlGroupName.SelectedValue.ToString();
        var dr = dtGroupData.Select("GROUPNO='" + _GroupNo + "'");
        if (dr.Length == 0)
            return;
        ttbGroupDesc.Text = dr[0]["DESCRIPTION"].ToString();
        ttbDetail.Text = dr[0]["DETAIL"].ToString();
        ttbEmail.Text = dr[0]["EMAIL"].ToString();

        //AddControls(_GroupNo);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        var lstService = GetControls();
        if (lstService.Count == 0)
            Response.Write("<script>alert('請至少選取一個服務')</script>");

        var GroupNo = ddlGroupName.SelectedValue.ToString();
        var Desc = ttbMessage.Text.Trim();
        var Email = _CommonClass.GetUserByAccount(User.Identity.Name)["EMAIL"].ToString();
        var TEL = _CommonClass.GetUserByAccount(User.Identity.Name)["TEL1"].ToString();

        foreach (var service in lstService)
        {
            String sSQL = "INSERT INTO MATCHMAKING (GROUPNO,SERVICE,DESCRIPTION,EMAIL,TEL,CREATEUSER,CREATETIME,UPDATEUSER,UPDATETIME) values ";
            sSQL += " ('" + GroupNo + "','" + service + "','" + Desc + "','" + Email + "','" + TEL + "','" + User.Identity.Name + "','" + System.DateTime.Now.ToString() + "','" + User.Identity.Name + "','" + System.DateTime.Now.ToString() + "')";
            _DBCenter.ExecuteSQL(sSQL);
        }
        Response.Write("<script>alert('媒合需求已送出')</script>");
    }

    protected void ClearAll()
    {
        ttbGroupDesc.Text = string.Empty;
        ttbDetail.Text = string.Empty;
        ttbEmail.Text = string.Empty;
    }
    private void AddControls(string _GroupNo)
    {
        DataTable dtEditItem = _DBCenter.GetDataTable("SELECT * FROM MENU_ITEM WHERE 1=1 AND CLASSNO = 'ServiceName' ");
        DataTable dtItem = _DBCenter.GetDataTable("SELECT * FROM GROUP_SERVICE WHERE 1=1 AND GROUPNO='" + _GroupNo + "' ");
        for (int i = 0; i < dtItem.Rows.Count; i++)
        {
            int index = (i + 1);

            CheckBox Ckb = new CheckBox();
            string ckbid = "ckb" + dtItem.Rows[i]["SERVICE"].ToString(); 
            Ckb.ID = ckbid;

            var dr = dtEditItem.Select("CLASSVALUE='" + dtItem.Rows[i]["SERVICE"].ToString() + "'");

            Label lbl = new Label();
            string id = "txt" + index;
            lbl.ID = id;
            lbl.Text = dr[0]["CLASSITEM"].ToString();

            panelZone.Controls.Add(Ckb);
            panelZone.Controls.Add(lbl);
            panelZone.Controls.Add(new LiteralControl("</br>"));

        }

    }

    private List<string> GetControls()
    {
        List<string> lstReturn = new List<string>();

        DataTable dtItem = _DBCenter.GetDataTable("SELECT * FROM MENU_ITEM WHERE 1=1 AND CLASSNO='ServiceName' ");
        for (int i = 0; i < dtItem.Rows.Count; i++)
        {
            var checkBox = panelZone.FindControl("ckb" + dtItem.Rows[i]["CLASSVALUE"].ToString()) as CheckBox;
            if (checkBox!=null&&checkBox.Checked == true)
                lstReturn.Add(dtItem.Rows[i]["CLASSVALUE"].ToString());
        }

        return lstReturn;

    }
}