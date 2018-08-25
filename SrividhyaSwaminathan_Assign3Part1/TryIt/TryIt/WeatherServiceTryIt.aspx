<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WeatherServiceTryIt.aspx.cs" Inherits="TryIt.WeatherServiceTryIt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div><h3>Service Description: </h3>
        Service returns the 5-day weather forecast for a given zipcode. The out put is 2d list of strings consisting of 6 rows and 5 columns. 
        Row-1  shows format- ”Date", "minTemperature", "maxTemperature", "Day conditions", "Night conditions". 
        Rows 2-6 , hold corresponding values for each of the 5 days
    </div><br />
    <div>Url: http://localhost:51214/Service1.svc?singleWsdl </div><br />
    <div>Method Name: weatherService</div><br />
    <div>Input: string zipcode</div><br />
    <div>Output: List&lt;List&lt;string&gt;&gt;</div> <br />
    <div>
        <asp:TextBox ID="txtInput" runat="server" Width="200px" placeholder="Enter a Zipcode:"></asp:TextBox>
        <asp:Button ID="btn_InvokeWS" runat="server" OnClick="btn_InvokeWS_Click" Text="Invoke" />
    </div>
    <br />
    <div>
        <asp:Label ID ="lblWeatherForecast" runat="server"></asp:Label>
    </div>
</asp:Content>
