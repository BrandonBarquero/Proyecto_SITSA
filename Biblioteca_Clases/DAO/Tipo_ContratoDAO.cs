using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class Tipo_ContratoDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Tipo_ContratoDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Tipo_Contrato> listaTipoContratos()
        {
            List<Tipo_Contrato> listaTipoContrato = new List<Tipo_Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CON_LISTAR_TIPO_CONTRATO]";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Tipo_Contrato tipo_Contrato = new Tipo_Contrato();
                tipo_Contrato.ID_TIPO_CONTRATO = list.GetInt32(0);
                tipo_Contrato.NOMBRE = list.GetString(1);
                tipo_Contrato.ESTADO = list.GetInt32(2);
                tipo_Contrato.HORAS = list.GetBoolean(3);
                tipo_Contrato.RANGO_DOCUMENTOS = list.GetBoolean(4);
                tipo_Contrato.MONTO = list.GetBoolean(5);
                tipo_Contrato.ACEPTACION = list.GetBoolean(6);
                listaTipoContrato.Add(tipo_Contrato);
            }
            list.Dispose();
            comando.Dispose();
            return listaTipoContrato;

        }

        public List<Tipo_Contrato> listaTipoContratosActivos()
        {
            List<Tipo_Contrato> listaTipoContrato = new List<Tipo_Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_TIPO_CONTRATO_ACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Tipo_Contrato tipo_Contrato = new Tipo_Contrato();
                tipo_Contrato.ID_TIPO_CONTRATO = list.GetInt32(0);
                tipo_Contrato.NOMBRE = list.GetString(1);
                tipo_Contrato.ESTADO = list.GetInt32(2);
                tipo_Contrato.HORAS = list.GetBoolean(3);
                tipo_Contrato.RANGO_DOCUMENTOS = list.GetBoolean(4);
                tipo_Contrato.MONTO = list.GetBoolean(5);
                tipo_Contrato.ACEPTACION = list.GetBoolean(6);
                listaTipoContrato.Add(tipo_Contrato);
            }
            list.Dispose();
            comando.Dispose();
            return listaTipoContrato;

        }

        public List<Tipo_Contrato> listaTipoContratosInactivos()
        {
            List<Tipo_Contrato> listaTipoContrato = new List<Tipo_Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_TIPO_CONTRATO_INACTIVO";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Tipo_Contrato tipo_Contrato = new Tipo_Contrato();
                tipo_Contrato.ID_TIPO_CONTRATO = list.GetInt32(0);
                tipo_Contrato.NOMBRE = list.GetString(1);
                tipo_Contrato.ESTADO = list.GetInt32(2);
                tipo_Contrato.HORAS = list.GetBoolean(3);
                tipo_Contrato.RANGO_DOCUMENTOS = list.GetBoolean(4);
                tipo_Contrato.MONTO = list.GetBoolean(5);
                tipo_Contrato.ACEPTACION = list.GetBoolean(6);
                listaTipoContrato.Add(tipo_Contrato);
            }
            list.Dispose();
            comando.Dispose();
            return listaTipoContrato;

        }

        public Tipo_Contrato listar_TipoContrato(int id)
        {
            Tipo_Contrato tipo_Contrato = new Tipo_Contrato();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CON_LISTAR_MAN_TIPO_CONTRATO_FILTRADO @PK_ID_TIPO_CONTRATO";
            comando.Parameters.AddWithValue("@PK_ID_TIPO_CONTRATO", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                tipo_Contrato.ID_TIPO_CONTRATO = list.GetInt32(0);
                tipo_Contrato.NOMBRE = list.GetString(1);
                tipo_Contrato.ESTADO = list.GetInt32(2);
                tipo_Contrato.HORAS = list.GetBoolean(3);
                tipo_Contrato.RANGO_DOCUMENTOS = list.GetBoolean(4);
                tipo_Contrato.MONTO = list.GetBoolean(5);
                tipo_Contrato.ACEPTACION = list.GetBoolean(6);
            }

            list.Dispose();
            comando.Dispose();

            return tipo_Contrato;
        }

        public int ActualizarEstadoHabilitarTipoContrato(Tipo_Contrato tipo_Contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_HABILITAR_TIPO_CONTRATO @PK_ID_TIPO_CONTRATO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_TIPO_CONTRATO", tipo_Contrato.ID_TIPO_CONTRATO);
            comando.Parameters.AddWithValue("@USUARIO", tipo_Contrato.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", tipo_Contrato.FECHA_MODIFICACION);

            result = comando.ExecuteNonQuery();
            comando.Dispose();

            return result;
        }

        public int ActualizarEstadoDeshabilitarTipoContrato(Tipo_Contrato tipo_Contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_DESHABILITAR_TIPO_CONTRATO @PK_ID_TIPO_CONTRATO,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_TIPO_CONTRATO", tipo_Contrato.ID_TIPO_CONTRATO);
            comando.Parameters.AddWithValue("@USUARIO", tipo_Contrato.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", tipo_Contrato.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();
            comando.Dispose();

            return result;
        }

        public int AgregarTipoContrato(Tipo_Contrato tipo_Contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_AGREGAR_TIPO_CONTRATO @NOMBRE, @HORAS, @RANGO_DOCUMENTOS, @MONTO, @ACEPTACION, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@NOMBRE", tipo_Contrato.NOMBRE);
            comando.Parameters.AddWithValue("@HORAS", tipo_Contrato.HORAS);
            comando.Parameters.AddWithValue("@RANGO_DOCUMENTOS", tipo_Contrato.RANGO_DOCUMENTOS);
            comando.Parameters.AddWithValue("@MONTO", tipo_Contrato.MONTO);
            comando.Parameters.AddWithValue("@ACEPTACION", tipo_Contrato.ACEPTACION);
            comando.Parameters.AddWithValue("@USUARIO", tipo_Contrato.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", tipo_Contrato.FECHA_CREACION);

            result = comando.ExecuteNonQuery();
            comando.Dispose();

            return result;
        }

        public int ModificarTipoContrato(Tipo_Contrato tipo_Contrato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ACTUALIZAR_TIPO_CONTRATO @ID, @NOMBRE, @HORAS, @RANGO_DOCUMENTOS, @MONTO, @ACEPTACION, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@ID", tipo_Contrato.ID_TIPO_CONTRATO);
            comando.Parameters.AddWithValue("@NOMBRE", tipo_Contrato.NOMBRE);
            comando.Parameters.AddWithValue("@HORAS", tipo_Contrato.HORAS);
            comando.Parameters.AddWithValue("@RANGO_DOCUMENTOS", tipo_Contrato.RANGO_DOCUMENTOS);
            comando.Parameters.AddWithValue("@MONTO", tipo_Contrato.MONTO);
            comando.Parameters.AddWithValue("@ACEPTACION", tipo_Contrato.ACEPTACION);
            comando.Parameters.AddWithValue("@USUARIO", tipo_Contrato.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", tipo_Contrato.FECHA_MODIFICACION);

            result = comando.ExecuteNonQuery();
            comando.Dispose();

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
    }
}
