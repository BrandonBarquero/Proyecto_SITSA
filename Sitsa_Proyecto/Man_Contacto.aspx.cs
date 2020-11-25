using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class Man_Contacto : System.Web.UI.Page
    {

        List<Contacto> list = new List<Contacto>();

        public Permiso_e Permisos;
        ContactoDAO dao_contacto = new ContactoDAO();


        protected void Page_Load(object sender, EventArgs e)
        {

            int perfil = (int)(Session["perfil"]);
            Permisos = dao_contacto.ControlPaginas("Contacto", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }

        }

        public List<Contacto> ListaContacto()
        {

            ContactoDAO dao = new ContactoDAO();

            list = dao.listaContactos();


            return list;
        }
    }
}