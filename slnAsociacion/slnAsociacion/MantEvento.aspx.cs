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
    public partial class MantEvento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefrescarEventos();
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = false;
                MensajeUpdate.Visible = false;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            RefrescarEventos();
        }

        public void RefrescarEventos()
        {
            gvEventos.DataSource = EventoL.ObtenerEventos();
            gvEventos.DataBind();
        }

        public void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MensajeDanger.Visible = true;
                    MensajeSuccess.Visible = false;
                    return;
                }

                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MensajeDanger.Visible = true;
                    MensajeSuccess.Visible = false;
                    return;
                }

                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    MensajeDanger.Visible = true;
                    MensajeSuccess.Visible = false;
                    return;
                }

                if (string.IsNullOrEmpty(txtFechaInicio.Text))
                {
                    MensajeDanger.Visible = true;
                    MensajeSuccess.Visible = false;
                    return;
                }

                if (string.IsNullOrEmpty(txtFechaFin.Text))
                {
                    MensajeDanger.Visible = true;
                    MensajeSuccess.Visible = false;
                    return;
                }

                string FechaIncio = txtFechaInicio.Text + " " + ddlHoraInicio.Text + ":" + ddlMinutosInicio.Text + ":" + "00" + " " + ddlFormatoInicio.Text;
                string FechaFin = txtFechaFin.Text + " " + ddlHoraFin.Text + ":" + ddlMinutosFin.Text + ":" + "00" + " " + ddlFormatoFin.Text;

                EventoE evento = new EventoE()
                {
                    Codigo = txtCodigo.Text,
                    Descripcion = txtNombre.Text,
                    Fecha_Inicio = FechaIncio,
                    Fecha_Fin = FechaFin
                };

                EventoL eventoL = new EventoL();

                eventoL.InsertarEvento(evento);
                RefrescarEventos();
                LimpiarCampos();
                MensajeDanger.Visible = false;
                MensajeSuccess.Visible = true;
            }
            catch (Exception)
            {

            }

        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            MensajeDanger.Visible = false;
        }
    }
}