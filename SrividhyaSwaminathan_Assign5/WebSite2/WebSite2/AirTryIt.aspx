<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AirTryIt.aspx.cs" Inherits="AirTryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div><h3>Service Description: </h3>
        This service returns the airquality index and Pollution Level status for a given lattitude and longitude.
        Return string has airaquality index followed by a comma and the pollution level status. 
    </div><br />
    <div>Url:http://webstrar61.fulton.asu.edu/Page1/Service1.svc?wsdl </div><br />
    <div>Method Name: AirQuality</div><br />
    <div>Input: decimal lattitude, decimal longitude</div><br />
    <div>Output: String of format “{Air quality Index},{Pollution Level}”</div> <br />
    <div>
        <asp:TextBox ID="txtInputLattitude" runat="server" Width="200px" placeholder="lattitude"></asp:TextBox>
        <asp:TextBox ID="txtInputLongitude" runat="server" Width="200px" placeholder="longitude"></asp:TextBox>
        <asp:Button ID="btn_InvokeAQS" runat="server" OnClick="btn_InvokeAQS_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblAirQuality" runat="server"></asp:Label>
    </div>
</asp:Content>

