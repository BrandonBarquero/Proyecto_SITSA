using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.DAO
{
   public class Cierre_MesDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Cierre_MesDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Contacto> listaCorreos(string id)
        {
            List<Contacto> listacorreos = new List<Contacto>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_CORREOS_REPORTE @ID";
            comando.Parameters.AddWithValue("@ID", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contacto cont = new Contacto();
                cont.ENCARGADO = list.GetString(0);
                cont.CORREO = list.GetString(1);
                listacorreos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listacorreos;

        }


        public int Cambiar_Estado_Reenvio(int dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_ACTUALIZAR_REENVIO_REPORTE] @PK_ID_REPORTE";
            comando.Parameters.AddWithValue("@PK_ID_REPORTE", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Eliminar_Cierre_Mes(int dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_ELIMINAR_CIERRE_MES] @FK_ID_REPORTE";
            comando.Parameters.AddWithValue("@FK_ID_REPORTE", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int AgregarCierreMes(int FK_ID_REPORTE, string usuario, string fecha)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_INSERTAR_CIERRE_MES @USUARIO, @FECHA, @FK_ID_REPORTE";
            comando.Parameters.AddWithValue("@USUARIO", usuario);
            comando.Parameters.AddWithValue("@FECHA", fecha);
            comando.Parameters.AddWithValue("@FK_ID_REPORTE", FK_ID_REPORTE);


            result = comando.ExecuteNonQuery();

            return result;

        }
    }
}
