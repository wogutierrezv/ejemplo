using Asociacion.Entidades;
using Asociacion.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnAsociacion
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
             UsuarioE usuarioE = UsuarioL.ObtenerUsuario(txtUsuario.Text, txtContrasenna.Text);

              if (usuarioE != null)
              {
                  Session["Usuario"] = usuarioE.PK_Usuario;
                  Session["Perfil"] = usuarioE.FK_Perfil;
                  Response.Redirect("Inicio.aspx");
              }
              else
              {
                  lbl_mensaje.Visible = true;
              }
        }
    }
}