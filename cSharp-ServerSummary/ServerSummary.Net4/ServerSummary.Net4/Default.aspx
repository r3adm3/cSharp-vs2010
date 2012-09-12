<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ServerSummary.Net4._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 481px;
            height: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        System Summary PAge for
        <asp:Label ID="lblServerName2" runat="server"></asp:Label>
    </h2>
    <br />
Host Name:&nbsp;
<asp:Label ID="lblHostName" runat="server"></asp:Label>
<br />
OS Name:
<asp:Label ID="lblOS" runat="server"></asp:Label>
<br />
OS Version:
<asp:Label ID="lblOSVer" runat="server"></asp:Label>
<br />
Original Install Date:&nbsp;
<asp:Label ID="lblInstallDate" runat="server"></asp:Label>
<br />
<br />
System Boot Time:
<asp:Label ID="lblSystemBootTime" runat="server"></asp:Label>
<br />
System Manufacturer:
<asp:Label ID="lblSystemManuFacturer" runat="server"></asp:Label>
    <br />
    System Model:
    <asp:Label ID="lblSystemModel" runat="server"></asp:Label>
<br />
<br />
Processor(s):
<asp:Label ID="lblProcessors" runat="server"></asp:Label>
<br />
BIOS Version:
<asp:Label ID="lblBios" runat="server"></asp:Label>
<br />
<br />
Total Physical Memory:
<asp:Label ID="lblPhysicalMemory" runat="server"></asp:Label>
<br />
Available Physical Memory:
<asp:Label ID="lblAvailableMemory" runat="server"></asp:Label>
<br />
    <br />
    <img alt="%CPU Time" class="style1" src="stats/Proc.png" />
    <img alt="Network Use" class="style1" src="stats/Network.png" /><br />
</asp:Content>
