<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AirQualityServiceTryIt.aspx.cs" Inherits="TryIt.AirQualityServiceTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div><h3>Service Description: </h3>
        This service returns the airquality index and Pollution Level status for a given lattitude and longitude.
        Return string has airaquality index followed by a comma and the pollution level status. 
    </div><br />
    <div>Url: http://localhost:51214/Service1.svc?singleWsdl </div><br />
    <div>Method Name: AirQuality</div><br />
    <div>Input: decimal lattitude, decimal longitude</div><br />
    <div>Output: String of format “{Air quality Index},{Pollution Level}”</div> <br />
    <div>
        <asp:TextBox ID="txtInputLattitude" runat="server" Width="200px" placeholder="lattitude"></asp:TextBox>
        <asp:TextBox ID="txtInputLongitude" runat="server" Width="200px" placeholder="longitude"></asp:TextBox>
        <asp:Button ID="btn_InvokeAQS" runat="server" OnClick="btn_InvokeAQ_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblAirQuality" runat="server"></asp:Label>
    </div>
</asp:Content>
