<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AppPg1.aspx.cs" Inherits="Member_AppPg1" %>
<%@ Register TagPrefix = "dtw" TagName="datetimeweather" src="..\DateWeatherTime.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <dtw:datetimeweather runat="server" /> 
    <br /><br />
    <h4>Get the address of any store you want!!!</h4><br /><br />
    <asp:Label runat="server" ID="searchLabel" Text="Enter a store to search"></asp:Label>
    <asp:TextBox ID="yelpSearch"  runat="server" Width="5000px" Height="50px" placehoder="Search " ></asp:TextBox>
    <asp:Button ID="submitSearch" Text="GO" runat="server" OnClick="submitSearch_Click" /><br />
    <asp:Label ID="output" runat="server"></asp:Label><br /><br />
    <asp:Button ID="AppPg2" runat="server" OnClick="AppPg2_Click" Text="Go to Page 2 to get the weather related info" /><br /><br />
    <asp:Button ID="home" runat="server" OnClick="home_Click" Text="Pick another Location" />
</asp:Content>

