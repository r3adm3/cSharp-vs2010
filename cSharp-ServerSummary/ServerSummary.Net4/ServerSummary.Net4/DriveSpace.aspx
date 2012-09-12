<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="DriveSpace.aspx.cs" Inherits="ServerSummary.Net4.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        DriveSpace</h2>
    <p>
         <asp:Chart ID="DriveChartsC" runat="server">
            <titles>
                <asp:Title ShadowOffset="3" Name="Drive Space" />
            </titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom"
                            IsTextAutofit="False" Name="Drive Space"
                            LegendStyle="Row" />
          
            </Legends>
            <Series>
                <asp:Series Name="DefaultC">
                </asp:Series>
            </Series>
            <ChartAreas>
              <asp:ChartArea Name="ChartAreaC" BorderWidth="0">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
            <asp:Chart ID="DriveChartsD" runat="server">
            <titles>
                <asp:Title ShadowOffset="3" Name="Drive Space" />
            </titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom"
                            IsTextAutofit="False" Name="Drive Space"
                            LegendStyle="Row" />
          
            </Legends>
            <Series>
                <asp:Series Name="DefaultD">
                </asp:Series>
            </Series>
            <ChartAreas>
              <asp:ChartArea Name="ChartAreaD" BorderWidth="0">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    </p>
</asp:Content>
