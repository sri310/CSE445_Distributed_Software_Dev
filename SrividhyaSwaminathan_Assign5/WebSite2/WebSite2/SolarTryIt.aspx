<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SolarTryIt.aspx.cs" Inherits="SolarTryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <br />
    <div><h3>Service Description: </h3>
        This service returns the average annual solar intensity for the given location.<br />
        <br /> Metric used :
        ALLSKY_SFC_SW_DWN - Averaged Insolation Incident On A Horizontal Surface
                             -The average amount of the total solar radiation incident 
                              on a horizontal surface at the surface of the earth.
    </div><br />
    <div>Url: http://webstrar61.fulton.asu.edu/Page2/Service1.svc?wsdl </div><br />
    <div>Method Name: SolarIntensity</div><br />
    <div>Input: decimal lattitude, decimal longitude</div><br />
    <div>Output: dcimal avgAnnualSolarIntensity</div> <br />
    <div>
        <asp:TextBox ID="txtInputLattitude" runat="server" Width="200px" placeholder="lattitude"></asp:TextBox>
        <asp:TextBox ID="txtInputLongitude" runat="server" Width="200px" placeholder="longitude"></asp:TextBox>
        <asp:Button ID="btn_InvokeSIS" runat="server" OnClick="btn_InvokeSIS_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblSolarIntensity" runat="server"></asp:Label>
    </div>
</asp:Content>

