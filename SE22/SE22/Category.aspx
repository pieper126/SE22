<%@ Page Title="Category" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SE22.Category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class = "well">
        <asp:Label ID="LblThreadName0" runat="server" Text="Thread name:"></asp:Label>
        <asp:Label ID="LblTotalPosts0" runat="server" Text="Total Post:" CssClass="right"></asp:Label>
    </div>    

    <asp:Panel runat="server" ID="panel">
    </asp:Panel>        

    <div class ="well">
        <asp:Button ID="BtnPrev" Text="Prev" runat="server" OnClick="BtnPrev_Click" CausesValidation="False"/>
        <asp:Button ID="BtnNext" Text="Next" runat="server" OnClick="BtnNext_Click" CausesValidation="False"/>
    </div>

    <div>
        <div>
            <h2><asp:Label ID="LblType" runat="server" Text="New Thread" Style="margin-top: 10px;"></asp:Label></h2>
        </div>
        <div>
            <asp:Label ID="LblName" runat="server" Text="ThreadName" Style="margin-top: 5px;"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="TbName" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="A Thread atleast needs a name!" ControlToValidate="TbName" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Content first post"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="TbContent" runat="server" Style="margin-bottom: 8" Height="182px" Width="603px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ContentValidator" runat="server" ErrorMessage="A Thread atleast needs some content!" ControlToValidate="TbContent" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Button ID="NewThreadbutton" runat="server" Text="Post New Thread" Width="139px" Style="margin-top: 10px" OnClick="NewThreadbutton_Click" />
            <asp:CustomValidator ID="LoggedInUserValidator" runat="server" ErrorMessage="User needs to be logged in" CssClass="text-danger"></asp:CustomValidator>
        </div>
    </div>

</asp:Content>

