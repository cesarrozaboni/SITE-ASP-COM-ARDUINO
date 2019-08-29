using System;
using System.Net.Mail;

namespace TCC.Login
{
    public partial class Login : ConstSession
    {
        #region "Constantes"
        private readonly string remetenteEmail = "sustentabilidade03@gmail.com"; //O e-mail do remetente
        #endregion

        #region "Variaveis ViewState"
        private string Nome
        {
            get
            {
                if (ViewState["__Nome"] != null)
                {
                    return (string)ViewState["__Nome"];
                }
                return null;

            }
            set
            {
                ViewState["__Nome"] = value;
            }
        }

        private string Email
        {
            get
            {
                if (ViewState["__Email"] != null)
                {
                    return (string)ViewState["__Email"];
                }
                return null;

            }
            set
            {
                ViewState["__Email"] = value;
            }
        }

        private string Senha
        {
            get
            {
                if (ViewState["__Senha"] != null)
                {
                    return (string)ViewState["__Senha"];
                }
                return null;

            }
            set
            {
                ViewState["__Senha"] = value;
            }
        }

        public string CodSeguranca
        {
            get
            {
                if (ViewState["__CodSeguranca"] != null)
                {
                    return (string)ViewState["__CodSeguranca"];
                }
                return null;

            }
            set
            {
                ViewState["__CodSeguranca"] = value;
            }
        }

        #endregion

        #region "Metodos da classe"
        protected void Page_Load(object sender, EventArgs e)
        {
            Mensagem.buttonOk += Mensagem_buttonOk;
            if (!IsPostBack)
            {
                txtMatricula.Focus();
            }
        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Nome = txtMatricula.Text;

                BLL.BLL bll = new BLL.BLL();
                var result = bll.Login(txtMatricula.Text, txtSenha.Text);
                switch (result.Trim())
                {
                    case "USUARIO CADASTRADO":
                        Usuario = txtMatricula.Text;
                        Response.Redirect("~/Ui/Home.aspx");
                        break;
                    case "SENHA INVALIDA":
                        Mensagem.MensagemAlerta("SENHA INCORRETA");
                        TrocarSenha.Visible = true;
                        break;
                    default:
                        Mensagem.MensagemAlerta(result.Trim());
                        break;
                }
            }
            catch (Exception)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }

        protected void lkBtnCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/CadastroUsuario.aspx");
        }

        protected void lkBtnTrocarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = CodigoSeguranca();
                string num = numero.ToString();
                num = num.PadRight(8, '0');
                numero = Convert.ToInt32(num);

                BLL.BLL obj = new BLL.BLL();
                var result = obj.AlterarSenha(Nome, num);
                if (result.Trim() == "USUARIO NAO POSSUI CADASTRO")
                {
                    Mensagem.MensagemAlerta(Nome + " NÃO POSSUI CADASTRO!");
                    return;
                }

                EnviaEmail(numero, result.Trim());
                Mensagem.MensagemAlerta("SUA NOVA SENHA FOI ENVIADA PARA O EMAIL " + result.Trim());
            }
            catch (Exception)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }

        private int CodigoSeguranca()
        {
            int value = 0;
            Random numero = new Random();
            value = numero.Next(10, 1000);
            return value;
        }

        private void EnviaEmail(int numero, string email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(remetenteEmail, "Sustentabilidade", System.Text.Encoding.UTF8);
            mail.Subject = "CODIGO DE SEGURANÇA PARA O SITE AGUAS PLUVIAIS";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = numero.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail

            SmtpClient client = new SmtpClient();  //Adicionando as credenciais do seu e-mail e senha:
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(remetenteEmail, "sustenta1234");

            client.Port = 587; // Esta porta é a utilizada pelo Gmail para envio
            client.Host = "smtp.gmail.com"; //Definindo o provedor que irá disparar o e-mail
            client.EnableSsl = true; //Gmail trabalha com Server Secured Layer

            try
            {
                client.Send(mail);
                Mensagem.MensagemAlerta("Envio do E-mail com sucesso");
            }
            catch (Exception ex)
            {
                Mensagem.MensagemAlerta("Ocorreu um erro ao enviar:" + ex.Message.Trim());
            }
        }
        #endregion
    }
}