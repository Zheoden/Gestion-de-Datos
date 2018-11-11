using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet
{
    public class Item_Factura
    {
        public int id { get; set; }
        public int monto { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public Factura factura { get; set; }
        public Ubicacion ubicacion { get; set; }
    }
}
