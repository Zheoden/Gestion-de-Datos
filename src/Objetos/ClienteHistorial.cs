using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class ClienteHistorial {
        public int compra_id { get; set; }
        public DateTime compra_fecha { get; set; }
        public int item_monto { get; set; }
        public string fact_pago_desc { get; set; }
    }
}
