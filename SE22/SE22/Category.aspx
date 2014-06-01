<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SE22.Category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
            <asp:Label ID="LblType" runat="server" Text="Label" Style="margin-top: 10px;"></asp:Label>
        </div>
        <div>
            <asp:Label ID="LblName" runat="server" Text="Label" Style="margin-top: 5px;"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="TbName" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="Tb" runat="server" Style="margin-bottom: 8" Height="182px" Width="603px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="64px" Style="margin-top: 10px" OnClick="Button1_Click" />
        </div>
    </div>

</asp:Content>

