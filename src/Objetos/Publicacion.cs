using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Publicacion
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Estado estado { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_evento { get; set; }
        public int codigo { get; set; }
        public Rubro rubro { get; set; }
        public Usuario user { get; set; }
        public Espectaculo espectaculo { get; set; }
        public Grado grado { get; set; }
        public int stock { get; set; }
        public int precio { get; set; }
    }
}
