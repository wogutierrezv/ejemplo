using Asociacion.Datos;
using Asociacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Logica
{
    public class EventoL
    {
        public void InsertarEvento(EventoE evento)
        {
            EventoD.InsertarEvento(evento);
        }

        public static List<EventoE> ObtenerEventos()
        {
            return EventoD.SeleccionarEventos();
        }
    }
}
