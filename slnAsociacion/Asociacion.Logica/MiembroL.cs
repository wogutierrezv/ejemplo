using Asociacion.Datos;
using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Logica
{
    public class MiembroL
    {
        public void InsertarAsociado(MiembroE miembro)
        {
            MiembroD.InsertarAsociado(miembro);
        }

        public static List<MiembroE> ObtenerMiembros()
        {
            return MiembroD.SeleccionarMiembros();
        }

        public void ModificarMiembro(MiembroE miembro)
        {
            MiembroD.ModificarMiembro(miembro);
        }

        public static int ValidarAsociado(string codigo)
        {
            return MiembroD.ValidarAsociado(codigo);
        }

        public static List<MiembroE> ObtenerMiembrosFiltro(string identificacion)
        {
            return MiembroD.SeleccionarMiembrosPorCodigo(identificacion);
        }

        public static MiembroE ObtenerMiembro(string identificacion)
        {
            return MiembroD.SeleccionarMiembro(identificacion);
        }
    }
}
