<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventsActivity.aspx.cs" Inherits="Evential.EventsActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Current Activity</h2>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataSourceID="EventDemoDB" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="LogTime" HeaderText="LogTime" 
                SortExpression="LogTime" />
            <asp:BoundField DataField="LogEvent" HeaderText="LogEvent" 
                SortExpression="LogEvent" />
            <asp:BoundField DataField="eventID" HeaderText="eventID" 
                SortExpression="eventID" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

<asp:SqlDataSource ID="EventDemoDB" runat="server" 
    ConnectionString="<%$ ConnectionStrings:EventsDemoConnectionString %>" 
    SelectCommand="SELECT top 50 * FROM [tblLogs] order by LogTime DESC"></asp:SqlDataSource>

</asp:Content>
