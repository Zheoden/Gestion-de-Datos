using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Grado
    {
        public int id { get; set; }
        public string prioridad { get; set; }
        public int comision { get; set; }
        public bool habilitado { get; set; }
    }
}
