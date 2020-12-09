using Biblioteca_Clases.Models;
using System.Data.SqlClient;
namespace Biblioteca_Clases.DAO
{
    public class Cliente_ContactoDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Cliente_ContactoDAO()
        {
            this.conexion = Conexion.getConexion();
        }



        public int AgregarCliente_Contacto(Cliente_Contacto cliente)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_AGREGAR_CLIENTE_CONTACTO @ESTADO, @USUARIO_CREACION, @FECHA_CREACION,@FK_ID_CLIENTE, @FK_ID_CONTACTO";
            comando.Parameters.AddWithValue("@ESTADO", cliente.ESTADO); ;
            comando.Parameters.AddWithValue("@USUARIO_CREACION", cliente.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_CREACION", cliente.FECHA_CREACION);
            comando.Parameters.AddWithValue("@FK_ID_CLIENTE", cliente.FK_ID_CLIENTE);
            comando.Parameters.AddWithValue("@FK_ID_CONTACTO", cliente.FK_ID_CONTACTO);


            result = comando.ExecuteNonQuery();

            return result;

        }
    }
}
