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
    public partial class Asistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefrescarEventos();
                RefrescarAsociados();
                gvAsistencia.DataSource = AsistenciaL.ObtenerAsistencia();
                gvAsistencia.DataBind();
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = false;
                MensajeUpdate.Visible = false;
                MensajeEstado.Visible = false;
            }
        }

        public void RefrescarEventos()
        {
            ddlEvento.DataSource = EventoL.ObtenerEventos() ;
            ddlEvento.DataValueField = "Codigo";
            ddlEvento.DataTextField = "Descripcion";
            ddlEvento.DataBind();
        }

        public void RefrescarAsociados()
        {
            ddlAsociado.DataSource = MiembroL.ObtenerMiembros();
            ddlAsociado.DataValueField = "Identificacion";
            ddlAsociado.DataTextField = "Nombre";
            ddlAsociado.DataBind();
        }

        protected void CogLinkButton_Click(object sender, EventArgs e)
        {
            ddlAsociado.DataSource = MiembroL.ObtenerMiembrosFiltro(txtCodigo.Text);
            ddlAsociado.DataValueField = "Identificacion";
            ddlAsociado.DataTextField = "Nombre";
            ddlAsociado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlAsociado.SelectedValue))
            {
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = true;
                MensajeUpdate.Visible = false;
                MensajeEstado.Visible = false;
                return;
            }

            if (string.IsNullOrEmpty(ddlEvento.SelectedValue))
            {
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = true;
                MensajeUpdate.Visible = false;
                MensajeEstado.Visible = false;
                return;
            }

            MiembroE miembro = MiembroL.ObtenerMiembro(ddlAsociado.SelectedValue);

            if (miembro.Estatus1 != "Activo" || miembro.Estado2 != "Confirmado")
            {
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = false;
                MensajeUpdate.Visible = false;
                MensajeEstado.Visible = true;
                return;
            }

            AsistenciaE asistenciaE = new AsistenciaE()
            {
                PK_Evento = ddlEvento.SelectedValue,
                PK_Asociado = ddlAsociado.SelectedValue,
                Fecha = DateTime.Now,
                Usuario_Registra = Session["Usuario"].ToString()
            };

            AsistenciaL asistenciaL = new AsistenciaL();

            asistenciaL.InsertarAsistencia(asistenciaE);
            txtCodigo.Text = string.Empty;
            MensajeSuccess.Visible = true;
            MensajeDanger.Visible = false;
            MensajeUpdate.Visible = false;
            MensajeEstado.Visible = false;
            gvAsistencia.DataSource = AsistenciaL.ObtenerAsistencia();
            gvAsistencia.DataBind();
        }
    }
}