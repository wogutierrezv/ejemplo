using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Asociacion.Datos
{
    public class Conexion
    {
        public static string Cadena
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["odbcAsociacion"].ConnectionString;
            }
        }
    }
}
