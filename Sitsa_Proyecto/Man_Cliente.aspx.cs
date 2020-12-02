using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication2
{
    public partial class Man_Cliente : System.Web.UI.Page
    {

        public Permiso_e Permisos;
        ClienteDAO dao_cliente = new ClienteDAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            int perfil = (int)(Session["perfil"]);
            Permisos = dao_cliente.ControlPaginas("Cliente", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }

        }

    }
}