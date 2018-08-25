<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StaffHome.aspx.cs" Inherits="Staff_StaffHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <br />
        <h3>Hello, Staff. Click on any one of the following two options<br /><br />
            staff level 1 - view all users registerd in the system. <br />
    staff level 2 - view all users and get user specific stats like locations serached and no. of searches<br /><br />
        </h3>
        <asp:Button ID="staff1" OnClick="staff1_Click" Text="Staff 1" runat="server" />
        <asp:Button ID="staff2" OnClick="staff2_Click" Text="Staff 2" runat="server" />
        
     </div>
</asp:Content>

