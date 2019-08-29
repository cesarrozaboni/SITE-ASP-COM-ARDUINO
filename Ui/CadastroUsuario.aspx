<%@ Page Title="" Language="C#" MasterPageFile="~/UI/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="TCC.UI.CadastroUsuario" %>

<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/CadastroUsuario/CadastroUsuario.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <asp:Panel runat="server" DefaultButton="btnBuscarMatricula">
        <div class=Cadastro07>
            <div class="Cadastro01">
                <span class="Cadastro02">Atualizar Cadastro</span>
            </div>
            <div class="Cadastro05">
                <div>
                    <div>
                        <span class="Cadastro03">MATRICULA</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="btnBuscarMatricula" CssClass="Cadastro04" runat="server" OnClick="btnBuscarMatricula_Click" ImageUrl="~/Imagens/btnPesquisar.png" />
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">NOME</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">SOBRENOME</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtSobrenome" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">SEXO</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlSexo" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="M">MASCULINO</asp:ListItem>
                            <asp:ListItem Value="F">FEMININO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="Cadastro05">
                <div>
                    <div>
                        <span class="Cadastro03">CIDADE</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlCidade" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">ITAPUI</asp:ListItem>
                            <asp:ListItem Value="2">BAURU</asp:ListItem>
                            <asp:ListItem Value="3">PEDERNEIRAS</asp:ListItem>
                            <asp:ListItem Value="4">JAU</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">ESTADO</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">SP</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">PAÍS</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlPais" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">BRASIL</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <div>
                        <span class="Cadastro03">ESTADO CIVIL</span>
                    </div>
                    <div>
                        <asp:DropDownList ID="ddlEstadoCivil" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">SOLTEIRO</asp:ListItem>
                            <asp:ListItem Value="2">CASADO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="Cadastro06">
                <asp:Button ID="btnSalvar" CssClass="btn-info" runat="server" Text="SALVAR" OnClick="btnSalvar_Click" />
            </div>
        </div>
    </asp:Panel>
    <uc1:Mensagem runat="server" ID="Mensagem" />
</asp:Content>
