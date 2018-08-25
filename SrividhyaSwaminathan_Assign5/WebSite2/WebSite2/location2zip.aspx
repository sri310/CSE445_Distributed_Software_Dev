<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="location2zip.aspx.cs" Inherits="location2zip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <div><h3>Service Description: </h3>
        This service returns a string array of zipocdes for a given city name and state code
    </div><br />
    <div>Url: http://webstrar61.fulton.asu.edu/Page2/Service1.svc?wsdl </div><br />
    <div>Method Name: location2zip</div><br />
    <div>Input: string cityName, string staeCode</div><br />
    <div>Output: string[] zipcodes</div> <br />
    <div>
        <asp:TextBox ID="txtInputCityName" runat="server" Width="200px" placeholder="Enter city name: "></asp:TextBox>
        <asp:TextBox ID="txtInputStateCode" runat="server" Width="200px" placeholder="Enter state code: "></asp:TextBox>
        <asp:Button ID="btn_Invokel2z" runat="server" OnClick="btn_Invokel2z_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblZipCodes" runat="server"></asp:Label>
    </div>
</asp:Content>

