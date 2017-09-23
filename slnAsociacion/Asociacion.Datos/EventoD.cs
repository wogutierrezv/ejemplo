using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class EventoD
    {
        public static List<EventoE> SeleccionarEventos()
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_EVENTOS]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                OdbcDataReader reader = command.ExecuteReader();

                List<EventoE> datos = new List<EventoE>();

                while (reader.Read())
                {
                    EventoE evento = new EventoE();

                    evento.Codigo = reader["PK_Codigo"].ToString();
                    evento.Descripcion = reader["Descripcion"].ToString();
                    evento.Fecha_Inicio = reader["Fecha_Inicio"].ToString();
                    evento.Fecha_Fin = reader["Fecha_Fin"].ToString();

                    datos.Add(evento);
                }
                return datos;
            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR AL OBTENER LA CONSULTA. DETALLE: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void InsertarEvento(EventoE evento)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_INSERTAR_EVENTO](?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_PK_Codigo", OdbcType.VarChar);
                command.Parameters["@P_PK_Codigo"].Value = evento.Codigo;

                command.Parameters.Add("@P_Descripcion", OdbcType.VarChar);
                command.Parameters["@P_Descripcion"].Value = evento.Descripcion;

                command.Parameters.Add("@P_Fecha_Inicio", OdbcType.VarChar);
                command.Parameters["@P_Fecha_Inicio"].Value = evento.Fecha_Inicio;

                command.Parameters.Add("@P_Fecha_Fin", OdbcType.VarChar);
                command.Parameters["@P_Fecha_Fin"].Value = evento.Fecha_Fin;

                command.ExecuteNonQuery();
            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
