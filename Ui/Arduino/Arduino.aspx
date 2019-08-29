<%@ Page Title="" Language="C#" MasterPageFile="~/Ui/MasterPage.Master" AutoEventWireup="true" CodeBehind="Arduino.aspx.cs" Inherits="TCC.Ui.Arduino.Arduino" %>

<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/Arduino/Arduino.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <asp:Panel ID="pnlDetalhes" runat="server">
        <div style="width: 100%; text-align: center;">
            <asp:Button runat="server" CssClass="btn btn-success" Text="Ligar" OnClick="btnLigaLed_Click" />
            <asp:Button runat="server" Text="Desligar" CssClass="btn btn-danger" OnClick="btnDesligaLed_Click" />
            <asp:Button runat="server" Text="Atualizar" CssClass="btn btn-info" OnClick="btnAtualizarTemperatura_Click" />
        </div>
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
