using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Factory
{
    public class Factory
    {
        public string ConexaoOracle()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["ProjetoSustentabilidade"];
            return connString.ToString();
        }
    }
}