<%@ Page Title="GroupData" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="GroupData.aspx.cs" Inherits="GroupData" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <div style="overflow: auto; width: 100%; height: 400px;">
        <asp:GridView ID="gvMain" runat="server" Width="99.9%" AutoGenerateColumns="False" AllowPaging="False" >
            <Columns>
                <asp:TemplateField HeaderText="社團名稱" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("CNAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="社團簡介" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("DESCRIPTION") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="社團內容說明" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblLot" runat="server" Text='<%# Bind("DETAIL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
