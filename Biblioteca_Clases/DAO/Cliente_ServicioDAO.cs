using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class Cliente_ServicioDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Cliente_ServicioDAO()
        {
            this.conexion = Conexion.getConexion();
        }



        public int AgregarCliente_Servicio(Cliente_Servicio cliente)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_CLIENTE_SERVICIO @TARIFA_HORA, @ESTADO, @USUARIO_CREACION, @FECHA_CREACION,@FK_ID_CLIENTE, @FK_ID_SERVICIO";
            comando.Parameters.AddWithValue("@TARIFA_HORA", cliente.TARIFA_HORA); ;
            comando.Parameters.AddWithValue("@ESTADO", cliente.ESTADO);
            comando.Parameters.AddWithValue("@USUARIO_CREACION", cliente.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_CREACION", cliente.FECHA_CREACION);
            comando.Parameters.AddWithValue("@FK_ID_CLIENTE", cliente.FK_ID_CLIENTE);
            comando.Parameters.AddWithValue("@FK_ID_SERVICIO", cliente.FK_ID_SERVICIO);




            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Cliente_Servicio> Listar_servicio_cliente_filtrado(string dato)
        {
            List<Cliente_Servicio> listaServicios = new List<Cliente_Servicio>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "EXEC [PA_CON_LISTAR_MAN_SERVICIO_CLIENTE_FILTRADO] @CLIENTE";
            comando.Parameters.AddWithValue("@CLIENTE", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Cliente_Servicio client = new Cliente_Servicio();
                client.PK_CLIENTE_SERVICIO = list.GetInt32(0);
                client.TARIFA_HORA = list.GetDouble(1);
                client.USAURIO_MODIFICACION = list.GetString(2);        //arreglar esto
                listaServicios.Add(client);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }
        public List<Proyecto> Listar_servicio_cliente_filtrado_contrato(string dato)
        {
            List<Proyecto> listaServicios = new List<Proyecto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "EXEC [PA_CON_LISTAR_MAN_SERVICIO_CLIENTE_FILTRADO_CONTRATO] @CLIENTE";
            comando.Parameters.AddWithValue("@CLIENTE", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Proyecto client = new Proyecto();
                client.ID_PROYECTO = list.GetInt32(0);
                client.NOMBRE = list.GetString(1);

                listaServicios.Add(client);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }

    }
}
