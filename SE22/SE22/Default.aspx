<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <link href="Style.css" rel="stylesheet" type="text/css" />  
    <div class = "well">
        <asp:Label ID="LblCategoryName" runat="server" Text="Category name:"></asp:Label>
        <asp:Label ID="LblTotalPosts" runat="server" Text="Total posts:"></asp:Label>
        <asp:Label ID="LblTotalThreads" runat="server" Text="Total Threads:" CssClass="right"></asp:Label>
    </div>    

    <div class ="well">        
        <asp:HyperLink ID="HyperLink0" runat="server">HyperLink</asp:HyperLink>
        <asp:Label ID="LblTotalPosts0" runat="server" Text="1000"></asp:Label>
        <asp:Label ID="LblTotalThreads0" runat="server" Text="1000"></asp:Label>        
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink1" CssClass ="" runat="server">HyperLink</asp:HyperLink>
        <asp:Label ID="LblTotalPosts1" runat="server" Text="1000"></asp:Label>
        <asp:Label ID="LblTotalThreads1" runat="server" Text="1000"></asp:Label>        
    </div>
 </asp:Content>
