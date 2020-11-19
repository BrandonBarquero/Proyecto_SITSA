using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class ServicioDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ServicioDAO()
        {
            this.conexion = Conexion.getConexion();
        }


        public List<Servicio> listaServicios()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_SERVICIO_ACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Servicio serv = new Servicio();
                serv.ID_SERVICIO = list.GetInt32(0);
                serv.DESCRIPCION = list.GetString(1);
                serv.ESTADO = list.GetInt32(2);
                listaServicios.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }
        public List<Servicio> listaServicios_INACTIVOS()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_SERVICIO_INACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Servicio serv = new Servicio();
                serv.ID_SERVICIO = list.GetInt32(0);
                serv.DESCRIPCION = list.GetString(1);
                serv.ESTADO = list.GetInt32(2);
                listaServicios.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }
        public List<Servicio> listaServicios_General()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_SERVICIO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Servicio serv = new Servicio();
                serv.ID_SERVICIO = list.GetInt32(0);
                serv.DESCRIPCION = list.GetString(1);
                serv.ESTADO = list.GetInt32(2);
                listaServicios.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }
        public List<Servicio> listaServiciosInactivos()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_SERVICIO_INACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Servicio serv = new Servicio();
                serv.ID_SERVICIO = list.GetInt32(0);
                serv.DESCRIPCION = list.GetString(1);
                serv.ESTADO = list.GetInt32(2);
                listaServicios.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listaServicios;

        }

        public int AgregarServicio(Servicio serv)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_SERVICIO @DESCRIPCION, @ESTADO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@DESCRIPCION", serv.DESCRIPCION);
            comando.Parameters.AddWithValue("@ESTADO", 1);
            comando.Parameters.AddWithValue("@USUARIO", serv.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", serv.FECHA_CREACION);


            result = comando.ExecuteNonQuery();

            return result;

        }


        public int ActualizarServicio(Servicio serv)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ACTUALIZAR_SERVICIO @PK_ID_SERVICIO, @DESCRIPCION,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_SERVICIO", serv.ID_SERVICIO);
            comando.Parameters.AddWithValue("@DESCRIPCION", serv.DESCRIPCION);
            comando.Parameters.AddWithValue("@USUARIO", serv.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", serv.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarEstadoDeshabilitarServicio(Servicio serv)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_DESHABILITAR_SERVICIO @PK_ID_SERVICIO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_SERVICIO", serv.ID_SERVICIO);
            comando.Parameters.AddWithValue("@USUARIO", serv.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", serv.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarEstadoHabilitarServicio(Servicio serv)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_HABILITAR_SERVICIO @PK_ID_SERVICIO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_SERVICIO", serv.ID_SERVICIO);
            comando.Parameters.AddWithValue("@USUARIO", serv.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", serv.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

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

        public int EliminarServicioContacto(string dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_MAN_ELIMINAR_CLIENTE_SERVICIO] @PK_ID_SERVICIO";
            comando.Parameters.AddWithValue("@PK_ID_SERVICIO", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }

    }
}
