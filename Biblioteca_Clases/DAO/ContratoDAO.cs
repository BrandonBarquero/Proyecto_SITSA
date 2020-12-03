using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class ContratoDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ContratoDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Contrato> listaContratos(string condicion)
        {
            List<Contrato> listaContratos = new List<Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            if (condicion == "Activo")
            {
                comando.CommandText = "exec PA_CON_LISTAR_CONTRATO_ACTIVO";
            }
            else if (condicion == "Inactivo")
            {
                comando.CommandText = "exec PA_CON_LISTAR_CONTRATO_INACTIVO";
            }
            else
            {
                comando.CommandText = "exec PA_CON_LISTAR_CONTRATO";
            }

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contrato cont = new Contrato();
                cont.ID_CONTRATO = list.GetInt32(0);
                cont.NOMBRE_CONTRATO = list.GetString(1);
                cont.DESCRIPCION = list.GetString(2);
                cont.FECHA_INICIO = list.GetDateTime(3);
                cont.FECHA_VENCE = list.GetDateTime(4);
                //cont.PRECIO = list.GetDouble(5);
                cont.ESTADO = list.GetInt32(6);

                if (!list.IsDBNull(7))
                {
                    cont.MONTO = list.GetInt32(7);
                }
                if (!list.IsDBNull(8))
                {
                    cont.HORAS = list.GetDouble(8);
                }
                if (!list.IsDBNull(9))
                {
                    cont.RANGO = list.GetInt32(9);
                }
                if (!list.IsDBNull(10))
                {
                    cont.HORAS_POR_CONSUMIR = list.GetDouble(10);
                }
                cont.CLIENTE = list.GetInt32(15);
                cont.TIPO_CONTRATO = list.GetInt32(16);
                cont.CONTACTO = list.GetInt32(17);
                listaContratos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContratos;
        }

        public int RebajarHorasContrato(int id, double cANTIDAD_HORAS, string USER, string FECHA)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_REBAJAR_HORAS_CONTRATO @PK_ID_CONTRATO, @HORAS, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_CONTRATO", id);
            comando.Parameters.AddWithValue("@HORAS", cANTIDAD_HORAS);
            comando.Parameters.AddWithValue("@USUARIO", USER);
            comando.Parameters.AddWithValue("@FECHA", FECHA);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public List<Contrato> listaContratosCliente(string cliente, int opc)
        {
            List<Contrato> listaContratos = new List<Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "";
            if (opc == 1) {
                comando.CommandText = "exec PA_CON_LISTAR_CONTRATO_CLIENTE @CLIENTE";
            } else if (opc == 2){
                comando.CommandText = "exec PA_CON_LISTAR_CONTRATO_CLIENTE_GARANTIA @CLIENTE";
            }
            comando.Parameters.AddWithValue("@CLIENTE", cliente);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contrato cont = new Contrato();
                cont.ID_CONTRATO = list.GetInt32(0);
                cont.NOMBRE_CONTRATO = list.GetString(1);
                cont.DESCRIPCION = list.GetString(2);
                cont.FECHA_INICIO = list.GetDateTime(3);
                cont.FECHA_VENCE = list.GetDateTime(4);
                //cont.PRECIO = list.GetDouble(5);
                cont.ESTADO = list.GetInt32(6);
                if (!list.IsDBNull(7))
                {
                    cont.MONTO = list.GetInt32(7);
                }
                if (!list.IsDBNull(8))
                {
                    cont.HORAS = list.GetDouble(8);
                }
                if (!list.IsDBNull(9))
                {
                    cont.RANGO = list.GetInt32(9);
                }
                if (!list.IsDBNull(10))
                {
                    cont.HORAS_POR_CONSUMIR = list.GetDouble(10);
                }
                //cont.MONTO = list.GetInt32(7);
                //cont.HORAS = list.GetDouble(8);
                //cont.RANGO = list.GetInt32(9);
                //cont.HORAS_POR_CONSUMIR = list.GetDouble(10);
                listaContratos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContratos;
        }
        public int AgregarContrato(Contrato contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_CONTRATO @NOMBRE, @DESCRIPCION, @CONTACTO, @FECHA_INICIO, @FECHA_VENCE, @USUARIO, @FECHA, @TIPO_CONTRATO, @CLIENTE, @HORAS, @MONTO, @RANGO";
            comando.Parameters.AddWithValue("@NOMBRE", contrato.NOMBRE_CONTRATO);
            comando.Parameters.AddWithValue("@DESCRIPCION", contrato.DESCRIPCION);
            comando.Parameters.AddWithValue("@CONTACTO", contrato.CONTACTO);
            comando.Parameters.AddWithValue("@FECHA_INICIO", contrato.FECHA_INICIO);
            comando.Parameters.AddWithValue("@FECHA_VENCE", contrato.FECHA_VENCE);
            comando.Parameters.AddWithValue("@USUARIO", contrato.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", contrato.FECHA_CREACION);
            comando.Parameters.AddWithValue("@TIPO_CONTRATO", contrato.TIPO_CONTRATO);
            comando.Parameters.AddWithValue("@CLIENTE", contrato.CLIENTE);
            comando.Parameters.AddWithValue("@HORAS", contrato.HORAS);
            comando.Parameters.AddWithValue("@MONTO", contrato.MONTO);
            comando.Parameters.AddWithValue("@RANGO", contrato.RANGO);

            //result = comando.ExecuteNonQuery();
            result = Convert.ToInt32(comando.ExecuteScalar());
            return result;
        }

        public List<Servicio> Listar_Servicios_Contrato(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            List<Servicio> servicios = new List<Servicio>();

            comando.CommandText = "exec PA_CON_LISTAR_SERVICIOS_CONTRATO @ID_CONTRATO";
            comando.Parameters.AddWithValue("@ID_CONTRATO", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Servicio ser = new Servicio();
                ser.ID_SERVICIO = list.GetInt32(0);
                ser.DESCRIPCION = list.GetString(1);
                servicios.Add(ser);
            }
            list.Dispose();
            comando.Dispose();

            return servicios;
        }

        public int ModificarContrato(Contrato contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ACTUALIZAR_CONTRATO @ID_CONTRATO, @NOMBRE, @DESCRIPCION, @CONTACTO, @FECHA_INICIO, @FECHA_VENCE, @USUARIO, @FECHA, @TIPO_CONTRATO, @CLIENTE, @HORAS, @MONTO, @RANGO";
            comando.Parameters.AddWithValue("@ID_CONTRATO", contrato.ID_CONTRATO);
            comando.Parameters.AddWithValue("@NOMBRE", contrato.NOMBRE_CONTRATO);
            comando.Parameters.AddWithValue("@DESCRIPCION", contrato.DESCRIPCION);
            comando.Parameters.AddWithValue("@CONTACTO", contrato.CONTACTO);
            comando.Parameters.AddWithValue("@FECHA_INICIO", contrato.FECHA_INICIO);
            comando.Parameters.AddWithValue("@FECHA_VENCE", contrato.FECHA_VENCE);
            comando.Parameters.AddWithValue("@USUARIO", contrato.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", contrato.FECHA_CREACION);
            comando.Parameters.AddWithValue("@TIPO_CONTRATO", contrato.TIPO_CONTRATO);
            comando.Parameters.AddWithValue("@CLIENTE", contrato.CLIENTE);
            comando.Parameters.AddWithValue("@HORAS", contrato.HORAS);
            comando.Parameters.AddWithValue("@MONTO", contrato.MONTO);
            comando.Parameters.AddWithValue("@RANGO", contrato.RANGO);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public int QuitarServiciosContrato(int id) {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_QUITAR_SERVICIOS_CONTRATO @ID_CONTRATO";
            comando.Parameters.AddWithValue("@ID_CONTRATO", id);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public int ModificarServiciosContrato(List<Servicio_Contrato> servicios)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            /*comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_QUITAR_SERVICIOS_CONTRATO @ID_CONTRATO";
            comando.Parameters.AddWithValue("@ID_CONTRATO", servicios[0].ID_CONTRATO);
            comando.ExecuteNonQuery();*/
            QuitarServiciosContrato(servicios[0].ID_CONTRATO);

            foreach (Servicio_Contrato dato in servicios)
            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "execute PA_MAN_AGREGAR_SERVICIOS_CONTRATO @ID_CONTRATO, @ID_SERVICIOS, @USUARIO, @FECHA";
                comando.Parameters.AddWithValue("@ID_CONTRATO", dato.ID_CONTRATO);
                comando.Parameters.AddWithValue("@ID_SERVICIOS", dato.ID_SERVICIO);
                comando.Parameters.AddWithValue("@USUARIO", dato.USUARIO_CREACION);
                comando.Parameters.AddWithValue("@FECHA", dato.FECHA_CREACION);

                result = comando.ExecuteNonQuery();
            }

            return result;
        }

        public int AgregarServiciosContrato(List<Servicio_Contrato> servicios)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            QuitarServiciosContrato(servicios[0].ID_CONTRATO);

            foreach (Servicio_Contrato dato in servicios){                

                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "execute PA_MAN_AGREGAR_SERVICIOS_CONTRATO @ID_CONTRATO, @ID_SERVICIOS, @USUARIO, @FECHA";
                comando.Parameters.AddWithValue("@ID_CONTRATO", dato.ID_CONTRATO);
                comando.Parameters.AddWithValue("@ID_SERVICIOS", dato.ID_SERVICIO);
                comando.Parameters.AddWithValue("@USUARIO", dato.USUARIO_CREACION);
                comando.Parameters.AddWithValue("@FECHA", dato.FECHA_CREACION);

                result = comando.ExecuteNonQuery();
            }

            return result;
        }

        public int ActualizarEstadoDeshabilitarContrato(Contrato contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_DESHABILITAR_CONTRATO @PK_ID_TIPO_CONTRATO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_TIPO_CONTRATO", contrato.ID_CONTRATO);
            comando.Parameters.AddWithValue("@USUARIO", contrato.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", contrato.FECHA_MODIFICACION);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public int ActualizarEstadoHabilitarContrato(Contrato contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_HABILITAR_CONTRATO @PK_ID_TIPO_CONTRATO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_TIPO_CONTRATO", contrato.ID_CONTRATO);
            comando.Parameters.AddWithValue("@USUARIO", contrato.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", contrato.FECHA_MODIFICACION);

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

        public Contrato devuelve_contrato(int id)
        {
            Contrato contrato = new Contrato();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_CON_DEVUELVE_CONTRATO @ID";
            comando.Parameters.AddWithValue("@ID", id);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contrato = new Contrato();
                contrato.ID_CONTRATO = list.GetInt32(0);
                contrato.CLIENTE = list.GetInt32(1);
                contrato.NOMBRE_CONTRATO = list.GetString(2);
                contrato.DESCRIPCION = list.GetString(3);
                contrato.CONTACTO = list.GetInt32(4);
                contrato.FECHA_INICIO = list.GetDateTime(5);
                contrato.FECHA_VENCE = list.GetDateTime(6);
                contrato.TIPO_CONTRATO = list.GetInt32(7);
                contrato.HORAS = list.GetDouble(8);
                contrato.MONTO = list.GetInt32(9);
                contrato.RANGO = list.GetInt32(10);
            }
            list.Dispose();
            comando.Dispose();
            return contrato;
        }

    }
}
