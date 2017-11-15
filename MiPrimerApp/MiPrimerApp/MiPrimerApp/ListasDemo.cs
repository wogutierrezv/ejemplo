using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimerApp
{
    public class ListasDemo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaElementos
    {
        public List<ListasDemo> _elementos { get; set; }
        public ListaElementos()
        {
            _elementos = new List<ListasDemo>();
            LoadElements();
        }

        public void LoadElements()
        {
            _elementos.Add(new ListasDemo()
            {
                Nombre = "Elemento 1",
                Descripcion = "Descripción al azar"
            });

            _elementos.Add(new ListasDemo()
            {
                Nombre = "Elemento 2",
                Descripcion = "Descripción al azar 2"
            });
        }
    }
}
