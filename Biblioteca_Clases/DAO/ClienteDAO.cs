using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class ClienteDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ClienteDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Cliente> listaClientes()
        {
            List<Cliente> listaServicios = new List<Cliente>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_REG_LISTAR_REG_CLIENTE_ACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Cliente client = new Cliente();
                client.ID_CLIENTE = list.GetInt32(0);
                client.NOMBRE = list.GetString(1);
                listaServicios.Add(client);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }

        public Cliente filtrar_cliente(int id)
        {
            Cliente cliente = new Cliente();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_REG_LISTAR_REG_CLIENTE_FILTRADO @ID";
            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                cliente = new Cliente();
                cliente.ID_CLIENTE = list.GetInt32(0);
                cliente.NOMBRE = list.GetString(1);
            }
            list.Dispose();
            comando.Dispose();

            return cliente;
        }

        public Permiso_e ControlPaginas(string dato1, string dato2)
        {
            Permiso_e result = new Permiso_e();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "EXEC PA_MAN_CONTROL_PAGINAS @dato1,@dato2";
            comando.Parameters.AddWithValue("@dato1", dato1);
            comando.Parameters.AddWithValue("@dato2", dato2);



            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                result.CREAR = list.GetBoolean(0);
                result.EDTIAR = list.GetBoolean(1);
                result.VER = list.GetBoolean(2);
            }
            list.Dispose();
            comando.Dispose();


            return result;

        }

        public int DevuelveCliente(int id, int opc)
        {
            int cliente_id = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "";
            if (opc == 1) {
                comando.CommandText = "exec DEVUELVE_CLIENTE_CONTRATO @ID";
            } else if (opc == 2) {
                comando.CommandText = "exec DEVUELVE_CLIENTE_PROYECTO @ID";
            }
            
            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                cliente_id = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();

            return cliente_id;
        }
    }
}
