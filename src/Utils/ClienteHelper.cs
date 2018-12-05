using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PalcoNet.Objetos;
using System.Globalization;

namespace PalcoNet.Utils {

    public partial class DBHelper {

        public static Boolean bajaCliente(string cliente) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                                  "SET clie_habilitado = 0 " +
                                  "WHERE clie_nombre = '" + cliente + "'";
            command.Connection = conn;
            command.Connection.Open();
            int rows = command.ExecuteNonQuery();
            command.Connection.Close();
            conn.Close();
            return rows > 0;
        }

        public static Boolean clienteDontExistDocumento(string tipo, string documento) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Cliente c " +
                          "WHERE c.clie_tipo_documento = '" + tipo + "' AND " +
                          "c.clie_documento = '" + documento + "'";

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

        public static Boolean clienteDontExistUsuario(string usuario) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE u.usuario_username = '" + usuario + "'";

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

        public static Boolean clienteDontExistCuil(string cuil) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Cliente c " +
                          "WHERE c.clie_cuil = '" + cuil + "'";

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

        public static Boolean altaCliente(Cliente cliente) {
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento, clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id) " +
                                "VALUES ('" + cliente.nombre + "', '" + cliente.apellido + "', '" + cliente.tipo_documento + "', '" + cliente.documento + "', '" + cliente.cuil + "', '" + cliente.mail + "'," +
                                " '" + cliente.telefono + "'," + "(SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + cliente.dire.calle + "' AND dire_numero = '" + cliente.dire.numero +
                                "' AND dire_piso = '" + cliente.dire.piso + "' AND dire_depto = '" + cliente.dire.depto + "' AND dire_localidad = '" + cliente.dire.localidad + "' AND dire_codigo_postal = '" +
                                cliente.dire.codigo_postal + "') , '" + cliente.fecha_nacimiento.ToString("yyyy-MM-dd HH:mm:ss") +
                                "', '" + VariablesGlobales.FechaHoraSistemaString + "' ," + "(SELECT TOP 1 tarj_id FROM EL_REJUNTE.Tarjeta WHERE tarj_numero = '" + cliente.tarjeta.numero + "' AND tarj_cod_seguridad = '" +
                                cliente.tarjeta.cod_seguridad + "' AND tarj_vencimiento = '" + cliente.tarjeta.vencimiento + "' AND tarj_titular = '" + cliente.tarjeta.titular + "' AND tarj_tipo = '" +
                                cliente.tarjeta.tipo + "')" + ", 1, (SELECT u.usuario_id FROM EL_REJUNTE.Usuario u WHERE u.usuario_username = '" + cliente.documento + "')" +
                                ")";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Cliente getClienteData(int ID) {
            if (clienteTieneTarjeta(ID)) {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                conn.Open();
                string SQL = "SELECT c.clie_id, c.clie_nombre, c.clie_apellido, c.clie_tipo_documento, c.clie_documento, c.clie_cuil, c.clie_email, c.clie_telefono, c.clie_fecha_nacimiento, c.clie_fecha_creacion, c.clie_habilitado, d.dire_id, d.dire_calle, d.dire_numero, d.dire_piso, d.dire_depto, d.dire_localidad, d.dire_codigo_postal, t.tarj_id, t.tarj_numero, t.tarj_cod_seguridad, t.tarj_vencimiento, t.tarj_titular, t.tarj_tipo " +
                              "FROM EL_REJUNTE.Cliente c, EL_REJUNTE.Direccion d, EL_REJUNTE.Tarjeta t " +
                              "WHERE c.clie_id = " + ID + " AND " +
                              "c.clie_direccion_id = d.dire_id AND " +
                              "c.clie_tarjeta_id = t.tarj_id";
                SqlCommand command = new SqlCommand(SQL, conn);
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
                Cliente cliente = new Cliente();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        cliente.id = Int32.Parse(reader["clie_id"].ToString());
                        cliente.nombre = reader["clie_nombre"].ToString();
                        cliente.apellido = reader["clie_apellido"].ToString();
                        cliente.tipo_documento = reader["clie_tipo_documento"].ToString();
                        cliente.documento = reader["clie_documento"].ToString();
                        cliente.cuil = reader["clie_cuil"].ToString();
                        cliente.mail = reader["clie_email"].ToString();
                        cliente.telefono = reader["clie_telefono"].ToString();
                        cliente.fecha_nacimiento = Convert.ToDateTime(reader["clie_fecha_nacimiento"]);
                        cliente.fecha_creacion = Convert.ToDateTime(reader["clie_fecha_creacion"]);
                        cliente.habilitado = Convert.ToBoolean(reader["clie_habilitado"].ToString());

                        Direccion dire = new Direccion();

                        dire.id = Int32.Parse(reader["dire_id"].ToString());
                        dire.calle = reader["dire_calle"].ToString();
                        dire.numero = reader["dire_numero"].ToString();
                        dire.piso = reader["dire_piso"].ToString();
                        dire.depto = reader["dire_depto"].ToString();
                        dire.localidad = reader["dire_localidad"].ToString();
                        dire.codigo_postal = reader["dire_codigo_postal"].ToString();

                        cliente.dire = dire;

                        Tarjeta tarjeta = new Tarjeta();

                        tarjeta.id = Int32.Parse(reader["tarj_id"].ToString());
                        tarjeta.numero = reader["tarj_numero"].ToString();
                        tarjeta.cod_seguridad = reader["tarj_cod_seguridad"].ToString();
                        tarjeta.vencimiento = reader["tarj_vencimiento"].ToString();
                        tarjeta.titular = reader["tarj_titular"].ToString();
                        tarjeta.tipo = reader["tarj_tipo"].ToString();

                        cliente.tarjeta = tarjeta;

                    }
                }

                conn.Close();
                return cliente;
            }
            else {
                SqlConnection conn = new SqlConnection(Connection.getStringConnection());
                conn.Open();
                string SQL = "SELECT c.clie_id, c.clie_nombre, c.clie_apellido, c.clie_tipo_documento, c.clie_documento, c.clie_cuil, c.clie_email, c.clie_telefono, c.clie_fecha_nacimiento, c.clie_fecha_creacion, c.clie_habilitado, d.dire_id, d.dire_calle, d.dire_numero, d.dire_piso, d.dire_depto, d.dire_localidad, d.dire_codigo_postal " +
                              "FROM EL_REJUNTE.Cliente c, EL_REJUNTE.Direccion d, EL_REJUNTE.Tarjeta t " +
                              "WHERE c.clie_id = " + ID + " AND " +
                              "c.clie_direccion_id = d.dire_id";
                SqlCommand command = new SqlCommand(SQL, conn);
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
                Cliente cliente = new Cliente();

                if (reader.HasRows) {
                    while (reader.Read()) {
                        cliente.id = Int32.Parse(reader["clie_id"].ToString());
                        cliente.nombre = reader["clie_nombre"].ToString();
                        cliente.apellido = reader["clie_apellido"].ToString();
                        cliente.tipo_documento = reader["clie_tipo_documento"].ToString();
                        cliente.documento = reader["clie_documento"].ToString();
                        cliente.cuil = reader["clie_cuil"].ToString();
                        cliente.mail = reader["clie_email"].ToString();
                        cliente.telefono = reader["clie_telefono"].ToString();
                        cliente.fecha_nacimiento = Convert.ToDateTime(reader["clie_fecha_nacimiento"]);
                        cliente.fecha_creacion = Convert.ToDateTime(reader["clie_fecha_creacion"]);
                        cliente.habilitado = Convert.ToBoolean(reader["clie_habilitado"].ToString());

                        Direccion dire = new Direccion();

                        dire.id = Int32.Parse(reader["dire_id"].ToString());
                        dire.calle = reader["dire_calle"].ToString();
                        dire.numero = reader["dire_numero"].ToString();
                        dire.piso = reader["dire_piso"].ToString();
                        dire.depto = reader["dire_depto"].ToString();
                        dire.localidad = reader["dire_localidad"].ToString();
                        dire.codigo_postal = reader["dire_codigo_postal"].ToString();

                        cliente.dire = dire;

                    }
                }

                conn.Close();
                return cliente;
            }
        }

        public static Boolean modificarCliente(Cliente cliente) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                               "SET clie_nombre = '" + cliente.nombre + "', clie_apellido = '" + cliente.apellido + "', clie_tipo_documento= '" + cliente.tipo_documento + "', clie_documento= '" + cliente.documento + "', clie_cuil= '" + cliente.cuil + "', clie_email= '" + cliente.mail + "', clie_telefono= '" + cliente.telefono + "', clie_direccion_id = (SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + cliente.dire.calle + "' AND dire_numero = '" + cliente.dire.numero + "' AND dire_piso = '" + cliente.dire.piso + "' AND dire_depto = '" + cliente.dire.depto + "' AND dire_localidad = '" + cliente.dire.localidad + "' AND dire_codigo_postal = '" + cliente.dire.codigo_postal + "') , clie_tarjeta_id = (SELECT TOP 1 tarj_id FROM EL_REJUNTE.Tarjeta WHERE tarj_numero = '" + cliente.tarjeta.numero + "' AND tarj_cod_seguridad = '" + cliente.tarjeta.cod_seguridad + "' AND tarj_vencimiento = '" + cliente.tarjeta.vencimiento + "' AND tarj_titular = '" + cliente.tarjeta.titular + "' AND tarj_tipo = '" + cliente.tarjeta.tipo + "') , clie_habilitado = " + Convert.ToInt32(cliente.habilitado) + " " +
                               "WHERE clie_id = " + cliente.id;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean asociarUsuarioCliente(string cuil) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Cliente " +
                               "SET clie_usuario_id = (SELECT usuario_id FROM EL_REJUNTE.Usuario WHERE usuario_username = '" + cuil + "') " +
                               "WHERE clie_cuil = '" + cuil + "'";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static Boolean clienteTieneTarjeta(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Cliente c " +
                          "WHERE c.clie_id = " + id + " AND " +
                          "c.clie_tarjeta_id IS NOT NULL";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            return reader.HasRows;
        }

        public static List<ClienteHistorial> clieGetHistorial(int id) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT c.compra_id, c.compra_fecha, i.item_monto, f.fact_pago_desc " +
                         "FROM EL_REJUNTE.Compra c, EL_REJUNTE.Ubicacion_compra uc, EL_REJUNTE.Ubicacion u, EL_REJUNTE.Item_Factura i, EL_REJUNTE.Factura f " +
                         "WHERE c.compra_id = uc.compra_id AND " +
                               "uc.ubica_id = u.ubica_id AND " +
                               "i.item_ubicacion_id = u.ubica_id AND " +
                               "f.fact_id = i.item_factura_id AND " +
                               "c.compra_cliente_id = " + id + " AND " +
                               "f.fact_cliente_id = " + id + " " +
                         "ORDER BY c.compra_id";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            List<ClienteHistorial> clientes = new List<ClienteHistorial>();

            if (reader.HasRows) {
                while (reader.Read()) {
                    ClienteHistorial cliente = new ClienteHistorial();
                    cliente.compra_id = Int32.Parse(reader["compra_id"].ToString());
                    cliente.fact_pago_desc = reader["fact_pago_desc"].ToString();
                    cliente.compra_fecha = Convert.ToDateTime(reader["compra_fecha"]);
                    cliente.item_monto = float.Parse(reader["item_monto"].ToString());
                    clientes.Add(cliente);
                }
            }

            conn.Close();
            return clientes;

        }

        public static int clienteGetId(int id_user) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT clie_id " +
                         "FROM EL_REJUNTE.Cliente " +
                         "WHERE clie_usuario_id = " + id_user;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (reader.HasRows) {
                reader.Read();
                return Convert.ToInt32(reader["clie_id"]);
            }

            conn.Close();
            return 0;
        }

        public static Boolean tieneTarjeta(int id_user) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT DISTINCT clie_tarjeta_id " +
                         "FROM EL_REJUNTE.Cliente " +
                         "WHERE clie_usuario_id = " + id_user;

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            bool aux = reader.HasRows;
            conn.Close();
            return aux;
        }

        public static Boolean clienteAcreditarPuntos(int id_cliente, int puntos) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Puntaje (punt_cliente_id, punt_cantidad, punt_vencimiento, punt_disponible) " +
                               "VALUES (" + id_cliente + ", " + puntos + ", (DateAdd(yy, +1, '" + VariablesGlobales.FechaHoraSistemaString + "')), 1)";
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;
        }

        public static int clienteGetPuntos(int id) {
            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT SUM(p.punt_cantidad) as Puntos " +
                          "FROM EL_REJUNTE.Puntaje p " +
                          "WHERE p.punt_cliente_id = " + id + " AND " +
                                "p.punt_disponible = 1 AND  p.punt_vencimiento >= '" + VariablesGlobales.FechaHoraSistemaString + "'";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int puntaje = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    if (reader["Puntos"].ToString() != null) {
                        Int32.TryParse(reader["Puntos"].ToString(), out puntaje);
                    }
                    else {
                        return 0;
                    }
                }
            }

            conn.Close();
            return puntaje;
        }

        public static Boolean puntosInhabilitar(int idPuntos) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Puntaje " +
                               "SET punt_disponible = 0 " +
                               "WHERE punt_id = " + idPuntos;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;

        }

        public static Boolean puntosReducir(int idPuntos, int nuevaCantidad) {

            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "UPDATE EL_REJUNTE.Puntaje " +
                               "SET punt_cantidad = " + nuevaCantidad + " " +
                               "WHERE punt_id = " + idPuntos;
            comm.Connection = connection;
            comm.Connection.Open();
            int rows = comm.ExecuteNonQuery();
            comm.Connection.Close();
            connection.Close();
            return rows > 0;

        }

        public static Boolean puntosCanjear(int idcliente, int cantidad) {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT punt_id, punt_cantidad " +
                         "FROM EL_REJUNTE.Puntaje " +
                         "WHERE punt_cliente_id = " + idcliente + " AND " +
                         "punt_disponible = 1 AND  punt_vencimiento >= '" + VariablesGlobales.FechaHoraSistemaString + "' " +
                         "ORDER BY punt_vencimiento";
            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;
            int puntaje = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    puntaje = Int32.Parse(reader["punt_cantidad"].ToString());
                    if ((cantidad - puntaje) > 0) {
                        DBHelper.puntosInhabilitar(Int32.Parse(reader["punt_id"].ToString()));
                        cantidad -= puntaje;
                    }
                    else if ((cantidad - puntaje) == 0) {
                        DBHelper.puntosInhabilitar(Int32.Parse(reader["punt_id"].ToString()));
                        return true;
                    }
                    else if ((cantidad - puntaje) < 0) {
                        DBHelper.puntosReducir(Int32.Parse(reader["punt_id"].ToString()), puntaje - cantidad);
                        return true;
                    }
                }
            }

            conn.Close();
            return true;

        }

    }
}