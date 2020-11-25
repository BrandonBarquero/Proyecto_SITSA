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
    public partial class Man_Tabla_Configuracion : System.Web.UI.Page
    {

        List<Tabla_Configuracion> list = new List<Tabla_Configuracion>();

        public Permiso_e Permisos;
        Tabla_ConfiguracionDAO dao_conf = new Tabla_ConfiguracionDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

            int perfil = (int)(Session["perfil"]);
            Permisos = dao_conf.ControlPaginas("Tabla Configuracion", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }

        }

        public List<Tabla_Configuracion> ListaConfiguracion()
        {

            Tabla_ConfiguracionDAO dao = new Tabla_ConfiguracionDAO();

            list = dao.listaTabla_Configuracion();


            return list;
        }
    }
}