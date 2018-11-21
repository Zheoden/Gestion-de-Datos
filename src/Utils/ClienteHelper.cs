﻿using System.Data.SqlClient;
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

        public static Boolean clienteDontExistUsuario(string usuario)
        {

            SqlConnection conn = new SqlConnection(Connection.getStringConnection());
            conn.Open();
            string SQL = "SELECT 1 " +
                          "FROM EL_REJUNTE.Usuario u " +
                          "WHERE u.usuario_username = '" + usuario + "'";

            SqlCommand command = new SqlCommand(SQL, conn);
            command.Connection = conn;
            command.CommandType = CommandType.Text;

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            if (!reader.HasRows)
            {
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
            MessageBox.Show(cliente.fecha_nacimiento.ToString());
            SqlConnection connection = new SqlConnection(Connection.getStringConnection());
            SqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO EL_REJUNTE.Cliente (clie_nombre, clie_apellido, clie_tipo_documento, clie_documento, clie_cuil, clie_email, clie_telefono, clie_direccion_id, clie_fecha_nacimiento, clie_fecha_creacion, clie_tarjeta_id, clie_habilitado, clie_usuario_id) " +
                                "VALUES ('" + cliente.nombre + "', '" + cliente.apellido + "', '" + cliente.tipo_documento + "', '" + cliente.documento + "', '" + cliente.cuil + "', '" + cliente.mail + "'," + 
                                " '" + cliente.telefono + "'," + "(SELECT TOP 1 dire_id FROM EL_REJUNTE.Direccion WHERE dire_calle = '" + cliente.dire.calle + "' AND dire_numero = '" + cliente.dire.numero + 
                                "' AND dire_piso = '" + cliente.dire.piso + "' AND dire_depto = '" + cliente.dire.depto + "' AND dire_localidad = '" + cliente.dire.localidad + "' AND dire_codigo_postal = '" +
                                cliente.dire.codigo_postal + "') , GETDATE()" + 
                                ", " + "GETDATE()" + "," + "(SELECT TOP 1 tarj_id FROM EL_REJUNTE.Tarjeta WHERE tarj_numero = '" + cliente.tarjeta.numero + "' AND tarj_cod_seguridad = '" + 
                                cliente.tarjeta.cod_seguridad + "' AND tarj_vencimiento = '" + cliente.tarjeta.vencimiento + "' AND tarj_titular = '" + cliente.tarjeta.titular + "' AND tarj_tipo = '" + 
                                cliente.tarjeta.tipo + "')" + ", 1, null" +
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
    }
}