using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class ProyectoDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ProyectoDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Proyecto> listaProyectos()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_PROYECTO_ACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Proyecto proy = new Proyecto();
                proy.ID_PROYECTO = list.GetInt32(0);
                proy.NOMBRE = list.GetString(1);
                proy.DESCRIPCION = list.GetString(2);
                proy.PRECIO = list.GetDouble(3);
                proy.ESTADO = list.GetInt32(4);
                proy.FK_ID_CLIENTE = list.GetInt32(5);
                listaProyectos.Add(proy);
            }
            list.Dispose();
            comando.Dispose();
            return listaProyectos;

        }
        public List<Proyecto> listaProyectos_INACTIVOS()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_PROYECTO_INACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Proyecto proy = new Proyecto();
                proy.ID_PROYECTO = list.GetInt32(0);
                proy.NOMBRE = list.GetString(1);
                proy.DESCRIPCION = list.GetString(2);
                proy.PRECIO = list.GetDouble(3);
                proy.ESTADO = list.GetInt32(4);
                proy.FK_ID_CLIENTE = list.GetInt32(5);
                listaProyectos.Add(proy);
            }
            list.Dispose();
            comando.Dispose();
            return listaProyectos;

        }
        public List<Proyecto> listaProyectos_General()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_PROYECTO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Proyecto proy = new Proyecto();
                proy.ID_PROYECTO = list.GetInt32(0);
                proy.NOMBRE = list.GetString(1);
                proy.DESCRIPCION = list.GetString(2);
                proy.PRECIO = list.GetDouble(3);
                proy.ESTADO = list.GetInt32(4);
                proy.FK_ID_CLIENTE = list.GetInt32(5);
                listaProyectos.Add(proy);
            }
            list.Dispose();
            comando.Dispose();
            return listaProyectos;

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

        public int AgregarProyecto(Proyecto proy)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_PROYECTO @NOMBRE, @DESCRIPCION, @PRECIO, @ESTADO,@USUARIO, @FECHA, @FK_ID_CLIENTE";
            comando.Parameters.AddWithValue("@NOMBRE", proy.NOMBRE);
            comando.Parameters.AddWithValue("@DESCRIPCION", proy.DESCRIPCION);
            comando.Parameters.AddWithValue("@PRECIO", proy.PRECIO);
            comando.Parameters.AddWithValue("@ESTADO", 1);
            comando.Parameters.AddWithValue("@USUARIO", proy.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", proy.FECHA_CREACION);
            comando.Parameters.AddWithValue("@FK_ID_CLIENTE", proy.FK_ID_CLIENTE);


            result = Convert.ToInt32(comando.ExecuteScalar());
            return result;

        }

        public int ActualizarProyecto(Proyecto proy)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ACTUALIZAR_PROYECTO @PK_ID_PROYECTO, @NOMBRE, @DESCRIPCION, @PRECIO,@USUARIO, @FECHA, @FK_ID_CLIENTE";
            comando.Parameters.AddWithValue("@PK_ID_PROYECTO", proy.ID_PROYECTO);
            comando.Parameters.AddWithValue("@NOMBRE", proy.NOMBRE);
            comando.Parameters.AddWithValue("@DESCRIPCION", proy.DESCRIPCION);
            comando.Parameters.AddWithValue("@PRECIO", proy.PRECIO);
            comando.Parameters.AddWithValue("@USUARIO", proy.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", proy.FECHA_CREACION);
            comando.Parameters.AddWithValue("@FK_ID_CLIENTE", proy.FK_ID_CLIENTE);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarEstadoDeshabilitarProyecto(Proyecto proy)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_DESHABILITAR_PROYECTO @PK_ID_PROYECTO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_PROYECTO", proy.ID_PROYECTO);
            comando.Parameters.AddWithValue("@USUARIO", proy.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", proy.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarEstadoHabilitarProyecto(Proyecto proy)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_HABILITAR_PROYECTO @PK_ID_PROYECTO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_PROYECTO", proy.ID_PROYECTO);
            comando.Parameters.AddWithValue("@USUARIO", proy.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", proy.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Proyecto> listaProyectos_cliente(int id, int opc)
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "";
            if (opc == 1)
            {
                comando.CommandText = "exec PA_CON_LISTAR_MAN_PROYECTO_CLIENTE @ID";
            }
            else if (opc == 2)
            {
                comando.CommandText = "exec PA_CON_LISTAR_MAN_PROYECTO_CLIENTE_GARANTIA @ID";
            }

            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Proyecto proy = new Proyecto();
                proy.ID_PROYECTO = list.GetInt32(0);
                proy.NOMBRE = list.GetString(1);
                proy.DESCRIPCION = list.GetString(2);
                proy.PRECIO = list.GetDouble(3);
                proy.ESTADO = list.GetInt32(4);
                proy.FK_ID_CLIENTE = list.GetInt32(5);
                listaProyectos.Add(proy);
            }
            list.Dispose();
            comando.Dispose();
            return listaProyectos;
        }

        public Proyecto devuelve_proyecto(int id)
        {
            Proyecto proyecto = new Proyecto();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_CON_DEVUELVE_PROYECTO @ID";
            comando.Parameters.AddWithValue("@ID", id);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                proyecto = new Proyecto();
                proyecto.ID_PROYECTO = list.GetInt32(0);
                proyecto.FK_ID_CLIENTE = list.GetInt32(1);
                proyecto.NOMBRE = list.GetString(2);
                proyecto.DESCRIPCION = list.GetString(3);
                proyecto.PRECIO = list.GetDouble(4);
            }
            list.Dispose();
            comando.Dispose();
            return proyecto;
        }

    }
}