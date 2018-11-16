using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Direccion
    {
        public int id { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string depto { get; set; }
        public string localidad { get; set; }
        public string codigo_postal { get; set; }
    }
}
