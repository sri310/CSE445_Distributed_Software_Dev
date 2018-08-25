<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Staff2Home.aspx.cs" Inherits="Staff_Staff2Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <h4>Hello staff level 2 user!</h4><br /><br />

    <asp:Label ID="lblUsers" runat="server"></asp:Label><br/><br />
    <asp:TextBox ID="txtUsername" runat="server" placeholder="enter a valid user name" Width="1500px"></asp:TextBox>
    <asp:Button ID="getUserStats" runat="server" Text="Get User Stats" Onclick="getUserStats_Click"/><br /><br />
    <asp:Label ID="lblUserStat" runat="server"></asp:Label>
</asp:Content>



