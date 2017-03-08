<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div  style="text-align:left; width:800px">
            <table style="width:100%">
                <tr><td> <asp:Label runat="server">社團分類</asp:Label></td></tr>
                <tr><td> <asp:DropDownList runat="server" ID="ddlGroupClass" CssClass="form-control" OnSelectedIndexChanged="ddlGroupClass_SelectedIndexChanged" AutoPostBack="true"/> </td></tr>
                <tr><td> <asp:Label runat="server">社團名稱</asp:Label></td></tr>
                <tr><td> <asp:DropDownList runat="server" ID="ddlGroupName" CssClass="form-control" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged" AutoPostBack="true"/> </td></tr>
                <tr>
              <td>
                   <asp:Label ID="Label1" runat="server" Text='社團簡介'></asp:Label>
              </td>
          </tr>
          <tr>
              <td style="height:100px; width:100%">
                  <asp:TextBox ID="ttbGroupDesc" runat="server" Height="100%" Rows="5" TextMode="MultiLine" Width="100%" Enabled="false"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label2" runat="server" Text='社團內容說明'></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:TextBox ID="ttbDetail" runat="server" Height="100%" Rows="5" TextMode="MultiLine" Width="100%" Enabled="false"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label5" runat="server" Text='Email'></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:TextBox ID="ttbEmail" runat="server" Height="100%" Rows="1" TextMode="MultiLine" Width="100%" Enabled="false"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label3" runat="server" Text='社團提供服務'></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
               <asp:Panel ID="panelZone" runat="server">

                </asp:Panel>
  
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label4" runat="server" Text='詳細需求說明'></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:TextBox ID="ttbMessage" runat="server" Height="100%" Rows="5" TextMode="MultiLine" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Button runat="server" id="btnSave" Text="送出" OnClick="btnSave_Click"  />
              </td>
          </tr>
            </table>


        </div> 





  <%--  <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>--%>
</asp:Content>
