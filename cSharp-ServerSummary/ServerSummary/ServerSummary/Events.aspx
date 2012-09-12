<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="ServerSummary._Default" MasterPageFile="" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" /><title>
	Home Page
</title><link href="/styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #form1
        {
            text-align: left;
        }
    </style>
    </head>

<body>


    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                    <asp:Label ID="lblServerName" runat="server"></asp:Label>
&nbsp;</h1>
            </div>
            <div class="loginDisplay">
            </div>
            <div class="clear hideSkiplink">
                <div style="float: left;" class="menu" id="NavigationMenu">
	<ul role="menubar" style="position: relative; width: auto; float: left;" tabindex="0" class="level1 static">
		<li style="position: relative; float: left;" class="static" role="menuitem">
        <a tabindex="-1" class="level1 static" href="http://localhost/Default.aspx">SystemSummary</a></li><li style="position: relative; float: left;" class="static" role="menuitem">
        <a tabindex="-1" class="level1 static" href="http://localhost/DriveSpace.aspx">DriveSpace</a></li><li style="position: relative; float: left;" class="static" role="menuitem">
        <a tabindex="-1" class="level1 static" href="http://localhost/net2/Events.aspx">Events</a></li><li style="position: relative; float: left;" class="static" role="menuitem">
        <a tabindex="-1" class="level1 static" href="http://localhost/net2/IISLogs.aspx">IIS Logs</a></li><li style="position: relative; float: left;" class="static" role="menuitem">
        <a tabindex="-1" class="level1 static" href="http://localhost/Certs.aspx">Certs</a></li>

    </ul>
</div><div style="clear: left;"></div><a id="NavigationMenu_SkipLink"></a>
            </div>
        </div>
        <div class="main">
            
            <form id="form1" runat="server">
    
        <h2>
            Eventlogs for
            <asp:Label ID="lblServerName2" runat="server"></asp:Label>
        </h2>
 
        <asp:DropDownList ID="ddlEventLog" runat="server" AutoPostBack="True">
            <asp:ListItem>System</asp:ListItem>
            <asp:ListItem>Application</asp:ListItem>
            
        </asp:DropDownList>
&nbsp;
        <asp:DropDownList ID="ddlNumberOfEvents" runat="server" AutoPostBack="True">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            EnableModelValidation="True" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    
   
    &nbsp;<br />
            Top 10 Application Events
            <asp:Label ID="lblAppEvtError" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
            <br />
            Top 10 System Events 
            <br />
            <asp:GridView ID="GridView3" runat="server" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
            <br />
    
   
    </form>


        
        </div>

        <div class="clear">
        </div>
    
    <div class="footer">
        
    </div>
    
    <script type="text/javascript">    new Sys.WebForms.Menu({ element: 'NavigationMenu', disappearAfter: 500, orientation: 'horizontal', tabIndex: 0, disabled: false });</script></form>

    </div>
</body>
</html>
