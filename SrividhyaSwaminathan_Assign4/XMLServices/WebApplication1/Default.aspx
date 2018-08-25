<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <br />
    <div><h3>Service Description: </h3>
       Method transforms an xml into html using a xsl doucument 
    </div><br />   
    <div>Method Name: transoformation</div><br />
    <div> Input - string url for xml, string url for xsl</div><br />
    <div>Output: byte array representing the html</div> <br />
    <div>
        <asp:TextBox ID="txtXMLUrl" runat="server" Width="1500px" placeholder="Enter XML Url: "></asp:TextBox><br />
        <asp:TextBox ID="txtXslUrl" runat="server" Width="1500px" placeholder="Enter Xsl Url "></asp:TextBox>
        <asp:Button ID="btn_transform" runat="server" OnClick="btn_transform_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblHtml" runat="server"></asp:Label>
    </div>

</asp:Content>
