using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class PerfilD
    {
        public static List<PerfilE> SeleccionarPerfiles()
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_PERFILES]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                OdbcDataReader reader = command.ExecuteReader();

                List<PerfilE> datos = new List<PerfilE>();

                while (reader.Read())
                {
                    PerfilE perfil = new PerfilE();

                    perfil.Codigo = int.Parse(reader["PK_Codigo"].ToString());
                    perfil.Descripcion = reader["Descripcion"].ToString();
                    perfil.Estado = char.Parse(reader["Estado"].ToString());

                    datos.Add(perfil);
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
