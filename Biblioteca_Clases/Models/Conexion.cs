using System;
using System.Data.SqlClient;

namespace Biblioteca_Clases.Models
{
    public class Conexion
    {
        private static SqlConnection objConexion;
        private static string error;

        public Conexion() { }
        public static SqlConnection getConexion()
        {
            if (objConexion != null)
            {
                return objConexion;
            }
            objConexion = new SqlConnection();
            objConexion.ConnectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=SITSA ;User ID=test;Password=root;";
            try
            {
                objConexion.Open();
                return objConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }
        public static void cerrarConexion()
        {
            if (objConexion != null)
            {
                objConexion.Close();
            }
        }
    }
}
