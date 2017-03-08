<%@ Page Title="ContactData" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ContactData.aspx.cs" Inherits="ContactData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <div style="overflow: auto; width: 100%; height: 400px;">
        <asp:GridView ID="gvMain" runat="server" Width="99.9%" AutoGenerateColumns="False" AllowPaging="False" >
            <Columns>
                <asp:TemplateField HeaderText="社團名稱" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("GROUPNO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="服務項目" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("SERVICE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="詳細說明" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("DESCRIPTION") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("EMAIL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="電話" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("TEL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請人" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("CREATEUSER") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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
