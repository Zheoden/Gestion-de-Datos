using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Factura
    {
        public int id { get; set; }
        public int numero { get; set; }
        public DateTime fecha { get; set; }
        public int total { get; set; }
        public string pago_descripcion { get; set; }
        public Cliente cliente { get; set; }
        public Empresa empresa { get; set; }
    }
}
