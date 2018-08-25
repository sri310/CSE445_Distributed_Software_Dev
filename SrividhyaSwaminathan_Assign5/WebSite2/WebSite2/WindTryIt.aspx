<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WindTryIt.aspx.cs" Inherits="WindTryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div><h3>Service Description: </h3>
        This service returns the average annual wind intensity at 10m for the give location. 
    </div><br />
    <div>Url: http://webstrar61.fulton.asu.edu/Page2/Service1.svc?wsdl </div><br />
    <div>Method Name: WindIntenstiy</div><br />
    <div>Input: decimal lattitude, decimal longitude</div><br />
    <div>Output: dcimal avgAnnualWindIntensity</div> <br />
    <div>
        <asp:TextBox ID="txtInputLattitude" runat="server" Width="200px" placeholder="lattitude"></asp:TextBox>
        <asp:TextBox ID="txtInputLongitude" runat="server" Width="200px" placeholder="longitude"></asp:TextBox>
        <asp:Button ID="btn_InvokeWIS" runat="server" OnClick="btn_InvokeWIS_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblWindIntensity" runat="server"></asp:Label>
    </div>
</asp:Content>

