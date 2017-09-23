using Asociacion.Datos;
using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Logica
{
    public class PerfilL
    {
        public static List<PerfilE> ObtenerPerfiles()
        {
            return PerfilD.SeleccionarPerfiles();
        }
    }
}
