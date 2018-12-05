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

        public static Boolean altaEmpresa(Empresa empresa) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Empresa (empre_razon_social, empre_cuit, empre_fecha_creacion, empre_mail, empre_direccion_id , empre_telefono, empre_usuario_id, empre_baja_logica) " +
                                "VALUES ('" + empresa.razon_social + "', '" + empresa.cuit + "', '" + VariablesGlobales.FechaHoraSistemaString + "' , '" + empresa.mail + "', (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + empresa.direccion.calle + "' AND dire_numero = '" + empresa.direccion.numero + "' AND dire_piso = '" + empresa.direccion.piso + "' AND dire_depto = '" + empresa.direccion.depto + "' AND dire_localidad = '" + empresa.direccion.localidad + "' AND dire_codigo_postal = '" + empresa.direccion.codigo_postal + "') , '" + empresa.telefono + "', (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE u.usuario_username = '" + empresa.cuit + "'), 0" +
                                ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean bajaEmpresa(string razon_social) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Empresa " +
                                  "SET empre_baja_logica = 1 " +
                                  "WHERE empre_razon_social = '" + razon_social + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean EmpresaDontExistCuit(string cuit) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Empresa " +
                          "WHERE empre_cuit = '" + cuit + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows) {
                return true;
            }

            conn.Close();
            return false;
        }

        public static Boolean modificarEmpresa(Empresa empresa) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Empresa " +
                               "SET empre_razon_social = '" + empresa.razon_social + "', empre_cuit = '" + empresa.cuit + "', empre_mail= '" + empresa.mail + "', empre_telefono= '" + empresa.telefono + "', empre_baja_logica= " + Convert.ToInt32(empresa.baja_logica) + ", empre_direccion_id = (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + empresa.direccion.calle + "' AND dire_numero = '" + empresa.direccion.numero + "' AND dire_piso = '" + empresa.direccion.piso + "' AND dire_depto = '" + empresa.direccion.depto + "' AND dire_localidad = '" + empresa.direccion.localidad + "' AND dire_codigo_postal = '" + empresa.direccion.codigo_postal + "') " +
                               "WHERE empre_id = " + empresa.id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Empresa cargarEmpresa(int id) {

            Empresa empresa = new Empresa();

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT e.empre_id, e.empre_razon_social , e.empre_cuit , e.empre_fecha_creacion, e.empre_mail, e.empre_telefono, e.empre_baja_logica, d.dire_id, d.dire_calle, d.dire_numero, d.dire_piso, d.dire_depto, d.dire_localidad, d.dire_codigo_postal " +
                         "FROM EL_REJUNTE.Empresa e, EL_REJUNTE.Direccion d " +
                         "WHERE e.empre_direccion_id = d.dire_id AND e.empre_id = " + id;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                while (reader.Read()) {
                    empresa.id = Int32.Parse(reader["empre_id"].ToString());
                    empresa.razon_social = reader["empre_razon_social"].ToString();
                    empresa.cuit = reader["empre_cuit"].ToString();
                    empresa.fecha_creacion = Convert.ToDateTime(reader["empre_fecha_creacion"].ToString());
                    empresa.mail = reader["empre_mail"].ToString();
                    empresa.telefono = reader["empre_telefono"].ToString();
                    empresa.baja_logica = Convert.ToBoolean(reader["empre_baja_logica"].ToString());

                    Direccion dire = new Direccion();

                    dire.id = Int32.Parse(reader["dire_id"].ToString());
                    dire.calle = reader["dire_calle"].ToString();
                    dire.numero = reader["dire_numero"].ToString();
                    dire.piso = reader["dire_piso"].ToString();
                    dire.depto = reader["dire_depto"].ToString();
                    dire.localidad = reader["dire_localidad"].ToString();
                    dire.codigo_postal = reader["dire_codigo_postal"].ToString();

                    empresa.direccion = dire;
                }
            }

            conn.Close();
            return empresa;
        }

        public static Boolean asociarUsuarioEmpresa(string cuit) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Empresa " +
                               "SET empre_usuario_id = (SELECT usuario_id FROM EL_REJUNTE.Usuario WHERE usuario_username = '" + cuit + "') " +
                               "WHERE empre_cuit = '" + cuit + "'";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static List<EmpresasMenosVendidas> empresasMenosVendidas(DateTime inicio, DateTime final, int grado_id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT TOP 5 SUM(p.publi_stock) as 'Bucatas no Vendidas', e.empre_id, e.empre_razon_social, e.empre_cuit, e.empre_mail, e.empre_telefono, g.grado_prioridad " +
                         "FROM EL_REJUNTE.Publicacion p, EL_REJUNTE.Usuario u, EL_REJUNTE.Empresa e, EL_REJUNTE.Grado g " +
                         "WHERE p.publi_usuario_id = u.usuario_id AND " +
                               "e.empre_usuario_id = usuario_id AND " +
                               "p.publi_grado_id = g.grado_id AND " +
                               "p.publi_fecha_inicio BETWEEN '" + inicio.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + final.ToString("yyyy-MM-dd HH:mm:ss") + "' AND " +
                               "g.grado_id = " + grado_id +" " +
                         "GROUP BY e.empre_id, e.empre_razon_social, e.empre_cuit, e.empre_mail, e.empre_telefono, g.grado_comision,  g.grado_prioridad " +
                         "ORDER BY 1 desc, g.grado_comision";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<EmpresasMenosVendidas> clientes = new List<EmpresasMenosVendidas>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    EmpresasMenosVendidas cliente = new EmpresasMenosVendidas();
                    cliente.Butacas_No_Vendidas = Int32.Parse(reader["Bucatas no Vendidas"].ToString());
                    cliente.Empresa_id = Int32.Parse(reader["empre_id"].ToString());
                    cliente.Razon_Social = reader["empre_razon_social"].ToString();
                    cliente.CUIT = reader["empre_cuit"].ToString();
                    cliente.Mail = reader["empre_mail"].ToString();
                    cliente.Telefono = reader["empre_telefono"].ToString();
                    cliente.Grado_De_Visibilidad = reader["grado_prioridad"].ToString();
                    clientes.Add(cliente);
                }
            }

            conn.Close();
            return clientes;

        }

    }
}