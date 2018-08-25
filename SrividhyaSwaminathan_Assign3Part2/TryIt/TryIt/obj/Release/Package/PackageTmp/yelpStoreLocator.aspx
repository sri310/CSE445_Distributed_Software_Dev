<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="yelpStoreLocator.aspx.cs" Inherits="TryIt.yelpStoreLocator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <div><h3>Service Description: RESTFUL </h3>
        Use an existing online yelp API to find the provided storeName closest to the location and return the address. 
        If no store is found, return an error message. If the store is further than 20 miles, from the zipcode, return a
        “no stores within 20 miles” message"
    </div><br />
    <div>BaseUrl: http://webstrar61.fulton.asu.edu/page0/Service1.svc/findNearestStore3?</div><br />
    <div>Method Name: findNeareststore</div><br />
    <div>Parameter: latitude, longitude, storeName</div><br />
    <div>Response: string address</div> <br />
    <div>Example of full URL :  http://webstrar61.fulton.asu.edu/page0/Service1.svc/findNearestStore3?latitude=33.4093&longitude=-111.92&storeName=711</div> <br />
    <div>
        <asp:TextBox ID="txtInputLatitude" runat="server" Width="200px" placeholder="Enter Latitude: "></asp:TextBox>
        <asp:TextBox ID="txtInputLongitude" runat="server" Width="200px" placeholder="Enter Longitude: "></asp:TextBox>
        <asp:TextBox ID="txtStoreName" runat="server" Width="200px" placeholder="Enter store name: "></asp:TextBox>
        <asp:Button ID="btn_InvokeRestful" runat="server" OnClick="btn_InvokeRestful_Click" Text="Invoke" />
    </div><br />
    <div>
        <asp:Label ID="lblAddress" runat="server"></asp:Label>
    </div>
</asp:Content>
