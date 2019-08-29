using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TCC
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidaUsuario();
        }

        protected void ValidaUsuario()
        {
            if (string.IsNullOrEmpty(ConstSession.Usuario))
            {
                Response.Redirect("~/Login/Login");
            }
        }

        protected void imgFoto_Click(object sender, EventArgs e)
        {
            
        }
    }
}