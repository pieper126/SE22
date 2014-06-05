<%@ Page Title="Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="SE22.Category" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class = "well">
        <asp:Label ID="LblThreadName0" runat="server" Text="Thread name:"></asp:Label>
        <asp:Label ID="LblTotalPosts0" runat="server" Text="Total Post:" CssClass="right"></asp:Label>
    </div>    

    <div class ="well">        
        <asp:HyperLink ID="HyperLink1" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalPosts1" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="ThreadButton1" OnClick="ThreadButton1_Click" Visible="False" CausesValidation="False" />              
        <asp:Button Text="Alter" runat="server" ID="AlterButton1" OnClick="AlterButton1_Click" Visible="False" Width="44px" CausesValidation="False"/>      
        <asp:Button Text="delete" runat="server" ID="DeleteButton1" OnClick="DeleteButton1_Click" Visible="False"  CausesValidation="False"/>      
        <asp:CustomValidator ID="ThreadValidator1" runat="server" ErrorMessage="CustomValidator" CssClass="text-danger"></asp:CustomValidator>
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink2" CssClass ="" runat="server" Visible="False" >Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalPosts2" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="ThreadButton2" Visible="False" OnClick="ThreadButton2_Click" CausesValidation="False"/>       
        <asp:Button Text="Alter" runat="server" ID="AlterButton2" OnClick="AlterButton2_Click" Visible="False" CausesValidation="False"/>       
        <asp:Button Text="delete" runat="server" ID="DeleteButton2" OnClick="DeleteButton2_Click" Visible="False" CausesValidation="False"/>      
        <asp:CustomValidator ID="ThreadValidator2" runat="server" ErrorMessage="CustomValidator" CssClass="text-danger"></asp:CustomValidator>
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink3" CssClass ="" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalPosts3" runat="server" Text="-" Visible="False"></asp:Label>
        <asp:Button Text="go" runat="server" ID="ThreadButton3" Visible="False" OnClick="ThreadButton3_Click" CausesValidation="False"/>         
        <asp:Button Text="Alter" runat="server" ID="AlterButton3" OnClick="AlterButton3_Click" Visible="False" CausesValidation="False"/>         
        <asp:Button Text="delete" runat="server" ID="DeleteButton3" OnClick="DeleteButton3_Click" Visible="False" CausesValidation="False"/>      
        <asp:CustomValidator ID="ThreadValidator3" runat="server" ErrorMessage="CustomValidator" CssClass="text-danger"></asp:CustomValidator>
    </div>

    <div class ="well">        
        <asp:HyperLink ID="HyperLink4" CssClass ="" runat="server" Visible="False">Not Found</asp:HyperLink>
        <asp:Label ID="LblTotalPosts4" runat="server" Text="-" Visible="False"></asp:Label>  
        <asp:Button Text="go" runat="server" ID="ThreadButton4" Visible="False" Width="30px" OnClick="ThreadButton4_Click" CausesValidation="False"/>                
        <asp:Button Text="Alter" runat="server" ID="AlterButton4" OnClick="AlterButton4_Click" Visible="False" CausesValidation="False"/>                
        <asp:Button Text="delete" runat="server" ID="DeleteButton4" OnClick="DeleteButton4_Click" Visible="False" CausesValidation="False"/>      
        <asp:CustomValidator ID="ThreadValidator4" runat="server" ErrorMessage="CustomValidator" CssClass="text-danger"></asp:CustomValidator>
    </div>

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

