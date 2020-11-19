using Biblioteca_Clases.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Control_Visitas
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CargarMenu();
        }






        LoginDAO dao = new LoginDAO();




        private void CargarMenu()
        {
            try
            {
                Biblioteca_Clases.Models.Menu obMenuE = new Biblioteca_Clases.Models.Menu();
                MenuDAO obMenuL = new MenuDAO();
                // string usuarioLogin = (Session["LoginCRM"] as UsuarioE).PK_Usuario;


                List<Biblioteca_Clases.Models.Menu> listaMenuPadre = new List<Biblioteca_Clases.Models.Menu>();
                List<Biblioteca_Clases.Models.Menu> listaMenuHijos = new List<Biblioteca_Clases.Models.Menu>();
                List<Biblioteca_Clases.Models.Menu> listaMenu = new List<Biblioteca_Clases.Models.Menu>();

                LoginDAO dao = new LoginDAO();
                string Nombre = (string)(Session["User"]);
                int dato = dao.consultausuarioperfil(Nombre);

                listaMenu = obMenuL.consultamenu(dato, 1);

                listaMenuPadre = listaMenu.ToList().Where(x => x.CODIGO_PADRE == "0").ToList();

                MenuPrincipal.InnerHtml =
                  "<li class='nav - item'> <a class='nav-link' href='Home.aspx'><i class='fa fa-home'></i>&nbsp; Inicio<span class='sr-only'></span></a></li>";


                foreach (Biblioteca_Clases.Models.Menu iMenu in listaMenuPadre)
                {
                    listaMenuHijos = listaMenu.ToList().Where(x => x.CODIGO_PADRE == iMenu.PK_ID_MENU.ToString()).ToList();

                    if (listaMenuHijos.Count <= 0)
                    {
                        if (iMenu.CODIGO_PADRE == "0")
                        {
                            MenuPrincipal.InnerHtml +=
                       "<li class='nav - item'> <a class='nav-link' href='" + iMenu.URL + "'><i class='" + iMenu.ICONO + "'></i>&nbsp; " + iMenu.DESCRIPCION + "<span class='sr-only'></span></a></li>";
                        }
                    }
                    else
                    {
                        /*MENU HIJOS*/
                        if (iMenu.CODIGO_PADRE == "0")
                        {
                            MenuPrincipal.InnerHtml += "<li class='dropdown'>";
                            MenuPrincipal.InnerHtml += "<a class='nav-link dropdown-toggle'  id='ND" + iMenu.DESCRIPCION + "' role='button' "
                              + "data-toggle = 'dropdown' aria-haspopup = 'true' aria-expanded = 'false' > " +
                              " <i class='" + iMenu.ICONO + "' aria-hidden='true'></i>&nbsp;" + iMenu.DESCRIPCION + " </a>";
                            MenuPrincipal.InnerHtml += "<ul class='dropdown-menu' aria-labelledby='ND" + iMenu.DESCRIPCION + "'>";
                        }

                        foreach (Biblioteca_Clases.Models.Menu iMenuHijos in listaMenuHijos)
                        {
                            ObtenerSubMenus(iMenuHijos, listaMenu);
                        }

                        if (iMenu.CODIGO_PADRE == "0")
                        {
                            MenuPrincipal.InnerHtml += "</ul>";
                            MenuPrincipal.InnerHtml += "</li>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string mesage = ex.Message;
                throw;
            }

        }

        private void ObtenerSubMenus(Biblioteca_Clases.Models.Menu pMenuHijos, List<Biblioteca_Clases.Models.Menu> plistaMenu)
        {
            try
            {
                List<Biblioteca_Clases.Models.Menu> listaMenuHijos = new List<Biblioteca_Clases.Models.Menu>();
                List<Biblioteca_Clases.Models.Menu> listaMenuTieneHijos = new List<Biblioteca_Clases.Models.Menu>();
                List<Biblioteca_Clases.Models.Menu> listaMenu = plistaMenu;

                listaMenuHijos = listaMenu.ToList().Where(x => x.CODIGO_PADRE == pMenuHijos.PK_ID_MENU.ToString()).ToList();
                if (listaMenuHijos.Count == 0)
                {
                    MenuPrincipal.InnerHtml += "<li><a class='nav-link' href='" + pMenuHijos.URL + "'><i class='" + pMenuHijos.ICONO + "'></i>&nbsp;" + pMenuHijos.DESCRIPCION + "</a></li>";
                    return;
                }

                MenuPrincipal.InnerHtml += "<li class='dropdown'>";
                MenuPrincipal.InnerHtml += "<a class='nav-link dropdown-toggle'  id='ND" + pMenuHijos.DESCRIPCION + "' role='button' "
                          + "data-toggle = 'dropdown' aria-haspopup = 'true' aria-expanded = 'false' > " +
                          " <i class='" + pMenuHijos.ICONO + "' aria-hidden='true'></i>&nbsp;" + pMenuHijos.DESCRIPCION + " </a>";
                MenuPrincipal.InnerHtml += "<ul class='dropdown-menu' aria-labelledby='ND" + pMenuHijos.DESCRIPCION + "'>";

                foreach (Biblioteca_Clases.Models.Menu iMenuHijos in listaMenuHijos)
                {
                    ObtenerSubMenus(iMenuHijos, listaMenu);
                }

                MenuPrincipal.InnerHtml += "</ul>";
                MenuPrincipal.InnerHtml += "</li>";

            }
            catch (Exception ex)
            {
                string mesage = ex.Message;
                throw;
            }
        }

    }
}