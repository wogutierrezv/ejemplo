using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asociacion.Entidades
{
    public class AsistenciaE
    {
        public string PK_Evento { get; set; }
        public string PK_Asociado { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario_Registra { get; set; }
    }
}
