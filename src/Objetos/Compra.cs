using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Compra
    {
        public int stock { get; set; }
        public int precio { get; set; }
        public string rubro { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_evento { get; set; }
        public DateTime fecha_publicacion { get; set; }
    }
}
