using System;
using Newtonsoft.Json;

namespace TCC.Ui.Login.Temperatura
{
    public partial class Temperatura : ConstSession
    {
        #region "Metodos da classe"
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaUsuario();
            Mensagem.buttonOk += Mensagem_buttonOk;
        }

        private void Mensagem_buttonOk(object source, EventArgs e)
        {
            Mensagem.FecharMensagemAlerta();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL bll = new BLL.BLL();
                var result = bll.ClimaTempo(ddlCidade.SelectedItem.Value);
                dynamic Clima = JsonConvert.DeserializeObject(result);

                foreach (var i in Clima)
                {
                    pnlDetalhes.Visible = true;
                    CidadeValue.Text = i.First.city;
                    regiaoValue.Text = i.Parent.location.region;
                    paisValue.Text = i.First.country;
                    velocValue.Text = string.Format("{0} KM/h", i.Parent.current_observation.wind.speed);
                    UmidadeValue.Text = string.Format("{0}%", i.Parent.current_observation.atmosphere.humidity);
                    nascenteValue.Text = i.Parent.current_observation.astronomy.sunrise;
                    poenteValue.Text = i.Parent.current_observation.astronomy.sunset;
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
        #endregion
    }
}