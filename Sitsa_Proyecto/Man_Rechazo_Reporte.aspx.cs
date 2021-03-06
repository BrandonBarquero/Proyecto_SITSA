﻿using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitsa_Proyecto
{
    public partial class Man_Rechazo_Reporte : System.Web.UI.Page
    {
        List<Rechazo_Reporte> list = new List<Rechazo_Reporte>();

        public Permiso_e Permisos;
        Rechazo_ReporteDAO dao = new Rechazo_ReporteDAO();
        ProyectoDAO dao_proyecto = new ProyectoDAO();


        protected void Page_Load(object sender, EventArgs e)
        {

            int perfil = (int)(Session["perfil"]);
            Permisos = dao_proyecto.ControlPaginas("Rechazos", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }

        }

        public List<Rechazo_Reporte> ListaReportes_Rechazados()
        {

            Rechazo_ReporteDAO dao = new Rechazo_ReporteDAO();

            list = dao.listaReportesRechazados();


            return list;
        }


       


}
}
