using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Entidades
{
    public class UsuarioE
    {
        public String PK_Usuario { get; set; }
        public String Nombre { get; set; }
        public int FK_Perfil { get; set; }
        public string NombrePerfil { get; set; }
        public String Contrasenna { get; set; }
        public char Estado { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
    }
}
