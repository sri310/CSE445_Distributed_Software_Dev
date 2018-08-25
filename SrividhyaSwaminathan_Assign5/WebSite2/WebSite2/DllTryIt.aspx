<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DllTryIt.aspx.cs" Inherits="DllTryIt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <br />
        <h4>Service description - Encrypt Decrypt DLL</h4>
        Namespace: SecureString
        This Dll was created to encrypt and store passwords (for staff users) in xml file. 
        It has one class called EncryptDecrypt and two functions Encrypt and Decrupt.<br />
        Funtion name - EnCrypt() - called on a string. <br />
        Return value - string encrypted string<br />
        <asp:TextBox ID="txtEncrypt" runat="server" placeholder="Enter String to Encrypt"></asp:TextBox>
        <asp:Button ID="btn_Encrypt" runat="server" Text="Encrypt" OnClick="btn_Encrypt_Click" /><br />
        <asp:Label ID="lblEncrypt" runat="server"></asp:Label><br />
        Funtion name - Decrypt() - called on a string. <br />
        Return value - string Decrypted string<br />
        <asp:TextBox ID="txtDecrypt" runat="server" placeholder="Enter String to Dencrypt"></asp:TextBox>
        <asp:Button ID="btn_Decrypt" runat="server" Text="Dncrypt" OnClick="btn_Decrypt_Click" /><br />
        <asp:Label ID="lblDecrypt" runat="server"></asp:Label><br /><br /><br />
        ** note - Password in Users.XMl was encrypted using a script and then stored.
        
    </div>
</asp:Content>

