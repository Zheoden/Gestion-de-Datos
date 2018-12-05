using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PalcoNet;

namespace PalcoNet.Objetos
{
    public class ClientesPuntosVencidos {
        public int Cantidad_De_Puntos { get; set; }
        public int Cliente_id { get; set; }
        public string Nombre_Completo { get; set; }
        public string Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public string CUIL { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_De_Nacimiento { get; set; }
    }

    public class ClientesMasCompras {
        public int Cantidad_De_Compras { get; set; }
        public int Cliente_id { get; set; }
        public string Nombre_Completo { get; set; }
        public string Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public string CUIL { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_De_Nacimiento { get; set; }
    }

    public class EmpresasMenosVendidas {
        public int Butacas_No_Vendidas { get; set; }
        public int Empresa_id { get; set; }
        public string Razon_Social { get; set; }
        public string CUIT { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Grado_De_Visibilidad { get; set; }
    }

}
