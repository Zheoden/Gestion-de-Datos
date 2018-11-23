using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Ubicacion_Publicacion
    {
        public Ubicacion ubicacion { get; set; }
        public Publicacion publicacion { get; set; }
        public bool disponible { get; set; }
    }
}
