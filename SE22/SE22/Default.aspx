<%@ Page Title="Home Page" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <link href="Style.css" rel="stylesheet" type="text/css" />  
    <div class = "well">
        <asp:Label ID="LblCategoryName0" runat="server" Text="Category name:"></asp:Label>
        <asp:Label ID="LblTotalThreads0" runat="server" Text="Total Threads:" CssClass="right"></asp:Label>
    </div>   

    <asp:Panel runat="server" ID="panel">
    </asp:Panel>        
 </asp:Content>
