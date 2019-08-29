using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC
{
    public class ConstSession : System.Web.UI.Page
    {
        public static string Usuario
        {
            get
            {
                if (HttpContext.Current.Session["__Usuario"] != null)
                {
                    return (string)HttpContext.Current.Session["__Usuario"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["__Usuario"] = value;
            }
        }

        public void Redirecionar(string url)
        {
            Response.Redirect(url);
        }

        protected void ValidaUsuario()
        {
            if (string.IsNullOrEmpty(ConstSession.Usuario))
            {
                Response.Redirect("~/Login/Login");
            }
        }

        protected string FormatarData(string data)
        {
            var dataFormatada = data.Substring(6, 2);
            dataFormatada += "/";
            dataFormatada += data.Substring(4, 2);
            dataFormatada += "/";
            dataFormatada += data.Substring(0, 4);
            return dataFormatada;
        }
    }
}