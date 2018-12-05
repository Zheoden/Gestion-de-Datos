using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class ClienteHistorial {
        public int id_Compra { get; set; }
        public DateTime Fecha_De_Compra { get; set; }
        public float Monto_De_Item { get; set; }
        public string Descripcion_Del_Pago { get; set; }
    }
}
