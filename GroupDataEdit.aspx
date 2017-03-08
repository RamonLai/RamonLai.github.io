<%@ Page Title="GroupDataEdit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="~/GroupDataEdit.aspx.cs" Inherits="GroupDataEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="overflow: auto; width: 100%; height: 400px;">
      <table style="width:100%">
          <tr>
              <td>
                    <h3> <asp:Label ID="lblGroupName" runat="server" Text='社團名稱'></asp:Label></h3>
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label1" runat="server" Text='社團簡介'></asp:Label>
              </td>
          </tr>
          <tr>
              <td style="height:100px; width:100%">
                  <asp:TextBox ID="ttbGroupDesc" runat="server" Height="100%" Rows="5" TextMode="MultiLine" Width="100%"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                   <asp:Label ID="Label2" runat="server" Text='社團內容說明'></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:TextBox ID="ttbDetail" runat="server" Height="100%" Rows="5" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                  <asp:Button runat="server" id="btnSave" Text="儲存" OnClick="btnSave_Click" />
              </td>
          </tr>


      </table>
    </div>
</asp:Content>
