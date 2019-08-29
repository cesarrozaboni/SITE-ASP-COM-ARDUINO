using System;
using System.Net.Mail;

namespace TCC.Login
{
    public partial class cadastroUsuario : ConstSession
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

        #region "Metodos da Classe"
        protected void Page_Load(object sender, EventArgs e)
        {
            Mensagem.buttonOk += Mensagem_buttonOk;
        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ConfirmarCodigo.Visible)
                {
                    /*VIEW STATE*/
                    Nome = txtCdMatricula.Text;
                    Senha = txtCdSenha.Text;
                    Email = txtCdEmail.Text;

                    BLL.BLL obj = new BLL.BLL();
                    var result = obj.CadastrarUsuario(Nome, null, Email);

                    if (!string.IsNullOrEmpty(result.Trim()))
                    {
                        if (result.Trim() == "USUARIO JA POSSUI CADASTRO")
                        {
                            Mensagem.MensagemAlerta(result.Trim());
                            return;
                        }
                        else if (result.Trim() == "EMAIL JÁ POSSUI CADASTRO")
                        {
                            Mensagem.MensagemAlerta(result.Trim());
                            return;
                        }
                    }
                    int numero = CodigoSeguranca();
                    CodSeguranca = numero.ToString();

                    /*Envia email com codigo de segurança*/
                    EnviaEmail(numero, Email);

                    ConfirmarCodigo.Visible = true;
                    btnCadastrar.Text = "CADASTRAR";
                    txtCdMatricula.Enabled = false;
                    txtCdEmail.Enabled = false;
                    txtCdSenha.Enabled = false;
                    txtConfirmaSenha.Enabled = false;
                    btnCadastrar.CausesValidation = false;
                }
                else
                {
                    if (!(CodSeguranca == txtCodigo.Text))
                    {
                        Mensagem.MensagemAlerta("Codigo Invalido!");
                        return;
                    }

                    BLL.BLL obj = new BLL.BLL();
                    obj.CadastrarUsuario(Nome, Senha, Email);
                    Mensagem.MensagemAlerta("USUARIO CADASTRADO COM SUCESSO!");
                    Usuario = Nome;
                    Response.Redirect("~/Ui/Home.aspx");

                }
            }
            catch (Exception ex)
            {
                Mensagem.MensagemAlerta("Erro Ao executar Operação");
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

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/Login.aspx");
        }
        #endregion
    }
}