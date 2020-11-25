using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Control_Visitas.Controllers;
using System;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class Man_Usuario : System.Web.UI.Page
    {
        DefaultController controller = new DefaultController();
        public Permiso_e Permisos;
        ServicioDAO dao_servicio = new ServicioDAO();
        PerfilDAO dao_perfil = new PerfilDAO();

        List<Usuario> list = new List<Usuario>();


        protected void Page_Load(object sender, EventArgs e)
        {



            int perfil = (int)(Session["perfil"]);
            Permisos = dao_servicio.ControlPaginas("Usuarios", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }


        }
        public List<Usuario> lista1()
        {

            UsuarioDAO dao = new UsuarioDAO();

            List<Usuario> list = dao.listausuarios();
            return list;
        }

        public List<Perfil> lista_perfiles()
        {

            PerfilDAO dao = new PerfilDAO();

            List<Perfil> list = dao.consultaPerfiles();
            return list;
        }

        public List<Usuario> ListaUsuarios(string valor)
        {

            UsuarioDAO dao = new UsuarioDAO();


            if (valor == null || valor == "Todos_Usuario")
            {
                list = dao.ListaUsuariosGeneral();
            }
            if (valor == "Activo_Usuario")
            {
                list = dao.ListaUsuariosActivos();
            }
            if (valor == "Inactivo_Usuario")
            {
                list = dao.ListaUsuariosInactivos();
            }

            return list;
        }


    }
}