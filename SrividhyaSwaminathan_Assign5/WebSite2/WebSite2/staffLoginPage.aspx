<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="staffLoginPage.aspx.cs" Inherits="staffLoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <div>
        <h4>Welcome to the staff login page</h4><br />
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="click" runat="server" OnClick="click_Click" Text="submit" /><br />
        <asp:CheckBox ID="Persistent" Text="Keep me signed in" runat="server" /><br />
        <asp:Label ID="Output" runat="server"></asp:Label>
        <a href="Account/Login.aspx">Click here to login as member</a>
     </div>
</asp:Content>

