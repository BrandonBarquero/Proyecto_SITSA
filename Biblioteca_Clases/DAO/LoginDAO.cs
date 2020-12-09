using Biblioteca_Clases.Models;
using System.Collections;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class LoginDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public LoginDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int consultamenu(Usuario user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_CON_INICIO_SESION @Cedula, @Contrasena";
            comando.Parameters.AddWithValue("@Cedula", user.CEDULA);
            comando.Parameters.AddWithValue("@Contrasena", user.CONTRASENNA);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;

        }
        public bool cambiarcontrasenna(Usuario user)
        {
            bool result = false;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTUALIZAR_MAN_CONTRASENNA @Correo, @Contrasena";
            comando.Parameters.AddWithValue("@Correo", user.CEDULA);
            comando.Parameters.AddWithValue("@Contrasena", user.CONTRASENNA);
            try
            {
                comando.ExecuteNonQuery();

                result = true;
            }
            catch (SqlException e)
            {
            }
            return result;

        }
        public int cambiocontrasenna(Usuario user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTUALIZAR_MAN_CONTRASENNA_CAMBIO @CEDULA, @Contrasena";
            comando.Parameters.AddWithValue("@CEDULA", user.CEDULA);
            comando.Parameters.AddWithValue("@Contrasena", user.CONTRASENNA);

            result = comando.ExecuteNonQuery();


            return result;

        }
        public int cambiarcontrasennacorreo(Usuario user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTUALIZAR_MAN_CONTRASENNA_CORREO @CORREO, @Contrasena";
            comando.Parameters.AddWithValue("@CORREO", user.CEDULA);
            comando.Parameters.AddWithValue("@Contrasena", user.CONTRASENNA);
            result = comando.ExecuteNonQuery();

            return result;

        }
        public ArrayList consultacorreos()
        {
            ArrayList listacorreos = new ArrayList();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_CORREOS";
            SqlDataReader list = comando.ExecuteReader();

            while (list.Read())
            {

                listacorreos.Add(list.GetString(0));
            }

            list.Dispose();
            comando.Dispose();
            return listacorreos;

        }
        public int consultausuarioperfil(string cedula)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_BUSCAR_PERFIL_USUARIO @CORREO";
            comando.Parameters.AddWithValue("@CORREO", cedula);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;


        }
    }
}
