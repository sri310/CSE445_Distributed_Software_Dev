<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XPathSearch.aspx.cs" Inherits="WebApplication1.XPathSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div><h3>Service Description: </h3>
      Method searches the xml document for a given xpath expression and returns the child nodes or content value based on the search expression
    </div><br />   
    <div>Method Name: XPathSearch</div><br />
    <div>Input - stirng url for xml, string path to search</div><br />
    <div>Output - List of string showing child nodes or content value</div> <br />
    <div>
        <asp:TextBox ID="txtXMLUrl" runat="server" Width="1500px" placeholder="Enter XML Url: "></asp:TextBox><br />
        <asp:TextBox ID="txtPath" runat="server" Width="1500px" placeholder="Enter Path expression "></asp:TextBox>
        <asp:Button ID="btn_search" runat="server" OnClick="btn_search_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
</asp:Content>
