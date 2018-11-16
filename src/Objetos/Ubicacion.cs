using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Ubicacion
    {
        public int id { get; set; }
        public string fila { get; set; }
        public int asiento { get; set; }
        public bool sin_numerar { get; set; }
        public int precio { get; set; }
        public int tipo_codigo { get; set; }
        public string tipo_descripcion { get; set; }
        public bool facturada { get; set; }
    }
}
