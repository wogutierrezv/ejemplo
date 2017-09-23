using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class AsistenciaD
    {
        public static void InsertarAsistencia(AsistenciaE asistencia)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_INSERTAR_ASISTENCIA](?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_PK_Evento", OdbcType.VarChar);
                command.Parameters["@P_PK_Evento"].Value = asistencia.PK_Evento;

                command.Parameters.Add("@P_PK_Asociado", OdbcType.VarChar);
                command.Parameters["@P_PK_Asociado"].Value = asistencia.PK_Asociado;

                command.Parameters.Add("@P_Fecha", OdbcType.DateTime);
                command.Parameters["@P_Fecha"].Value = asistencia.Fecha;

                command.Parameters.Add("@P_Usuario_Registra", OdbcType.VarChar);
                command.Parameters["@P_Usuario_Registra"].Value = asistencia.Usuario_Registra;

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

        public static List<AsistenciaE> SeleccionarAsistencia()
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_ASISTENCIA]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                OdbcDataReader reader = command.ExecuteReader();

                List<AsistenciaE> datos = new List<AsistenciaE>();

                while (reader.Read())
                {
                    AsistenciaE evento = new AsistenciaE();

                    evento.PK_Evento = reader["Descripcion"].ToString();
                    evento.PK_Asociado = reader["Nombre"].ToString();
                    evento.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                    evento.Usuario_Registra = reader["Usuario_Registra"].ToString();

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
    }
}
