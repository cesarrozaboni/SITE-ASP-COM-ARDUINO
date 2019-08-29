using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCC.UI
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Mensagem.buttonOk += Mensagem_buttonOk;
            if (!IsPostBack)
            {
                txtId.Focus();
                txtId.Text = ConstSession.Usuario;
            }
        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }

        protected void btnBuscarMatricula_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BLL.BLL obj = new BLL.BLL();
                var result = obj.Detalhes(txtId.Text);

                txtNome.Text = result.ElementAt(1);
                txtSobrenome.Text = result.ElementAt(2);
                ddlCidade.SelectedIndex = Convert.ToInt32(result.ElementAt(3));
                ddlEstado.SelectedIndex = Convert.ToInt32(result.ElementAt(4));
                ddlPais.SelectedIndex = Convert.ToInt32(result.ElementAt(5));
                ddlSexo.SelectedIndex = (result.ElementAt(6) == "M") ? 1 : 2;
                ddlEstadoCivil.SelectedIndex = Convert.ToInt32(result.ElementAt(7));
                ddlCidade.DataBind();
            }
            catch (Exception ex)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL obj = new BLL.BLL();
                obj.AtualizarUsuario(txtId.Text, txtNome.Text, txtSobrenome.Text, ddlCidade.SelectedValue, ddlEstado.SelectedValue, ddlPais.SelectedValue, ddlSexo.SelectedValue, ddlEstadoCivil.SelectedValue);
                Mensagem.MensagemAlerta("Operação Concluida");
            }
            catch (Exception ex)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }
    }
}