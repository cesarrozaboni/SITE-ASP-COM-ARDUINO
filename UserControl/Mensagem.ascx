<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensagem.ascx.cs" Inherits="SistemaOficina.UserControl.Mensagem" %>
<!--CSS Bootstrap-->
<link href="../Content/Bootstrap.css" rel="stylesheet" />

<asp:Panel ID="ucMensagens" runat="server" Visible="false">
    <div style="width: 300px; height: 150px; position: relative; display: block; margin-top: -100px; margin-left: 33%; background-color: #fafb98; border: 3px solid red; text-align: center; padding: 0px;" runat="server">
        <div style="padding: 20px;" runat="server">
            <div style="padding: 0px">
                <asp:Label ID="lblMensagem" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                <br />
                <asp:Button ID="btnOk" type="button" class="btn btn-info" runat="server" CausesValidation="false" Text="OK" OnClick="btnOk_Click" />
            </div>
        </div>
    </div>
</asp:Panel>

<asp:Panel ID="ucPergunta" runat="server" Visible="false">
    <div style="width: 300px; height: 150px; position: relative; display: block; margin-top: -100px; margin-left: 33%; background-color: #d0d1cb; border: 3px solid blue; text-align: center; padding: 0px;" runat="server">
        <div style="padding: 20px;" runat="server">
            <div style="padding: 0px">
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Label"></asp:Label>
                <br />
                <asp:Button ID="btnSim" type="button" class="btn btn-info" runat="server" CausesValidation="false" Text="SIM" OnClick="btnSim_Click" />
                <asp:Button ID="btnNao" type="button" class="btn btn-info" style="margin-left:15px" runat="server" CausesValidation="false" Text="NAO" OnClick="btnNao_Click" />
            </div>
        </div>
    </div>
</asp:Panel>

