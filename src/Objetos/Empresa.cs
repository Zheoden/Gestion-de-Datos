﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Empresa
    {
        public int id { get; set; }
        public string razon_social { get; set; }
        public string cuit { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string mail { get; set; }
        public Direccion direccion { get; set; }
        public string telefono { get; set; }
        public Usuario user { get; set; }
        public bool baja_logica { get; set; }
    }
}
