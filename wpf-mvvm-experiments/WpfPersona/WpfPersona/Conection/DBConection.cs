using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPersona.Models;

namespace WpfPersona.Conection
{
    public class DBConection
    {
        private PersonaCollection _listaPersonas;

        public PersonaCollection ListarPersonas()
        {
            var lista = new PersonaCollection();
            lista.Add(new Persona(1, "Persona 1", DateTime.Now));
            lista.Add(new Persona(2, "Persona 2", DateTime.Now));
            lista.Add(new Persona(3, "Persona 3", DateTime.Now));
            lista.Add(new Persona(4, "Persona 4", DateTime.Now));
            lista.Add(new Persona(5, "Persona 5", DateTime.Now));
            return lista;
        }
    }
}
