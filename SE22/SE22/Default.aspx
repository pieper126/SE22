<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SE22._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <link href="Style.css" rel="stylesheet" type="text/css" />  
    <div class = "well">
        <asp:Label ID="LblCategoryName0" runat="server" Text="Category name:"></asp:Label>
        <asp:Label ID="LblTotalThreads0" runat="server" Text="Total Threads:" CssClass="right"></asp:Label>
    </div>    

    <div class ="well">        
        <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalThreads1" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="CategoryButton1" OnClick="CategoryButton1_Click" Visible="False"/>      
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink2" CssClass ="" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalThreads2" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="CategoryButton2" Visible="False"/>       
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink3" CssClass ="" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalThreads3" runat="server" Text="-" Visible="False"></asp:Label>
        <asp:Button Text="go" runat="server" ID="CategoryButton3" Visible="False"/>         
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink4" CssClass ="" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalThreads4" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="CategoryButton4" Visible="False" />                
    </div>
 </asp:Content>
