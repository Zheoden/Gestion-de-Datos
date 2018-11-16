using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Espectaculo
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fecha_venc { get; set; }
        public Rubro rubro { get; set; }
        public string estado { get; set; }
    }
}
