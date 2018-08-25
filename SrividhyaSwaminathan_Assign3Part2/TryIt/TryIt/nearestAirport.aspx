<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="nearestAirport.aspx.cs" Inherits="TryIt.nearestAirport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div><h3>Service Description: </h3>
        This Service returns a 2d list having information about the nearest relevant airports for a given
        latitude and longitude.
    </div><br />
    <div>Url: http://webstrar61.fulton.asu.edu/Page2/Service1.svc?wsdl </div><br />
    <div>Method Name: nearestAirport</div><br />
    <div>Input: decimal latitude, decimal longitude</div><br />
    <div>Output: List&lt;List&lt;string&gt;&gt;</div> <br />
    <div>
        <asp:TextBox ID="txtLatitude" runat="server" Width="200px" placeholder="Enter Latitude:"></asp:TextBox>
        <asp:TextBox ID="txtLongitude" runat="server" Width="200px" placeholder="Enter Longitude:"></asp:TextBox>
        <asp:Button ID="btn_InvokeNAS" runat="server" OnClick="btn_InvokeNAS_Click" Text="Invoke" />
    </div>
    <br />
    <div>
        <asp:Label ID ="lblNearestAirports" runat="server"></asp:Label>
    </div>
</asp:Content>
