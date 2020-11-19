using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.DAO
{
   public class ContadoresDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ContadoresDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int Contar_Clientes()
        {
           // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_CLIENTES";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Usuarios()
        {
            // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_USUARIOS";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Contratos()
        {
            // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_CONTRATOS";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }
        public int Contar_Servicios()
        {
            // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_SERVICIOS";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Proyectos()
        {
            // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_PROYECTOS";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Cierre_Mes()
        {
            // int result = 0;
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_REG_CONTAR_CIERRE_MES";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

    }
}
