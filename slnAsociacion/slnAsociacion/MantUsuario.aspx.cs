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
    public partial class MantUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefrescarPerfiles();
                RefrescarUsuarios();
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = false;
                MensajeUpdate.Visible = false;
            }
        }

        public void validarCampos()
        {
            string mensaje = "Los siguientes campos estan vacios: ";

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                mensaje += "Código\n";
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                mensaje += "Nombre\n";
            }
            if (string.IsNullOrEmpty(txtContrasenna.Text))
            {
                mensaje += "Contraseña\n";
            }
        }
        public void RefrescarUsuarios()
        {
            gvUsuarios.DataSource = UsuarioL.ObtenerUsuarios();
            gvUsuarios.DataBind();
        }

        public void RefrescarPerfiles()
        {
            ddlPerfil.DataSource = PerfilL.ObtenerPerfiles();
            ddlPerfil.DataValueField = "Codigo";
            ddlPerfil.DataTextField = "Descripcion";
            ddlPerfil.DataBind();
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = false;
            MensajeUpdate.Visible = false;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = false;
            txtContrasenna.Enabled = false;
            txtCodigo.Text = gvUsuarios.SelectedRow.Cells[0].Text.ToString();
            txtNombre.Text = gvUsuarios.SelectedRow.Cells[1].Text.ToString();
            //ddlPerfil.SelectedValue = gvUsuarios.SelectedRow.Cells[4].Text.ToString();

            if (gvUsuarios.SelectedRow.Cells[3].Text.ToString() == "A")
            {
                A.Checked = true;
                I.Checked = false;
            }
            else
            {
                I.Checked = true;
                A.Checked = false;
            }
        }

        public void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            ddlPerfil.SelectedIndex = 0;
            txtContrasenna.Text = string.Empty;
            A.Checked = false;
            I.Checked = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtContrasenna.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            LimpiarCampos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }


            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (string.IsNullOrEmpty(txtContrasenna.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!A.Checked && !I.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            UsuarioE usuarioE = new UsuarioE()
            {
                PK_Usuario = txtCodigo.Text,
                Nombre = txtNombre.Text,
                FK_Perfil = Convert.ToInt32(ddlPerfil.SelectedValue.ToString()),
                Contrasenna = txtContrasenna.Text,
                Estado = (A.Checked) ? 'A' : 'I'
            };

            UsuarioL usuarioL = new UsuarioL();

            usuarioL.InsertarUsuario(usuarioE);
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = true;
            MensajeUpdate.Visible = false;
            RefrescarUsuarios();
            LimpiarCampos();
        }

   
        protected void btnModificar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }


            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!A.Checked && !I.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            UsuarioE usuarioE = new UsuarioE()
            {
                PK_Usuario = txtCodigo.Text,
                Nombre = txtNombre.Text,
                FK_Perfil = Convert.ToInt32(ddlPerfil.SelectedValue.ToString()),
                Fecha_Modificacion = DateTime.Now,
                Estado = (A.Checked) ? 'A' : 'I'
            };

            UsuarioL usuarioL = new UsuarioL();

            usuarioL.ModificarUsuario(usuarioE);
            RefrescarUsuarios();
            LimpiarCampos();
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = false;
            MensajeUpdate.Visible = true;

        }
    }
}