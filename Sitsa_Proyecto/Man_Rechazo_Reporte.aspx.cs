using Biblioteca_Clases.DAO;
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


        protected void Page_Load(object sender, EventArgs e)
        {



        }

        public List<Rechazo_Reporte> ListaReportes_Rechazados()
        {

            Rechazo_ReporteDAO dao = new Rechazo_ReporteDAO();

            list = dao.listaReportesRechazados();


            return list;
        }



    }
}
