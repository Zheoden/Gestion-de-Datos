using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PalcoNet.Objetos;

namespace PalcoNet.Utils {

    public partial class DBHelper {

        public static Boolean altaEspectaculo(Espectaculo espec) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Espectaculo (espec_codigo, espec_descripcion, espec_fecha, espec_fecha_venc, espec_rubro_id, espec_estado_id, espec_direccion_id) " +
                                "VALUES ( " + espec.codigo + ", '" + espec.descripcion + "', GETDATE(), '" + espec.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                                espec.rubro.id + ", " + espec.estado.id + ", (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + espec.direccion.calle + "' AND dire_numero = '" + espec.direccion.numero +
                                "' AND dire_piso = '" + espec.direccion.piso + "' AND dire_depto = '" + espec.direccion.depto + "' AND dire_localidad = '" + espec.direccion.localidad + "' AND dire_codigo_postal = '" +
                                espec.direccion.codigo_postal + "'))";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean modificarEspectaculo(Espectaculo espec) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Espectaculo "+
                                "SET espec_descripcion = '" + espec.descripcion + "', espec_fecha_venc = '" + espec.fecha_venc.ToString("yyyy-MM-dd HH:mm:ss") + "', espec_rubro_id = " + espec.rubro.id +
                                ",espec_estado_id = " + espec.estado.id + ", espec_direccion_id = (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + espec.direccion.calle + "' AND dire_numero = '" + espec.direccion.numero +
                                "' AND dire_piso = '" + espec.direccion.piso + "' AND dire_depto = '" + espec.direccion.depto + "' AND dire_localidad = '" + espec.direccion.localidad + "' AND dire_codigo_postal = '" +
                                espec.direccion.codigo_postal + "') " + 
                                "WHERE espec_codigo = " + espec.codigo;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

    }
}