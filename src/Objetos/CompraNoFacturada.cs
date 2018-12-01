using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class CompraNoFacturada
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string documento { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int ubica_id { get; set; }
    }
}
