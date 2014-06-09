<%@ Page Title="Thread" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="SE22.Thread" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="panel">
    </asp:Panel>

    <div class ="well">
        <asp:Button ID="BtnPrev" Text="Prev" runat="server" OnClick="BtnPrev_Click" CausesValidation="False"/>
        <asp:Button ID="BtnNext" Text="Next" runat="server" OnClick="BtnNext_Click" CausesValidation="False"/>
    </div>

    <div class ="well">
        <div>
            <h2><asp:Label  ID="LblType" runat="server" Text="New Post" Style="margin-top: 10px;"></asp:Label></h2>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Content"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="Tb" runat="server" Style="margin-bottom: 8" Height="182px" Width="603px" TextMode="MultiLine" Wrap ="true"></asp:TextBox>
            <asp:RequiredFieldValidator ID="TbRequiredFieldValidator" runat="server" ErrorMessage="A post at least needs some content!" ControlToValidate="Tb" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button ID="BtnNewPost" runat="server" Text="Post!" Width="64px" Style="margin-top: 10px" OnClick="BtnNewPost_click" />
            <asp:CustomValidator ID="LoggedInUserValidator" runat="server" ErrorMessage="User needs to be logged in" CssClass="text-danger"></asp:CustomValidator>
        </div>
    </div>

</asp:Content>

