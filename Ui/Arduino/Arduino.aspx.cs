using System;
using System.IO.Ports;
using Newtonsoft.Json;

namespace TCC.Ui.Arduino
{
    public partial class Arduino : ConstSession
    {
        SerialPort porta1 = new SerialPort();

        protected void Page_Load(object sender, EventArgs e)
        {
            Mensagem.buttonOk += Mensagem_buttonOk;
            if (!IsPostBack)
            {
                ValidaUsuario();
                BucarTemperatura();
            }

        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }

        protected void btnLigaLed_Click(object sender, EventArgs e)
        {
            try
            {
                porta1.PortName = "COM3";
                porta1.BaudRate = 9600;
                porta1.Open();

                if (porta1.IsOpen)
                {
                    porta1.WriteLine("1");
                    Mensagem.MensagemAlerta("Cobertura Aberta Com Sucesso!");
                }
                porta1.Close();
            }
            catch (Exception)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }

        protected void btnDesligaLed_Click(object sender, EventArgs e)
        {
            try
            {
                porta1.PortName = "COM3";
                porta1.BaudRate = 9600;
                porta1.Open();
                if (porta1.IsOpen)
                {
                    porta1.WriteLine("2");
                    Mensagem.MensagemAlerta("Cobertura Fechada Com Sucesso!");
                }
                porta1.Close();
            }
            catch (Exception)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }

        protected void btnAtualizarTemperatura_Click(object sender, EventArgs e)
        {
            BucarTemperatura();
        }

        protected void BucarTemperatura()
        {
            try
            {
                BLL.BLL bll = new BLL.BLL();
                var result = bll.ClimaTempo("455845");
                dynamic Clima = JsonConvert.DeserializeObject(result);

                foreach (var i in Clima)
                {
                    pnlDetalhes.Visible = true;
                    CidadeValue.Text = i.First.city;
                    regiaoValue.Text = i.Parent.location.region;
                    paisValue.Text = i.First.country;
                    velocValue.Text = string.Format("{0} KM/h", i.Parent.current_observation.wind.speed);
                    UmidadeValue.Text = string.Format("{0}%", i.Parent.current_observation.atmosphere.humidity);
                    condicaoValue.Text = i.Parent.current_observation.condition.text;
                    temperaturaValue.Text = string.Format("{0} ºC", i.Parent.current_observation.condition.temperature);
                    break;
                }
            }
            catch (Exception)
            {
                Mensagem.MensagemAlerta("Erro Ao Executar Operação");
            }
        }
    }
}
