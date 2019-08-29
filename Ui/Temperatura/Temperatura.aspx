<%@ Page Title="" Language="C#" MasterPageFile="~/Ui/MasterPage.Master" AutoEventWireup="true" CodeBehind="Temperatura.aspx.cs" Inherits="TCC.Ui.Login.Temperatura.Temperatura" %>
<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/Temperatura/Temperatura.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <asp:Panel ID="pnlConsulta" runat="server">
        <div>
            <span class="Temp1">Selecionar Cidade:</span>
            <asp:DropDownList ID="ddlCidade" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="455845">Bauru</asp:ListItem>
                <asp:ListItem Value="436118">Itapuí</asp:ListItem>
                <asp:ListItem Value="443390">Pederneiras</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnPesquisar" Text="PESQUISAR" CssClass="btn-info Temp5" runat="server" OnClick="btnPesquisar_Click" />
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlDetalhes" runat="server" Visible="false">
        <div class="Temp4">
            <div class="Temp3">
                <div>
                    <span class="Temp1">Cidade:</span>
                    <asp:Label ID="CidadeValue" runat="server" CssClass="Temp2"></asp:Label>
                </div>
                <div>
                    <span class="Temp1">Região:</span>
                    <asp:Label ID="regiaoValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
                <div>
                    <span class="Temp1">País:</span>
                    <asp:Label ID="paisValue" runat="server" CssClass="Temp2"></asp:Label>
                </div>
            </div>
            <div class="Temp3">
                <div>
                    <span class="Temp1">Velocidade Do vento</span>
                    <asp:Label ID="velocValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
                <div>
                    <span class="Temp1">Umidade do Ar:</span>
                    <asp:Label ID="UmidadeValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
            </div>
            <div class="Temp3">
                <div>
                    <span class="Temp1">Nascer do Sol:</span>
                    <asp:Label ID="nascenteValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
                <div>
                    <span class="Temp1">Por do sol:</span>
                    <asp:Label ID="poenteValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
            </div>
            <div class="Temp3">
                <div>
                    <span class="Temp1">Condição:</span>
                    <asp:Label ID="condicaoValue" runat="server" CssClass="Temp2"></asp:Label>;
                </div>
                <div>
                    <span class="Temp1">Temperatura:</span>
                    <asp:Label ID="temperaturaValue" runat="server" CssClass="Temp2"></asp:Label>
                </div>
            </div>
        </div>

    </asp:Panel>
    <uc1:Mensagem runat="server" ID="Mensagem" />
</asp:Content>
