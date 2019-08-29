using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace TCC.DAL
{
    public class DAL
    {
        #region "Constante"
        const string stringConexao = "ProjetoSustentabilidade";

        const string cURL = "https://weather-ydn-yql.media.yahoo.com/forecastrss";
        const string cAppID = "Q5m3KH36";
        const string cConsumerKey = "dj0yJmk9SG1LV2xBVjVtdUd2JmQ9WVdrOVVUVnRNMHRJTXpZbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmc3Y9MCZ4PTcy";
        const string cConsumerSecret = "1a90fb5cf058497fb8efcd5873f6f4913cecab37";
        const string cOAuthVersion = "1.0";
        const string cOAuthSignMethod = "HMAC-SHA1";
        const string cUnitID = "u=c";           // Metric units
        const string cFormat = "json";

        const string SpLogin = "SP_LOGIN";
        const string SpCadastro = "SP_CADASTRO";
        const string SpTrocarSenha = "SP_TROCARSENHA";
        const string SpAtualizarUsuario = "SP_ATU_USUARIO";
        const string SpRetornarUsuario = "SP_RETORNAUSUARIO";

        const string ParamId = "pID";
        const string ParamNome = "pNOME";
        const string ParamSenha = "pSENHA";
        const string ParamUsuario = "pUSUARIO";
        const string ParamEmail = "pEMAIL";
        const string ParamSobrenome = "pSOBRENOME";
        const string ParamCidade = "pCIDADE";
        const string ParamEstado = "pESTADO";
        const string ParamPais = "pPAIS";
        const string ParamSexo = "pSEXO";
        const string ParamEstadoCivil = "pEST_CIVIL";
        const string ParamFoto = "pFOTO";
        const string ParamReturnChar = "pRETURN_CHAR";
        #endregion

        #region "Banco de Dados"
        public string LoginSistema(string Nome, string Senha)
        {
            Factory.Factory factory = new Factory.Factory();

            string connString = factory.ConexaoOracle();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connString.ToString();

            con.Open();
            OracleCommand cmd = new OracleCommand(SpLogin, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter(ParamNome, Nome));
            cmd.Parameters.Add(new OracleParameter(ParamSenha, Senha));
            var pRetorno = new OracleParameter(ParamReturnChar, OracleDbType.Char, ParameterDirection.Output);
            pRetorno.Size = 30;
            cmd.Parameters.Add(pRetorno);
            cmd.ExecuteNonQuery();
            con.Close();
            return pRetorno.Value.ToString();
        }

        public string CadastrarUsuario(string Matricula, string Senha, string Email)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings[stringConexao];


            OracleConnection con = new OracleConnection();
            con.ConnectionString = connString.ToString();

            con.Open();
            OracleCommand cmd = new OracleCommand(SpCadastro, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter(ParamUsuario, Matricula));
            cmd.Parameters.Add(new OracleParameter(ParamSenha, Senha));
            cmd.Parameters.Add(new OracleParameter(ParamEmail, Email));
            var pRetorno = new OracleParameter(ParamReturnChar, OracleDbType.Char, ParameterDirection.Output);
            pRetorno.Size = 30;
            cmd.Parameters.Add(pRetorno);
            cmd.ExecuteNonQuery();
            con.Close();
            return pRetorno.Value.ToString();
        }

        public void AtualizarUsuario(string Matricula, string Nome, string sobreNome, string cidade, string estado, string pais, string sexo, string estadoCivil)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings[stringConexao];

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connString.ToString();
            con.Open();
            OracleCommand cmd = new OracleCommand(SpAtualizarUsuario, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter(ParamId, Matricula));
            cmd.Parameters.Add(new OracleParameter(ParamNome, Nome));
            cmd.Parameters.Add(new OracleParameter(ParamSobrenome, sobreNome));
            cmd.Parameters.Add(new OracleParameter(ParamCidade, cidade));
            cmd.Parameters.Add(new OracleParameter(ParamEstado, estado));
            cmd.Parameters.Add(new OracleParameter(ParamPais, pais));
            cmd.Parameters.Add(new OracleParameter(ParamSexo, sexo));
            cmd.Parameters.Add(new OracleParameter(ParamEstadoCivil, estadoCivil));
            cmd.Parameters.Add(new OracleParameter(ParamFoto, ""));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string AlterarSenha(string Nome, string Senha)
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings[stringConexao];


            OracleConnection con = new OracleConnection();
            con.ConnectionString = connString.ToString();

            con.Open();
            OracleCommand cmd = new OracleCommand(SpTrocarSenha, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter(ParamUsuario, Nome));
            cmd.Parameters.Add(new OracleParameter(ParamSenha, Senha));
            var pRetorno = new OracleParameter(ParamReturnChar, OracleDbType.Char, ParameterDirection.Output);
            pRetorno.Size = 30;
            cmd.Parameters.Add(pRetorno);
            cmd.ExecuteNonQuery();
            con.Close();
            return pRetorno.Value.ToString();
        }

        public List<string> Detalhes(string Id)
        {
            try
            {
                List<string> obj = new List<string>();
                System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
                System.Configuration.ConnectionStringSettings connString;
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings[stringConexao];


                OracleConnection con = new OracleConnection();
                con.ConnectionString = connString.ToString();

                con.Open();
                OracleCommand cmd = new OracleCommand(SpRetornarUsuario, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter(ParamId, Id));
                cmd.Parameters.Add("pREFCURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            obj.Add(reader.IsDBNull(i) ? " " : reader.GetString(i));
                        }
                    }
                }
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region "API"
        protected static string _get_timestamp()
        {
            TimeSpan lTS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64(lTS.TotalSeconds).ToString();
        }

        protected static string _get_nonce()
        {
            return Convert.ToBase64String(
                                           new ASCIIEncoding().GetBytes(
                                                                         DateTime.Now.Ticks.ToString()
                                                                        )
                                         );
        }

        protected static string _get_auth(string cidade)
        {
            string lNonce = _get_nonce();
            string lTimes = _get_timestamp();
            string lCKey = string.Concat(cConsumerSecret, "&");
            string lSign = string.Format(
                                         "format={0}&" +
                                         "oauth_consumer_key={1}&" +
                                         "oauth_nonce={2}&" +
                                         "oauth_signature_method={3}&" +
                                         "oauth_timestamp={4}&" +
                                         "oauth_version={5}&" +
                                         "{6}&{7}",
                                         cFormat,
                                         cConsumerKey,
                                         lNonce,
                                         cOAuthSignMethod,
                                         lTimes,
                                         cOAuthVersion,
                                         cUnitID,
                                         cidade
                                        );

            lSign = string.Concat(
                                  "GET&",
                                  Uri.EscapeDataString(cURL),
                                  "&",
                                  Uri.EscapeDataString(lSign)
                                  );

            using (var lHasher = new HMACSHA1(Encoding.ASCII.GetBytes(lCKey)))
            {
                lSign = Convert.ToBase64String(
                 lHasher.ComputeHash(Encoding.ASCII.GetBytes(lSign))
                );
            }

            return "OAuth " +
                   "oauth_consumer_key=\"" + cConsumerKey + "\", " +
                   "oauth_nonce=\"" + lNonce + "\", " +
                   "oauth_timestamp=\"" + lTimes + "\", " +
                   "oauth_signature_method=\"" + cOAuthSignMethod + "\", " +
                   "oauth_signature=\"" + lSign + "\", " +
                   "oauth_version=\"" + cOAuthVersion + "\"";

        }

        public string ClimaTempo(string cidade)
        {
            cidade = "woeid=" + cidade;

            List<string> Dados = new List<string>();
            string lURL = cURL + "?" + cidade + "&" + cUnitID + "&format=" + cFormat;

            var lClt = new WebClient();

            lClt.Headers.Set("Content-Type", "application/" + cFormat);
            lClt.Headers.Add("X-Yahoo-App-Id", cAppID);
            lClt.Headers.Add("Authorization", _get_auth(cidade));

            byte[] lDataBuffer = lClt.DownloadData(lURL);
            string lOut = Encoding.ASCII.GetString(lDataBuffer);

            return lOut;
           
        }
        #endregion
    }
}