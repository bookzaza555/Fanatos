<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TempleProject.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label></div>
    <div>
        <asp:TextBox ID="tbUsername" runat="server" placeholder="username"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox ID="tbPassword" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
    </div>
    
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click1" />
    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />
</asp:Content>
