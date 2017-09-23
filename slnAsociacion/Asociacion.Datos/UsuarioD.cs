using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class UsuarioD
    {
        public static UsuarioE ObtenerUsuario(string usuario, string contrasenna)
        {

            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_USUARIO_POR_CODIGO_CONTRASENNA](?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@P_Usuario", OdbcType.VarChar);
                command.Parameters["@P_Usuario"].Value = usuario;

                command.Parameters.Add("@P_Contrasenna", OdbcType.VarChar);
                command.Parameters["@P_Contrasenna"].Value = contrasenna;

                OdbcDataReader reader = command.ExecuteReader();
                UsuarioE usuarioE = null;

                while (reader.Read())
                {
                    usuarioE = new UsuarioE();

                    usuarioE.PK_Usuario = reader["PK_Usuario"].ToString();
                    usuarioE.Nombre = reader["Nombre"].ToString();
                    usuarioE.FK_Perfil = int.Parse(reader["FK_Perfil"].ToString());
                }

                return usuarioE;
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

        public static List<UsuarioE> SeleccionarUsuarios()
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_SELECCIONAR_USUARIO]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                OdbcDataReader reader = command.ExecuteReader();

                List<UsuarioE> datos = new List<UsuarioE>();

                while (reader.Read())
                {
                    UsuarioE usuario = new UsuarioE();

                    usuario.PK_Usuario = reader["PK_Usuario"].ToString();
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.FK_Perfil = int.Parse(reader["FK_Perfil"].ToString());
                    usuario.NombrePerfil = reader["Nombre_Perfil"].ToString();
                    usuario.Estado = char.Parse(reader["Estado"].ToString());

                    datos.Add(usuario);
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

        public static void InsertarUsuario(UsuarioE usuario)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_INSERTAR_USUARIO](?,?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_PK_Usuario", OdbcType.VarChar);
                command.Parameters["@P_PK_Usuario"].Value = usuario.PK_Usuario;

                command.Parameters.Add("@P_Nombre", OdbcType.VarChar);
                command.Parameters["@P_Nombre"].Value = usuario.Nombre;

                command.Parameters.Add("@P_FK_Perfil", OdbcType.Int);
                command.Parameters["@P_FK_Perfil"].Value = usuario.FK_Perfil;

                command.Parameters.Add("@P_Contrasenna", OdbcType.VarChar);
                command.Parameters["@P_Contrasenna"].Value = usuario.Contrasenna;

                command.Parameters.Add("@P_Estado", OdbcType.Char);
                command.Parameters["@P_Estado"].Value = usuario.Estado;

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

        public static void ModificarUsuario(UsuarioE usuario)
        {
            OdbcConnection conn = new OdbcConnection(Conexion.Cadena);

            try
            {
                conn.Open();

                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[PA_MODIFICAR_USUARIO](?,?,?,?,?) }";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;
                command.Parameters.Add("@P_PK_Usuario", OdbcType.VarChar);
                command.Parameters["@P_PK_Usuario"].Value = usuario.PK_Usuario;

                command.Parameters.Add("@P_Nombre", OdbcType.VarChar);
                command.Parameters["@P_Nombre"].Value = usuario.Nombre;

                command.Parameters.Add("@P_FK_Perfil", OdbcType.Int);
                command.Parameters["@P_FK_Perfil"].Value = usuario.FK_Perfil;

                command.Parameters.Add("@P_Fecha_Modificacion", OdbcType.DateTime);
                command.Parameters["@P_Fecha_Modificacion"].Value = usuario.Fecha_Modificacion;

                command.Parameters.Add("@P_Estado", OdbcType.Char);
                command.Parameters["@P_Estado"].Value = usuario.Estado;

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
