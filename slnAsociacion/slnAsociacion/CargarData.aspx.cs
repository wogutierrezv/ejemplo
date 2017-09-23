using Asociacion.Entidades;
using Asociacion.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace slnAsociacion
{
    public partial class CargarData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RefrescarAsociados();
                MensajeSuccess.Visible = false;
                MensajeDanger.Visible = false;
                MensajeUpdate.Visible = false;
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            //string ruta = "C:\\Users\\wogut\\Documents\\Visual Studio 2013\\Projects\\slnAsociacion\\slnAsociacion\\ExcelFile\\Padron Asociados.xlsx";

            string ruta = Server.MapPath("~/") + "Asociados.xlsx";


            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=Excel 12.0;");
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From Asociados", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                MiembroL miembroL = new MiembroL();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    MiembroE miembro = new MiembroE();

                    miembro.Id = row["Id"].ToString();
                    miembro.Identificacion = row["Número Cédula"].ToString();
                    miembro.Nombre = row["Nombre"].ToString().Trim();
                    miembro.Estatus1 = row["Estatus 1"].ToString();
                    miembro.Estado2 = row["Est2"].ToString();
                    miembro.Correo = row["Correo"].ToString();
                    miembro.Telefono = row["Telefono"].ToString();

                    if (MiembroL.ValidarAsociado(miembro.Identificacion) == 1)
                    {
                        miembroL.ModificarMiembro(miembro);
                    }
                    else
                    {
                        miembroL.InsertarAsociado(miembro);
                    }
                }
            }
        }

        protected bool ValidarExtension(string ext)
        {
            switch (ext)
            {
                case ".xls":
                case ".xlsx":
                    return true;
            }
            return false;
        }

        public void validarCampos()
        {
            string mensaje = "Los siguientes campos estan vacios: ";

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                mensaje += "Código\n";
            }
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                mensaje += "Correo\n";
            }
            if (string.IsNullOrEmpty(txtIndentificacion.Text))
            {
                mensaje += "Identificación\n";
            }
        }

        public void RefrescarAsociados()
        {
            gvAsociados.DataSource = MiembroL.ObtenerMiembros();
            gvAsociados.DataBind();
        }

        public void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtIndentificacion.Text = string.Empty;
            EstatusA.Checked = false;
            EstatusI.Checked = false;
            Estado2A.Checked = false;
            Estado2I.Checked = false;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            txtCodigo.Enabled = true;
            txtIndentificacion.Enabled = true;
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


            if (string.IsNullOrEmpty(txtIndentificacion.Text))
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

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }


            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!EstatusA.Checked && !EstatusI.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!Estado2A.Checked && !Estado2I.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }


            MiembroE miembro = new MiembroE()
            {
                Id = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Identificacion = txtIndentificacion.Text,
                Estatus1 = (EstatusA.Checked) ? "Activo" : "Inacrivo",
                Estado2 = (Estado2A.Checked) ? "Confirmado" : "No",
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };

            MiembroL miembroL = new MiembroL();

            miembroL.InsertarAsociado(miembro);
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = true;
            MensajeUpdate.Visible = false;
            RefrescarAsociados();
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


            if (string.IsNullOrEmpty(txtIndentificacion.Text))
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

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }


            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!EstatusA.Checked && !EstatusI.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            if (!Estado2A.Checked && !Estado2I.Checked)
            {
                MensajeDanger.Visible = true;
                MensajeSuccess.Visible = false;
                MensajeUpdate.Visible = false;
                return;
            }

            MiembroE miembro = new MiembroE()
            {
                Nombre = txtNombre.Text,
                Identificacion = txtIndentificacion.Text,
                Estatus1 = (EstatusA.Checked) ? "Activo" : "Inactivo",
                Estado2 = (Estado2A.Checked) ? "Confirmado" : "No",
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text
            };

            MiembroL miembroL = new MiembroL();

            miembroL.ModificarMiembro(miembro);
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = false;
            MensajeUpdate.Visible = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            RefrescarAsociados();
            LimpiarCampos();
        }

        protected void gvAsociados_SelectedIndexChanged(object sender, EventArgs e)
        {
            MensajeDanger.Visible = false;
            MensajeSuccess.Visible = false;
            MensajeUpdate.Visible = false;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = false;
            txtIndentificacion.Enabled = false;
            txtCodigo.Text = gvAsociados.SelectedRow.Cells[0].Text.ToString();
            txtNombre.Text = gvAsociados.SelectedRow.Cells[1].Text.ToString();
            txtIndentificacion.Text = gvAsociados.SelectedRow.Cells[2].Text.ToString();
            txtCorreo.Text = gvAsociados.SelectedRow.Cells[5].Text.ToString();
            txtTelefono.Text = gvAsociados.SelectedRow.Cells[6].Text.ToString();

            if (gvAsociados.SelectedRow.Cells[3].Text.ToString() == "Activo")
            {
                EstatusA.Checked = true;
                EstatusI.Checked = false;
            }
            else
            {
                EstatusI.Checked = true;
                EstatusA.Checked = false;
            }

            if (gvAsociados.SelectedRow.Cells[4].Text.ToString() == "Confirmado")
            {
                Estado2A.Checked = true;
                Estado2I.Checked = false;
            }
            else
            {
                Estado2I.Checked = true;
                Estado2A.Checked = false;
            }
        }

        protected void btnNuevo_Click1(object sender, EventArgs e)
        {

        }

        protected void gvAsociados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAsociados.PageIndex = e.NewPageIndex;
            RefrescarAsociados();
        }
    }
}