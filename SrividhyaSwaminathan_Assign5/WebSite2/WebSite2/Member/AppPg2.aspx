<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AppPg2.aspx.cs" Inherits="Member_AppPg2" %>
<%@ Register TagPrefix = "dtw" TagName="datetimeweather" src="..\DateWeatherTime.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <dtw:datetimeweather runat="server" /> 
    <br /><br />
    <div>** Wind and Solar Intensity services are slow. Please hold on for a second to see your result.<br /></div>
    <asp:Button ID="weather" runat="server" OnClick="weather_Click" Text="Get Today's Weather" /><br /><br />
    <asp:Button ID="airQuality" runat="server" OnClick="airQuality_Click" Text="Know your air quality Index" /><br /><br />
    <asp:Button ID="windIntensity" runat="server" OnClick="windIntensity_Click" Text="Get wind Intensity" /><br /><br />
    <asp:Button ID="solarIntensity" runat="server" OnClick="solarIntensity_Click" Text="Get Solar Intensity" /><br /><br />
    <asp:Label ID="output" runat="server"></asp:Label><br /><br />
    <asp:Button ID="AppPg1" runat="server" OnClick="AppPg1_Click" Text="search for a store" /><br /><br />
    <asp:Button ID="home" runat="server" OnClick="home_Click" Text="Pick another Location" />
</asp:Content>

