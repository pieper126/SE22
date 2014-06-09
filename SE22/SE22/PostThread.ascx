<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostThread.ascx.cs" Inherits="SE22.PostThread" %>
    <div class ="well">       
          <div>
            <asp:TextBox ID="PostTB" runat="server" CssClass="col-md-offset-0" Style="margin-bottom: 5px; margin-left: 5px;" ReadOnly="True" Height="60px" Width="572px" Visible="False"></asp:TextBox>
        </div>        
        <asp:HyperLink ID="HyperLink" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="Lbl" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="GoButton" OnClick="GoButton_Click" Visible="False" CausesValidation="False" />              
        <asp:Button Text="Alter" runat="server" ID="AlterButton" OnClick="AlterButton_Click" Visible="False" Width="44px" CausesValidation="False"/>      
        <asp:Button Text="delete" runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" Visible="False"  CausesValidation="False"/>      
        <asp:CustomValidator ID="ThreadValidator1" runat="server" ErrorMessage="CustomValidator" CssClass="text-danger"></asp:CustomValidator>
    </div>