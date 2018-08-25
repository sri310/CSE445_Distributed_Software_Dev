<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetLatLngServiceTryIt.aspx.cs" Inherits="TryIt.GetLatLngServiceTryItaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div><h3>Service Description: </h3>
       This service returns the lattitude and longitude of any US zip code. 
    </div><br />
    <div>Url: http://localhost:51214/Service1.svc?singleWsdl </div><br />
    <div>Method Name: getLatLngService</div><br />
    <div>Input: string zipcode</div><br />
    <div>Output: String of format “{latitude},{longitude}”</div> <br />
    <div>
        <asp:TextBox ID="txtInputZipCode" runat="server" Width="300px" placeholder="Enter Zipcode"></asp:TextBox>
        <asp:Button ID="btn_InvokeGLLS" runat="server" OnClick="btn_InvokeGLLS_Click" Text="Invoke" />
        <br />
    </div>
    <div>
        <asp:Label ID ="lblLatLong" runat="server"></asp:Label>
    </div>
</asp:Content>
