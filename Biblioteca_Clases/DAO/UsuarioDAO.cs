using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class UsuarioDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public UsuarioDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Usuario> listausuarios()
        {
            List<Usuario> listusuarios = new List<Usuario>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_USUARIO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Usuario user = new Usuario();
                user.CEDULA = list.GetString(1);
                user.NOMBRE = list.GetString(2);
                user.CORREO = list.GetString(3);
                user.ESTADO = list.GetBoolean(4);
                user.FK_PERFIL = list.GetInt32(10);
                listusuarios.Add(user);
            }
            list.Dispose();
            comando.Dispose();
            return listusuarios;

        }

        public Usuario listausuarios(string cedula)
        {
            Usuario user = new Usuario();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_USUARIO @cedula";
            comando.Parameters.AddWithValue("@cedula", cedula);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                user.ID_USUARIO = list.GetInt32(0);
                user.CEDULA = list.GetString(1);
                user.NOMBRE = list.GetString(2);
                user.CORREO = list.GetString(3);
                user.ESTADO = list.GetBoolean(4);
                user.FK_PERFIL = list.GetInt32(10);

            }
            list.Dispose();
            comando.Dispose();
            return user;
        }


        public int verificacedula(string dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_CON_VERFICA_CEDULA @Cedula";
            comando.Parameters.AddWithValue("@Cedula", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;

        }
        public int verificaemail(string dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_CON_VERFICA_CORREO  @Correo";
            comando.Parameters.AddWithValue("@Correo", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;

        }

        public int AgregarUsuario(Usuario user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_MAN_USUARIO @CEDULA, @NOMBRE,@CORREO, @CONTRASENNA,@FECHA, @USUARIO, @FK_PERFIL";
            comando.Parameters.AddWithValue("@CEDULA", user.CEDULA);
            comando.Parameters.AddWithValue("@NOMBRE", user.NOMBRE);
            comando.Parameters.AddWithValue("@CORREO", user.CORREO);
            comando.Parameters.AddWithValue("@CONTRASENNA", user.CONTRASENNA);
            comando.Parameters.AddWithValue("@FECHA", user.FECHA_CREACION);
            comando.Parameters.AddWithValue("@USUARIO", user.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FK_PERFIL", user.FK_PERFIL);

            result = comando.ExecuteNonQuery();

            return result;

        }


        public int ActualizarUsuario(Usuario user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ACTUALIZAR_MAN_USUARIO @CEDULA, @NOMBRE,@CORREO,@FK_PERFIL,@FECHA,@USUARIO";
            comando.Parameters.AddWithValue("@CEDULA", user.CEDULA);
            comando.Parameters.AddWithValue("@NOMBRE", user.NOMBRE);
            comando.Parameters.AddWithValue("@CORREO", user.CORREO);
            comando.Parameters.AddWithValue("@FK_PERFIL", user.FK_PERFIL);
            comando.Parameters.AddWithValue("@FECHA", user.FECHA_MODIFICACION);
            comando.Parameters.AddWithValue("@USUARIO", user.USUARIO_MODIFICACION);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Usuario> ListaUsuariosActivos()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_USUARIO_ACTIVO";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Usuario user = new Usuario();
                user.ID_USUARIO = list.GetInt32(0);
                user.CEDULA = list.GetString(1);
                user.NOMBRE = list.GetString(2);
                user.CORREO = list.GetString(3);
                user.ESTADO = list.GetBoolean(4);
                user.FK_PERFIL = list.GetInt32(10);
                listaUsuario.Add(user);

            }
            list.Dispose();
            comando.Dispose();
            return listaUsuario;
        }

        public List<Usuario> ListaUsuariosInactivos()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_USUARIO_INACTIVO";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Usuario user = new Usuario();
                user.ID_USUARIO = list.GetInt32(0);
                user.CEDULA = list.GetString(1);
                user.NOMBRE = list.GetString(2);
                user.CORREO = list.GetString(3);
                user.ESTADO = list.GetBoolean(4);
                user.FK_PERFIL = list.GetInt32(10);
                listaUsuario.Add(user);

            }
            list.Dispose();
            comando.Dispose();
            return listaUsuario;
        }

        public List<Usuario> ListaUsuariosGeneral()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_USUARIO_GENERAL";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Usuario user = new Usuario();
                user.ID_USUARIO = list.GetInt32(0);
                user.CEDULA = list.GetString(1);
                user.NOMBRE = list.GetString(2);
                user.CORREO = list.GetString(3);
                user.ESTADO = list.GetBoolean(4);
                user.FK_PERFIL = list.GetInt32(10);
                listaUsuario.Add(user);

            }
            list.Dispose();
            comando.Dispose();
            return listaUsuario;
        }


        public int ActualizarEstadoHabilitarUsuario(Usuario usuario)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_HABILITAR_USUARIO @PK_ID_USUARIO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_USUARIO", usuario.ID_USUARIO);
            comando.Parameters.AddWithValue("@USUARIO", usuario.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", usuario.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;
        }

        public int ActualizarEstadoDeshabilitarUsuarioo(Usuario usuario)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_DESHABILITAR_USUARIO @PK_ID_USUARIO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_USUARIO", usuario.ID_USUARIO);
            comando.Parameters.AddWithValue("@USUARIO", usuario.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", usuario.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;
        }


    }
}
