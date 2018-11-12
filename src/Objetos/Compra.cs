using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet
{
    public class Compra
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int cantidad { get; set; }
        public Cliente cliente { get; set; }
    }
}
