<%@ Page Title="Thread" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="SE22.Thread" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class = "well"> 
         <div>
            <asp:TextBox ID="PostTB0" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="PostedBy0" runat="server" Text="Label" Style="margin-top: 10px;" Visible="False"></asp:Label>
             <asp:Button ID="BtnAlter0" Text="Alter" runat="server" OnClick="BtnAlter0_Click" CausesValidation="False"/>
             <asp:Button ID="BtnDelete0" Text="Delete" runat="server" OnClick="BtnDelete0_Click" CausesValidation="False"/>
             <asp:CustomValidator ID="ThreadValidator1" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </div>
    </div>

    <div class = "well"> 
         <div>
            <asp:TextBox ID="PostTB1" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="PostedBy1" runat="server" Text="Label" Style="margin-top: 10px;" Visible="False"></asp:Label>
             <asp:Button ID="BtnAlter1" Text="Alter" runat="server" OnClick="BtnAlter1_Click" CausesValidation="False"/>
             <asp:Button ID="BtnDelete1" Text="Delete" runat="server" OnClick="BtnDelete1_Click" style="height: 26px" CausesValidation="False"/>
             <asp:CustomValidator ID="ThreadValidator2" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </div>
    </div>

    <div class = "well"> 
         <div>
            <asp:TextBox ID="PostTB2" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="PostedBy2" runat="server" Text="Label" Style="margin-top: 10px;" Visible="False"></asp:Label>
             <asp:Button ID="BtnAlter2" Text="Alter" runat="server" OnClick="BtnAlter2_Click" CausesValidation="False"/>
            <asp:Button ID="BtnDelete2" Text="Delete" runat="server" OnClick="BtnDelete2_Click" CausesValidation="False"/>
             <asp:CustomValidator ID="ThreadValidator3" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </div>
    </div>

    <div class = "well"> 
         <div>
            <asp:TextBox ID="PostTB3" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="PostedBy3" runat="server" Text="Label" Style="margin-top: 10px;" Visible="False"></asp:Label>
             <asp:Button ID="BtnAlter3" Text="Alter" runat="server" OnClick="BtnAlter3_Click" CausesValidation="False"/>
            <asp:Button ID="BtnDelete3" Text="Delete" runat="server" OnClick="BtnDelete3_Click" CausesValidation="False"/>
             <asp:CustomValidator ID="ThreadValidator4" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </div>
    </div>

    <div class = "well"> 
         <div>
            <asp:TextBox ID="PostTB4" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="PostedBy4" runat="server" Text="Label" Style="margin-top: 10px;" Visible="False"></asp:Label>
             <asp:Button ID="BtnAlter4" Text="Alter" runat="server" OnClick="BtnAlter4_Click" />
            <asp:Button ID="BtnDelete4" Text="Delete" runat="server" OnClick="BtnDelete4_Click" />
             <asp:CustomValidator ID="ThreadValidator5" CssClass="text-danger" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
        </div>
    </div>

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
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="A post at least needs some content!" ControlToValidate="Tb" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button ID="BtnNewPost" runat="server" Text="Post!" Width="64px" Style="margin-top: 10px" OnClick="BtnNewPost_click" />
            <asp:CustomValidator ID="LoggedInUserValidator" runat="server" ErrorMessage="User needs to be logged in" CssClass="text-danger"></asp:CustomValidator>
        </div>
    </div>

</asp:Content>

