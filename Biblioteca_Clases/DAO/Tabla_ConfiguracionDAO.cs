using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.DAO
{
  public  class Tabla_ConfiguracionDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Tabla_ConfiguracionDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Tabla_Configuracion> listaTabla_Configuracion()
        {
            List<Tabla_Configuracion> listaConfiguracion = new List<Tabla_Configuracion>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_LISTAR_TABLA_CONFIGURACION";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Tabla_Configuracion cont = new Tabla_Configuracion();
                cont.ESTADO = list.GetInt16(0);
                cont.CONSECUTIVO = list.GetInt16(1);
                cont.DESCRIPCION = list.GetString(2);
                cont.OBSERVACION = list.GetString(3);
                cont.LLAVE01 = list.GetString(4);
                cont.LLAVE02 = list.GetString(5);
                cont.LLAVE03 = list.GetString(6);
                cont.LLAVE04 = list.GetString(7);
                cont.LLAVE05 = list.GetString(8);
                cont.LLAVE06 = list.GetString(9);
                cont.VALOR = list.GetString(10);
                cont.FK_LLAVE_FORANEA = list.GetInt64(11);
                cont.ESTRUCTURA = list.GetString(12);
                cont.GUI_RELACION = list.GetString(13);
                cont.PK_TBL_CONFIG = list.GetInt64(14);
                listaConfiguracion.Add(cont);
                
            }
            list.Dispose();
            comando.Dispose();
            return listaConfiguracion;

        }

        public int AgregarTabla_Configuracion(Tabla_Configuracion cont)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_AGREGAR_TABLA_CONFIGURACION @FK_TBL_CTRL_REG_CONFIGURACION, @USUARIO, @FECHA, @ESTADO, @CONSECUTIVO, @DESCRIPCION, @OBSERVACION, @LLAVE01, @LLAVE02, @LLAVE03, @LLAVE04, @LLAVE05, @LLAVE06, @VALOR, @FK_LLAVE_FORANEA, @ESTRUCTURA, @GUI_RELACION";
            comando.Parameters.AddWithValue("@FK_TBL_CTRL_REG_CONFIGURACION", 0);
            comando.Parameters.AddWithValue("@USUARIO", cont.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", cont.FECHA_CREACION);
            comando.Parameters.AddWithValue("@ESTADO", cont.ESTADO);
            comando.Parameters.AddWithValue("@CONSECUTIVO", cont.CONSECUTIVO);
            comando.Parameters.AddWithValue("@DESCRIPCION", cont.DESCRIPCION);
            comando.Parameters.AddWithValue("@OBSERVACION", cont.OBSERVACION);
            comando.Parameters.AddWithValue("@LLAVE01", cont.LLAVE01);
            comando.Parameters.AddWithValue("@LLAVE02", cont.LLAVE02);
            comando.Parameters.AddWithValue("@LLAVE03", cont.LLAVE03);
            comando.Parameters.AddWithValue("@LLAVE04", cont.LLAVE04);
            comando.Parameters.AddWithValue("@LLAVE05", cont.LLAVE05);
            comando.Parameters.AddWithValue("@LLAVE06", cont.LLAVE06);
            comando.Parameters.AddWithValue("@VALOR", cont.VALOR);
            comando.Parameters.AddWithValue("@FK_LLAVE_FORANEA", cont.FK_LLAVE_FORANEA);
            comando.Parameters.AddWithValue("@ESTRUCTURA", cont.ESTRUCTURA);
            comando.Parameters.AddWithValue("@GUI_RELACION", cont.GUI_RELACION);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int ActualizarTabla_Configuracion(Tabla_Configuracion cont)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTUALIZAR_TABLA_CONFIGURACION @FK_TBL_CTRL_REG_CONFIGURACION, @USUARIO, @FECHA, @ESTADO, @CONSECUTIVO, @DESCRIPCION, @OBSERVACION, @LLAVE01, @LLAVE02, @LLAVE03, @LLAVE04, @LLAVE05, @LLAVE06, @VALOR, @FK_LLAVE_FORANEA, @ESTRUCTURA, @GUI_RELACION, @PK_TBL_CONFIG";


            comando.Parameters.AddWithValue("@FK_TBL_CTRL_REG_CONFIGURACION", 0);
            comando.Parameters.AddWithValue("@USUARIO", cont.USUARIO_MODIFICACION); 
            comando.Parameters.AddWithValue("@FECHA", cont.FECHA_MODIFICACION);
            if (cont.ESTADO != 0) {comando.Parameters.AddWithValue("@ESTADO", cont.ESTADO); } else { comando.Parameters.AddWithValue("@ESTADO", " "); }; 
            if (cont.CONSECUTIVO != 0) {comando.Parameters.AddWithValue("@CONSECUTIVO", cont.CONSECUTIVO); } else { comando.Parameters.AddWithValue("@CONSECUTIVO", " "); }; 
            if (cont.DESCRIPCION != null) {comando.Parameters.AddWithValue("@DESCRIPCION", cont.DESCRIPCION); } else { comando.Parameters.AddWithValue("@DESCRIPCION", " "); }; 
            if (cont.OBSERVACION != null) {comando.Parameters.AddWithValue("@OBSERVACION", cont.OBSERVACION); } else { comando.Parameters.AddWithValue("@OBSERVACION", " "); }; 
            if (cont.LLAVE01 != null) {comando.Parameters.AddWithValue("@LLAVE01", cont.LLAVE01); } else { comando.Parameters.AddWithValue("@LLAVE01", " "); };
            if (cont.LLAVE02 != null) {comando.Parameters.AddWithValue("@LLAVE02", cont.LLAVE02); } else { comando.Parameters.AddWithValue("@LLAVE02", " "); }; 
            if (cont.LLAVE03 != null) {comando.Parameters.AddWithValue("@LLAVE03", cont.LLAVE03); } else { comando.Parameters.AddWithValue("@LLAVE03", " "); }; 
            if (cont.LLAVE04 != null) {comando.Parameters.AddWithValue("@LLAVE04", cont.LLAVE04); } else { comando.Parameters.AddWithValue("@LLAVE04", " "); }; 
            if (cont.LLAVE05 != null) {comando.Parameters.AddWithValue("@LLAVE05", cont.LLAVE05); } else { comando.Parameters.AddWithValue("@LLAVE05", " "); }; 
            if (cont.LLAVE06 != null) {comando.Parameters.AddWithValue("@LLAVE06", cont.LLAVE06); } else { comando.Parameters.AddWithValue("@LLAVE06", " "); }; 
            if (cont.VALOR != null) {comando.Parameters.AddWithValue("@VALOR", cont.VALOR); } else { comando.Parameters.AddWithValue("@VALOR", " "); }; 
            if (cont.FK_LLAVE_FORANEA != 0) {comando.Parameters.AddWithValue("@FK_LLAVE_FORANEA", cont.FK_LLAVE_FORANEA); } else { comando.Parameters.AddWithValue("@FK_LLAVE_FORANEA", " "); }; 
            if (cont.ESTRUCTURA != null) {comando.Parameters.AddWithValue("@ESTRUCTURA", cont.ESTRUCTURA); } else { comando.Parameters.AddWithValue("@ESTRUCTURA", " "); }; 
            if (cont.GUI_RELACION != null) {comando.Parameters.AddWithValue("@GUI_RELACION", cont.GUI_RELACION); } else { comando.Parameters.AddWithValue("@GUI_RELACION", " "); }; 
            if (cont.PK_TBL_CONFIG != 0) {comando.Parameters.AddWithValue("@PK_TBL_CONFIG", cont.PK_TBL_CONFIG); } else { comando.Parameters.AddWithValue("@PK_TBL_CONFIG", " "); }; 

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int EliminarTabla(int dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_ELIMINAR_TABLA_CONFIGURACION] @PK_ID_TABLA";
            comando.Parameters.AddWithValue("@PK_ID_TABLA", dato);

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


        public List<Tabla_Configuracion> Correo_Configuracion()
        {
            List<Tabla_Configuracion> listaConfiguracion = new List<Tabla_Configuracion>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CTRL_LISTAR_MAN_CONFIGURACION_CORREO]";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Tabla_Configuracion cont = new Tabla_Configuracion();
                cont.ESTADO = list.GetInt16(0);
                cont.CONSECUTIVO = list.GetInt16(1);
                cont.DESCRIPCION = list.GetString(2);
                cont.OBSERVACION = list.GetString(3);
                cont.LLAVE01 = list.GetString(4);
                cont.LLAVE02 = list.GetString(5);
                cont.LLAVE03 = list.GetString(6);
                cont.LLAVE04 = list.GetString(7);
                cont.LLAVE05 = list.GetString(8);
                cont.LLAVE06 = list.GetString(9);
                cont.VALOR = list.GetString(10);
                cont.FK_LLAVE_FORANEA = list.GetInt64(11);
                cont.ESTRUCTURA = list.GetString(12);
                cont.GUI_RELACION = list.GetString(13);
                cont.PK_TBL_CONFIG = list.GetInt64(14);
                listaConfiguracion.Add(cont);

            }
            list.Dispose();
            comando.Dispose();
            return listaConfiguracion;

        }
    }

}
