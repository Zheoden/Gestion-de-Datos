using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Estado
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public bool estado_inicial { get; set; }
        public bool estado_final { get; set; }
    }
}
