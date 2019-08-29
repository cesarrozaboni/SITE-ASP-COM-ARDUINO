<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TCC.UI.Home" %>
<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/Home/Home.css" rel="stylesheet" />
    <div>
        <div class="Home03">
            <div>
                <span class="Home01">BEM VINDO: </span>
                <asp:Label ID="lblNomeValue" CssClass="Home02" runat="server"></asp:Label>
            </div>
            <div>
                <span class="Home01">CADASTRO EM: </span>
                <asp:Label ID="lblCadastroValue" CssClass="Home02" runat="server"></asp:Label>
            </div>
        </div>
        <div>
            <asp:Image runat="server" CssClass="Home04" ImageUrl="~/Imagens/chuva.jpg" />
        </div>
    </div>
     <uc1:Mensagem runat="server" ID="Mensagem" />
</asp:Content>
