<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroUsuario.aspx.cs" Inherits="TCC.Login.cadastroUsuario" %>

<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Usuario</title>
    <link href="../Content/Login/Cadastro.css" rel="stylesheet" />
</head>
<body class="body">
    <form id="form1" runat="server">

        <asp:Panel ID="pnlCadastro" runat="server" DefaultButton="btnVoltar">

            <div class="divImagem">
            </div>

            <div class="row">
                <div class="col-sm-6 col-xs-12 col-sm-offset-4">
                    <div>
                        <span class="cadastroMatricula">MATRICULA</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtCdMatricula" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="rfvCdNome" CssClass="reqFieldVal" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtCdMatricula"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="Cadastro02">
                    <div>
                        <span class="Cadastro01">SENHA</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtCdSenha" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="rfvCdSenha" CssClass="reqFieldVal" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtCdSenha"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:RangeValidator ID="rgvSenha" runat="server" CssClass="reqFieldVal" ErrorMessage="INFORME UMA SENHA DE 4 A 8 DIGITOS" MaximumValue="99999999" MinimumValue="1000" Type="Integer" ControlToValidate="txtCdSenha"></asp:RangeValidator>
                    </div>
                </div>
                <div class="Cadastro03">
                    <div>
                        <span >CONFIRMAR SENHA</span>
                    </div>
                    <div>
                        <asp:TextBox ID="txtConfirmaSenha" TextMode="Password" runat="server" ControlToValidate="txtConfirmaSenha" CausesValidation="True"></asp:TextBox>
                    </div>
                    <div>
                        <asp:RequiredFieldValidator ID="frvConfirmaSenha" CssClass="reqFieldVal" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtConfirmaSenha"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:CompareValidator ID="cvSenha" CssClass="reqFieldVal" runat="server" ErrorMessage="SENHA DIFERENTE" ControlToCompare="txtCdSenha" ControlToValidate="txtConfirmaSenha"></asp:CompareValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="Cadastro05">
                    <div class="Cadastro02">
                        <div class="Cadastro01">
                            <span>EMAIL</span>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCdEmail" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:RequiredFieldValidator ID="rfvEmail" CssClass="reqFieldVal" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtCdEmail"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:RegularExpressionValidator ID="revEmail" CssClass="reqFieldVal" runat="server" Font-Bold="true" ErrorMessage="INFORME UM EMAIL VALIDO" ControlToValidate="txtCdEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div id="ConfirmarCodigo" class="row col-sm-6 col-xs-12 col-sm-offset-4 Cadastro06" runat="server" visible="false">
                        <div>
                            <span class="Cadastro07">CODIGO DE SEGURANÇA</span>
                        </div>
                        <div>
                            <asp:TextBox ID="txtCodigo" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6 col-xs-12 col-sm-offset-4">
                    <asp:Button ID="btnCadastrar" class="btn btn-info Cadastro08" Text="ENVIAR" runat="server" OnClick="btnCadastrar_Click"></asp:Button>
                    <asp:Button ID="btnVoltar" class="btn btn-danger Cadastro08" Text="Voltar" runat="server" CausesValidation="false" OnClick="btnVoltar_Click"></asp:Button>
                </div>
            </div>
        </asp:Panel>
        <uc1:Mensagem runat="server" ID="Mensagem" />
    </form>
</body>
</html>
