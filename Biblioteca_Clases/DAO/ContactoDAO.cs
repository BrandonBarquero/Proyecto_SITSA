using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class ContactoDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ContactoDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Contacto> listaContactos()
        {
            List<Contacto> listaContactos = new List<Contacto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_CON_LISTAR_MAN_CONTACTO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contacto cont = new Contacto();
                cont.ID_CONTACTO = list.GetInt32(0);
                cont.ENCARGADO = list.GetString(1);
                cont.TELEFONO = list.GetInt32(2);
                cont.CORREO = list.GetString(3);
                cont.TIPO_ENCARGADO = list.GetString(4);
                listaContactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContactos;

        }

        public List<Contacto> BuscarDatosContacto(int id)
        {
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_EXTRAER_CONTACTO_CLIENTE @ID";
            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader list = comando.ExecuteReader();
            Contacto cont = new Contacto();
            List<Contacto> contactos = new List<Contacto>();
            while (list.Read())
            {
                cont = new Contacto();
                cont.ID_CONTACTO = list.GetInt32(0);
                cont.ENCARGADO = list.GetString(1);
                cont.TELEFONO = list.GetInt32(2);
                cont.CORREO = list.GetString(3);
                contactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return contactos;
        }

        public int AgregarContacto(Contacto cont)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_AGREGAR_CONTACTO @ENCARGADO, @TELEFONO,@CORREO, @TIPO_ENCARGADO, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@ENCARGADO", cont.ENCARGADO);
            comando.Parameters.AddWithValue("@TELEFONO", cont.TELEFONO);
            comando.Parameters.AddWithValue("@CORREO", cont.CORREO);
            comando.Parameters.AddWithValue("@TIPO_ENCARGADO", cont.TIPO_ENCARGADO);
            comando.Parameters.AddWithValue("@USUARIO", cont.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", cont.FECHA_CREACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarContacto(Contacto cont)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTUALIZAR_CONTACTO @PK_ID_CONTACTO, @ENCARGADO, @TELEFONO,@CORREO, @TIPO_ENCARGADO, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_CONTACTO", cont.ID_CONTACTO);
            comando.Parameters.AddWithValue("@ENCARGADO", cont.ENCARGADO);
            comando.Parameters.AddWithValue("@TELEFONO", cont.TELEFONO);
            comando.Parameters.AddWithValue("@CORREO", cont.CORREO);
            comando.Parameters.AddWithValue("@TIPO_ENCARGADO", cont.TIPO_ENCARGADO);
            comando.Parameters.AddWithValue("@USUARIO", cont.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", cont.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public int EliminarContacto(Contacto cont)
        {

            int result = 0;

            try
            {
               
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "execute PA_CTRL_MAN_ELIMINAR_CONTACTO @PK_ID_CONTACTO";
                comando.Parameters.AddWithValue("@PK_ID_CONTACTO", cont.ID_CONTACTO);

                result = comando.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Error");
                return 2; 
            }

            return result;

        }
        public int EliminarClienteContacto(string dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_ELIMINAR_CLIENTE_CONTACTO] @PK_ID_CONTACTO";
            comando.Parameters.AddWithValue("@PK_ID_CONTACTO", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public Permiso_e ControlPaginas(string dato1, string dato2)
        {
            Permiso_e result = new Permiso_e();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "EXEC PA_CTRL_MAN_CONTROL_PAGINAS @dato1,@dato2";
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
        public List<Contacto> listaContactoscliente(int cliente)
        {
            List<Contacto> listaContactos = new List<Contacto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CTRL_CON_LISTAR_MAN_CONTACTO_CLIENTE] @CLIENTE";
            comando.Parameters.AddWithValue("@CLIENTE", cliente);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contacto cont = new Contacto();
                cont.AUX = list.GetInt32(0);
                cont.ID_CONTACTO = list.GetInt32(1);
                cont.ENCARGADO = list.GetString(2);
                cont.TELEFONO = list.GetInt32(3);
                cont.CORREO = list.GetString(4);
                cont.TIPO_ENCARGADO = list.GetString(5);
                listaContactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContactos;

        }

    }
}
