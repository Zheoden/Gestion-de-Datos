using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool habilitado { get; set; }
        public int cant_logeo_error { get; set; }
        public string tipo { get; set; }
        public List<Rol> roles { get; set; }
        public List<Funcionalidad> funcionalidades { get; set; }
    }
}
