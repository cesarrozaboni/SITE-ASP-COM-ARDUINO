using System;

namespace SistemaOficina.UserControl
{
    public partial class Mensagem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public delegate void buttonOkEventHandler(object source, EventArgs e);
        public event buttonOkEventHandler buttonOk;

        public delegate void buttonSimEventHandler(object source, EventArgs e);
        public event buttonSimEventHandler buttonSim;

        public delegate void buttonNaoEventHandler(object source, EventArgs e);
        public event buttonNaoEventHandler buttonNao;

        protected virtual void btnOk_Click(object source, EventArgs e)
        {
            buttonOk?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void btnSim_Click(object source, EventArgs e)
        {
            buttonSim?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void btnNao_Click(object source, EventArgs e)
        {
            buttonNao?.Invoke(this, EventArgs.Empty);
        }

        public void MensagemAlerta(string mensagem)
        {
            ucMensagens.Visible = true;
            lblMensagem.Text = mensagem.Trim();
            btnOk.Focus();
        }

        public void MensagemPergunta(string mensagem)
        {
            ucMensagens.Visible = true;
            lblMensagem.Text = mensagem.Trim();
            btnNao.Focus();
        }


        public void FecharMensagemAlerta()
        {
            ucMensagens.Visible = false;
        }

        public void FecharMensagemPergunta()
        {
            ucPergunta.Visible = false;
        }
    }
}