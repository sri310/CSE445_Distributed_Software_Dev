<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MemberHome.aspx.cs" Inherits="Member_MemberHome" %>
<%@ Register TagPrefix = "dtw" TagName="datetimeweather" src="..\DateWeatherTime.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br /><br />
    <h4>Location based App</h4>
    <br />
    <div> You need to enter a zipcode</div>
    <br />
    A zipcode lookup service is shown below to help you find your zipcode.<br />
    <asp:TextBox ID="cityName" placeholder="Enter city name" runat="server"></asp:TextBox>
    <asp:TextBox ID="stateCode" placeholder="Enter state code" runat="server"></asp:TextBox>
    <asp:Button ID="zipLookup" runat="server" OnClick="zipLookup_Click" Text="Lookup Zipcodes" /><br />
    <asp:Label ID="lblZips" runat="server"></asp:Label>
    <br /><br />
    <h4>Enter Valid Zipcode to continue with the applciation</h4>
    <br/>
    <asp:TextBox ID="zipCode" Width="200px" runat="server"></asp:TextBox>
    <asp:Button ID="submit" runat="server" OnClick="submit_Click" Text="Submit" />
    <asp:Label ID="error" runat="server"></asp:Label>
 

</asp:Content>

