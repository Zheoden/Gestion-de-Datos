using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Tarjeta
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string cod_seguridad { get; set; }
        public DateTime vencimiento { get; set; }
        public string titular { get; set; }
        public string tipo { get; set; }
    }
}
