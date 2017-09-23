using Asociacion.Datos;
using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Logica
{
    public class AsistenciaL
    {
        public void InsertarAsistencia(AsistenciaE asistencia)
        {
            AsistenciaD.InsertarAsistencia(asistencia);
        }

        public static List<AsistenciaE> ObtenerAsistencia()
        {
            return AsistenciaD.SeleccionarAsistencia();
        }
    }
}
