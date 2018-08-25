<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix = "dtw" TagName="datetimeweather" src="DateWeatherTime.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <dtw:datetimeweather runat="server" /><br />
<br /><br />
    <h4>This is a location based Application</h4>
    <div><br /><br />There are three types of users.
        <br />Member - can go in to the member pages, search for nearbystores and get weather related info.
        <br />Staff level 1 - See all the users of the system
        <br /> Staff level 2 - See all users of the system and also get user statistic<br />
                All member users can self subcribe but all staff users are precreated<br /><br />
    </div>
<asp:Button ID="mbrPgBtn" runat="server" OnClick="mbrPgBtn_Click" Text="Member page" /><br /><br />
<asp:Button ID="registerBtn" runat="server" OnClick="registerBtn_Click" Text="Member Self Subcribe" /><br /><br />
<asp:Button ID="mbrLogin" runat="server" OnClick="mbrLogin_Click" Text="Member Login" /><br /><br />
<asp:Button ID="staffLogin" runat="server" OnClick="staffLogin_Click" Text="staff login" /><br /><br />

<asp:Button ID="staffPgBtn" runat="server" OnClick="staffPgBtn_Click" Text="Staff Page" />
</asp:Content>
