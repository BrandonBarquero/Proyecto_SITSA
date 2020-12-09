using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class Fase_TiempoDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Fase_TiempoDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int AgregarFase_Tiempo(Fase_Tiempo fase, int id_proyecto, string usuario, string fecha)
        {
            int result = 0;

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_AGREGAR_FASE_TIEMPO @DESCRIPCION, @TIEMPO,@USUARIO, @FECHA, @FK_ID_PROYECTO, @ESTADO";

            comando.Parameters.AddWithValue("@DESCRIPCION", fase.DESCRIPCION);
            comando.Parameters.AddWithValue("@TIEMPO", fase.TIEMPO);
            comando.Parameters.AddWithValue("@USUARIO", usuario);
            comando.Parameters.AddWithValue("@FECHA", fecha);
            comando.Parameters.AddWithValue("@FK_ID_PROYECTO", id_proyecto);
            comando.Parameters.AddWithValue("@ESTADO", 1);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Fase_Tiempo> Listar_Fase_Tiempo_Filtrado(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            List<Fase_Tiempo> fases = new List<Fase_Tiempo>();

            comando.CommandText = "exec PA_CTRL_REG_LISTAR_FASE_TIEMPO @FK_ID_PROYECTO";
            comando.Parameters.AddWithValue("@FK_ID_PROYECTO", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Fase_Tiempo fase = new Fase_Tiempo();
                fase.ID_FASE = list.GetInt32(0);
                fase.DESCRIPCION = list.GetString(1);
                fase.TIEMPO = list.GetDouble(2);
                fases.Add(fase);
            }
            list.Dispose();
            comando.Dispose();

            return fases;
        }

        public int ActualizarEstadoDeshabilitarFase(Fase_Tiempo fase)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_DESHABILITAR_FASE_TIEMPO @PK_ID_FASE,@USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@PK_ID_FASE", fase.ID_FASE);
            comando.Parameters.AddWithValue("@USUARIO", fase.USUARIO_MODIFICACION);
            comando.Parameters.AddWithValue("@FECHA", fase.FECHA_MODIFICACION);


            result = comando.ExecuteNonQuery();

            return result;

        }
        public int EliminarFase(int dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_ELIMINAR_FASE_TIEMPO] @PK_ID_CONTACTO";
            comando.Parameters.AddWithValue("@PK_ID_CONTACTO", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }


    }
}