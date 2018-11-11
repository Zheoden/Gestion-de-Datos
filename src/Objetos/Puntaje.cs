using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet
{
    public class Puntaje
    {
        public int id { get; set; }
        public Cliente cliente { get; set; }
        public DateTime vencimiento { get; set; }
        public int cantidad { get; set; }
    }
}
