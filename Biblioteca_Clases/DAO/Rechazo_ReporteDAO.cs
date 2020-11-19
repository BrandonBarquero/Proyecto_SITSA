using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class Rechazo_ReporteDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Rechazo_ReporteDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Rechazo_Reporte> listaReportesRechazados()
        {
            List<Rechazo_Reporte> listaReportesRechazados = new List<Rechazo_Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_LISTAR_RECHAZO_REPORTE";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Rechazo_Reporte cont = new Rechazo_Reporte();
                cont.FK_ID_REPORTE = list.GetInt32(0);
                cont.MOTIVO = list.GetString(1);
                listaReportesRechazados.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaReportesRechazados;

        }

    }
}