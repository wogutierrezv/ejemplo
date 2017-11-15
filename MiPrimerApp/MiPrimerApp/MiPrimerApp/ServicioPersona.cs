using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimerApp
{
    public class ServicioPersona
    {
        public List<Persona> ConsultarPersona()
        {
            var lista = new List<Persona>();
            lista.Add(new Persona() { foto = "http://static.mercadoshops.com/piloto-para-lluvia-hombre-arana-spiderman-orig-mundo-manias_iZ154830141XvZxXpZ3XfZ148114094-612938980-3.jpgXsZ148114094xIM.jpg", nombre = "Hombre Araña" });
            lista.Add(new Persona() { foto = "https://lumiere-a.akamaihd.net/v1/images/open-uri20150422-20810-4v8pyz_5da72a2e.png?region=0,0,600,600", nombre = "Hulk" });

            return lista;
        }
    }
}
