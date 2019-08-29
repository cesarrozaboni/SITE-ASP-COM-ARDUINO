<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TCC.Login.Login" %>

<%@ Register Src="~/UserControl/Mensagem.ascx" TagPrefix="uc1" TagName="Mensagem" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Content/Bootstrap.css" rel="stylesheet" />
    <link href="../Content/Login/Login.css" rel="stylesheet" />
    <title>Login </title>
</head>

<body class="body">

    <form id="form1" runat="server">
        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
            <div class="divTopoLogin" runat="server">
            </div>
            <div class="container">

                <div class="row">
                    <div class="Login01">
                        <span class="lblMatricula">MATRICULA: </span>
                        <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                        <div class="reqFieldVal">
                            <asp:RequiredFieldValidator ID="rfvMatricula" CssClass="reqFieldVal2" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtMatricula"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="Login01">
                        <span class="lblSenha">SENHA: </span>
                        <asp:TextBox ID="txtSenha" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:Button ID="btnLogin" Text="Login" class="btn-info Login02" runat="server" OnClick="btnLogin_Click"></asp:Button>
                        <div class="Login03">
                            <asp:RequiredFieldValidator ID="rfvSenha" CssClass="reqFieldVal2" runat="server" ErrorMessage="CAMPO OBRIGATORIO" ValidateRequestMode="Inherit" ControlToValidate="txtSenha" ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div id="TrocarSenha" runat="server" class="row Login04" visible="false">
                    <asp:LinkButton Class="lkBtn" runat="server" CausesValidation="false" OnClick="lkBtnTrocarSenha_Click">REDEFINIR SENHA</asp:LinkButton>
                </div>

                <div class="row Login04">
                    <asp:LinkButton Class="lkBtn" runat="server" CausesValidation="false" OnClick="lkBtnCadastrar_Click">CADASTRAR USUÁRIO</asp:LinkButton>
                </div>
            </div>
        </asp:Panel>

        <uc1:Mensagem runat="server" ID="Mensagem" />
    </form>
</body>
<script src="../Scripts/Login/Login.js"></script>
</html>
