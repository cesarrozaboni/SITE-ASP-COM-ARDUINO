using System;
using System.Linq;

namespace TCC.UI
{
    #region "Metodos da classe"
    public partial class Home : ConstSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Mensagem.buttonOk += Mensagem_buttonOk;
            if (!IsPostBack)
            {
                try
                {
                    ValidaUsuario();
                    BLL.BLL obj = new BLL.BLL();
                    var result = obj.Detalhes(Usuario);

                    lblNomeValue.Text = result.ElementAt(1) + result.ElementAt(2);
                    lblCadastroValue.Text = string.IsNullOrEmpty(result.ElementAt(9).Trim())? " " : FormatarData(result.ElementAt(9));
                }
                catch (Exception)
                {
                    Mensagem.MensagemAlerta("Erro Ao Executar Operação");
                }
            }
        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }
    }
    #endregion
}