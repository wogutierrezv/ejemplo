using Asociacion.Datos;
using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Logica
{
    public class UsuarioL
    {
        public static UsuarioE ObtenerUsuario(string usuario, string contrasenna)
        {
            return UsuarioD.ObtenerUsuario(usuario, contrasenna);
        }

        public static List<UsuarioE> ObtenerUsuarios()
        {
            return UsuarioD.SeleccionarUsuarios();
        }

        public void InsertarUsuario(UsuarioE usuario)
        {
            UsuarioD.InsertarUsuario(usuario);
        }

        public void ModificarUsuario(UsuarioE usuario)
        {
            UsuarioD.ModificarUsuario(usuario);
        }
    }
}
