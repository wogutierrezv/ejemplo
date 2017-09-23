using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class MiembroD
    {
        public static void InsertarAsociado(MiembroE miembro)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_INSERTAR_MIEMBRO](?,?,?,?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_Id", OdbcType.VarChar);
                command.Parameters["@P_Id"].Value = miembro.Id;

                command.Parameters.Add("@P_Nombre", OdbcType.VarChar);
                command.Parameters["@P_Nombre"].Value = miembro.Nombre;

                command.Parameters.Add("@P_Identificacion", OdbcType.VarChar);
                command.Parameters["@P_Identificacion"].Value = miembro.Identificacion;

                command.Parameters.Add("@P_Estatus1", OdbcType.VarChar);
                command.Parameters["@P_Estatus1"].Value = miembro.Estatus1;

                command.Parameters.Add("@P_Estado2", OdbcType.VarChar);
                command.Parameters["@P_Estado2"].Value = miembro.Estado2;

                command.Parameters.Add("@P_Correo", OdbcType.VarChar);
                command.Parameters["@P_Correo"].Value = miembro.Correo;

                command.Parameters.Add("@P_Telefono", OdbcType.VarChar);
                command.Parameters["@P_Telefono"].Value = miembro.Telefono;

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

        public static int ValidarAsociado(string codigo)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_VALIDAR_CODIGO_MIEMBRO](?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_Codigo", OdbcType.VarChar);
                command.Parameters["@P_Codigo"].Value = codigo;

                command.Parameters.Add("@P_Bandera", OdbcType.Int);
                command.Parameters["@P_Bandera"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                int bandera = Convert.ToInt32(command.Parameters["@P_Bandera"].Value.ToString());

                return bandera;
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

        public static List<MiembroE> SeleccionarMiembros()
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_MIEMBROS]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                OdbcDataReader reader = command.ExecuteReader();

                List<MiembroE> datos = new List<MiembroE>();

                while (reader.Read())
                {
                    MiembroE miembro = new MiembroE();

                    miembro.Id = reader["Id"].ToString();
                    miembro.Nombre = reader["Nombre"].ToString();
                    miembro.Identificacion = reader["Identificacion"].ToString();
                    miembro.Estatus1 = reader["Estatus1"].ToString();
                    miembro.Estado2 = reader["Estado2"].ToString();
                    miembro.Correo = reader["Correo"].ToString();
                    miembro.Telefono = reader["Telefono"].ToString();

                    datos.Add(miembro);
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

        public static List<MiembroE> SeleccionarMiembrosPorCodigo(string identificacion)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_ASOCIADO_POR CODIGO](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@P_Identificacion", OdbcType.VarChar);
                command.Parameters["@P_Identificacion"].Value = identificacion;
                OdbcDataReader reader = command.ExecuteReader();

                List<MiembroE> datos = new List<MiembroE>();

                while (reader.Read())
                {
                    MiembroE miembro = new MiembroE();

                    miembro.Id = reader["Id"].ToString();
                    miembro.Nombre = reader["Nombre"].ToString();
                    miembro.Identificacion = reader["Identificacion"].ToString();
                    miembro.Estatus1 = reader["Estatus1"].ToString();
                    miembro.Estado2 = reader["Estado2"].ToString();
                    miembro.Correo = reader["Correo"].ToString();
                    miembro.Telefono = reader["Telefono"].ToString();

                    datos.Add(miembro);
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

        public static MiembroE SeleccionarMiembro(string identificacion)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_ASOCIADO_POR CODIGO](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@P_Identificacion", OdbcType.VarChar);
                command.Parameters["@P_Identificacion"].Value = identificacion;
                OdbcDataReader reader = command.ExecuteReader();

                MiembroE miembro = null;

                while (reader.Read())
                {
                    miembro = new MiembroE();

                    miembro.Id = reader["Id"].ToString();
                    miembro.Nombre = reader["Nombre"].ToString();
                    miembro.Identificacion = reader["Identificacion"].ToString();
                    miembro.Estatus1 = reader["Estatus1"].ToString();
                    miembro.Estado2 = reader["Estado2"].ToString();
                    miembro.Correo = reader["Correo"].ToString();
                    miembro.Telefono = reader["Telefono"].ToString();

                }
                return miembro;
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

        public static void ModificarMiembro(MiembroE miembro)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_MODIFICAR_MIEMBRO](?,?,?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_Nombre", OdbcType.VarChar);
                command.Parameters["@P_Nombre"].Value = miembro.Nombre;

                command.Parameters.Add("@P_Identificacion", OdbcType.VarChar);
                command.Parameters["@P_Identificacion"].Value = miembro.Identificacion;

                command.Parameters.Add("@P_Estatus1", OdbcType.VarChar);
                command.Parameters["@P_Estatus1"].Value = miembro.Estatus1;

                command.Parameters.Add("@P_Estado2", OdbcType.VarChar);
                command.Parameters["@P_Estado2"].Value = miembro.Estado2;

                command.Parameters.Add("@P_Correo", OdbcType.VarChar);
                command.Parameters["@P_Correo"].Value = miembro.Correo;

                command.Parameters.Add("@P_Telefono", OdbcType.VarChar);
                command.Parameters["@P_Telefono"].Value = miembro.Telefono;

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
