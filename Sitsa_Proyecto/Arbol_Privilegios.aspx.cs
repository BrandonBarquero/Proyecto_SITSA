using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Menu = Biblioteca_Clases.Models.Menu;


namespace Control_Visitas
{
    public partial class Arbol_Provilegios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HabilitaOpcionesPermisos();
            if (!IsPostBack)
            {
                LlenarPerfiles();
                CargarTreeViewPermisos();
                tvPermisos.Attributes.Add("onclick", "postBackByObject()");
            }
        }
        private const int CHECKEAR_NODOS = 1;
        private const int DESCHECKEAR_NODOS = 2;

        //prueba

        public void LlenarPerfiles()
        {
            try
            {
                List<Perfil> listaPerfiles = new List<Perfil>();

                PerfilDAO dao = new PerfilDAO();

                listaPerfiles = dao.consultaPerfiles();

                if (listaPerfiles.Count > 0)
                {
                    ddlPerfiles.DataSource = listaPerfiles;
                    ddlPerfiles.DataValueField = "Pk_ID_PERFIL";
                    ddlPerfiles.DataTextField = "DESCRIPCION";
                    ddlPerfiles.DataBind();
                    ddlPerfiles.Items.Insert(0, new ListItem() { Text = "-- SELECCIONE EL PERFIL --", Value = "" });
                }
                else
                {
                    ddlPerfiles.DataSource = "";
                    ddlPerfiles.DataBind();
                    ddlPerfiles.Items.Insert(0, new ListItem() { Text = "-- SELECCIONE EL PERFIL --", Value = "" });
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
            }
        }

        protected void btnLimpiarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);

            }
        }
        private void EliminarNodosTreeView()
        {
            tvPermisos.Nodes.Clear();
            tvPermisos.ExpandAll();

        }

        private void CargarTreeViewPermisos()
        {
            try
            {
                TreeNode nodoMenu;


                List<Menu> listaMenu = new List<Menu>();
                MenuDAO dao2 = new MenuDAO();


                int FK_TBL_CRM_SEG_PERFIL = string.IsNullOrEmpty(ddlPerfiles.SelectedValue) ? 0 : Convert.ToInt32(ddlPerfiles.SelectedValue);

                listaMenu = dao2.consultamenuperfil(FK_TBL_CRM_SEG_PERFIL, "1");



                List<Menu> listaMenuPadre = listaMenu.ToList().Where(x => x.CODIGO_PADRE == "0").ToList();

                foreach (Menu iMenu in listaMenuPadre)
                {
                    nodoMenu = new TreeNode();
                    nodoMenu.Text = "&nbsp;<span><i class='" + iMenu.ICONO + "' aria-hidden='true'></i> &nbsp;" + iMenu.DESCRIPCION + "</span>";

                    nodoMenu.Value = "menu-" + iMenu.PK_ID_MENU; // valor para identificar que el nodo pertenece a un menu
                    nodoMenu.ShowCheckBox = true;
                    nodoMenu.Checked = iMenu.ESTADO_PERMISO ? true : false;

                    ObtenerPermisos(nodoMenu,
                      iMenu.CREAR_MENU,
                      iMenu.EDITAR_MENU,
                      iMenu.VER_MENU,
                      iMenu.APROBACION_MENU,
                      iMenu.REENVIO_MENU,
                      iMenu.CREAR_PERMISO,
                      iMenu.EDITAR_PERMISO,
                      iMenu.VER_PERMISO,
                      iMenu.APROBACON_PERMISO,
                      iMenu.REENVIO_PERMISO,
                      iMenu.PK_ID_MENU
                      );

                    ObtenerSubmenus(nodoMenu, iMenu, listaMenu);

                    tvPermisos.Nodes.Add(nodoMenu);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);

            }

        }
        private int ObtenerNodosHermanosCheckeados(TreeNode nodoPadre)
        {
            int contNodosCheckeados = 0;

            foreach (TreeNode node in nodoPadre.ChildNodes)
            {
                if (node.Checked == true)
                {
                    contNodosCheckeados++;
                }
            }

            return contNodosCheckeados;

        }
        private string ObtenerIdsDeNodosCheckeados(string datoAContener = null) // dato para identificar cualesc a cuales nodos seleccionados se le van a obtener el valor
        {

            int size = tvPermisos.CheckedNodes.Count;
            TreeNode[] list = new TreeNode[size];
            tvPermisos.CheckedNodes.CopyTo(list, 0);

            string datosNodosPermisos = "";

            foreach (TreeNode nodo in list)
            {
                if (datoAContener != null)
                {
                    if (nodo.Value.Contains(datoAContener))
                    {
                        datosNodosPermisos += string.Format("{0},", // se utiliza la coma para separar cada uno de los permisos
                                                                    nodo.Value.Split('-')[1]);
                    }
                }
                else
                {
                    datosNodosPermisos += string.Format("{0},", // se utiliza la coma para separar cada uno de los permisos
                                                                    nodo.Value.Split('-')[1]);
                }



            }

            return datosNodosPermisos += "";
        }
        protected void btnAceptarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPerfiles.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
                    return;
                }

                PrivilegiosE obPrivilegiosE = new PrivilegiosE();
                PrivilegiosD obPrivilegiosL = new PrivilegiosD();
                // string Compania = (Session["Compañia"] as MetaTipoE).VALOR_DEFECTO;
                // string usuarioLogin = (Session["LoginCRM"] as UsuarioE).PK_Usuario;
                string result = "";

                string listaMenusSeleccionados = ObtenerIdsDeNodosCheckeados("menu");
                string listaPermisosSeleccionados = ObtenerIdsDeNodosCheckeados("permiso");

                obPrivilegiosE.OPCION = 0;
                obPrivilegiosE.USUARIO = "2";
                obPrivilegiosE.FK_TBL_CRM_SEG_PERFIL = Convert.ToInt32(ddlPerfiles.SelectedValue);
                obPrivilegiosE.LISTA_MENU = listaMenusSeleccionados;
                obPrivilegiosE.LISTA_PERMISOS = listaPermisosSeleccionados;

                result = obPrivilegiosL.InsertarPermisos(obPrivilegiosE);

                Limpiar();
                lblMensajeExito.Text = result;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalInfoExitosa", "AlertaExito()", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalInfoExitosa", "AlertaFallo()", true);

            }
        }

        public void Limpiar()
        {
            try
            {
                ddlPerfiles.SelectedValue = "";
                EliminarNodosTreeView();
                CargarTreeViewPermisos();
                tvPermisos.ExpandAll();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
            }
        }


        private void ObtenerPermisos(TreeNode nodo,
      bool CREAR_MENU,
      bool EDITAR_MENU,
      bool VER_MENU,
      bool APROBACION_MENU,
      bool REENVIO_MENU,
      bool CREAR_PERMISO,
      bool EDITAR_PERMISO,
      bool VER_PERMISO,
      bool APROBACION_PERMISO,
      bool REENVIO_PERMISO,
      int PK_ID_MENU
     )
        {
            try
            {
                if (CREAR_MENU)
                {
                    TreeNode nodoPermiso = new TreeNode();
                    nodoPermiso.Text = "<i class='fa fa-plus' aria-hidden='true'></i> &nbsp;<span>Crear </span>";
                    nodoPermiso.Value = "permiso-crear/" + PK_ID_MENU;
                    nodoPermiso.ShowCheckBox = true;
                    nodoPermiso.Checked = CREAR_PERMISO ? true : false;
                    nodo.ChildNodes.Add(nodoPermiso);
                }
                if (EDITAR_MENU)
                {
                    TreeNode nodoPermiso = new TreeNode();
                    nodoPermiso.Text = "<i class='fa fa-edit' aria-hidden='true'></i> &nbsp;<span>Editar </span>";
                    nodoPermiso.Value = "permiso-editar/" + PK_ID_MENU;
                    nodoPermiso.ShowCheckBox = true;
                    nodoPermiso.Checked = EDITAR_PERMISO ? true : false;
                    nodo.ChildNodes.Add(nodoPermiso);
                }
                if (VER_MENU)
                {
                    TreeNode nodoPermiso = new TreeNode();
                    nodoPermiso.Text = "<i class='fa fa-align-justify' aria-hidden='true'></i> &nbsp;<span>Ver </span>";
                    nodoPermiso.Value = "permiso-ver/" + PK_ID_MENU;
                    nodoPermiso.ShowCheckBox = true;
                    nodoPermiso.Checked = VER_PERMISO ? true : false;
                    nodo.ChildNodes.Add(nodoPermiso);
                }
                if (APROBACION_MENU)
                {
                    TreeNode nodoPermiso = new TreeNode();
                    nodoPermiso.Text = "<i class='fa fa-check' aria-hidden='true'></i> &nbsp;<span>Aprobacion </span>";
                    nodoPermiso.Value = "permiso-aprobacion/" + PK_ID_MENU;
                    nodoPermiso.ShowCheckBox = true;
                    nodoPermiso.Checked = APROBACION_PERMISO ? true : false;
                    nodo.ChildNodes.Add(nodoPermiso);
                }
                if (REENVIO_MENU)
                {
                    TreeNode nodoPermiso = new TreeNode();
                    nodoPermiso.Text = "<i class='fa fa-share' aria-hidden='true'></i> &nbsp;<span>Reenvio </span>";
                    nodoPermiso.Value = "permiso-reenvio/" + PK_ID_MENU;
                    nodoPermiso.ShowCheckBox = true;
                    nodoPermiso.Checked = REENVIO_PERMISO ? true : false;
                    nodo.ChildNodes.Add(nodoPermiso);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
            }
        }
        private void ObtenerSubmenus(TreeNode nodoPadre, Menu pMenuHijos, List<Menu> plistaMenu)
        {
            List<Menu> listaMenuHijos = new List<Menu>();
            List<Menu> listaMenuTieneHijos = new List<Menu>();
            List<Menu> listaMenu = plistaMenu;

            TreeNode nodoSubmenu;

            try
            {
                listaMenuHijos = listaMenu.ToList().Where(x => x.CODIGO_PADRE == pMenuHijos.PK_ID_MENU.ToString()).ToList();
                // verificacion para identificar si el menu tiene submenus
                if (listaMenuHijos.Count > 0)
                {
                    foreach (Menu submenu in listaMenuHijos)
                    {
                        nodoSubmenu = new TreeNode();

                        nodoSubmenu.Text = "&nbsp;<span><i class='" + submenu.ICONO + "' aria-hidden='true'></i> &nbsp;" + submenu.DESCRIPCION + "</span>";
                        nodoSubmenu.Value = "menu-" + submenu.PK_ID_MENU; // valor para identificar que el nodo pertenece a un menu
                        nodoSubmenu.ShowCheckBox = true;
                        nodoSubmenu.Checked = submenu.ESTADO_PERMISO ? true : false;

                        ObtenerPermisos(nodoSubmenu,
                          submenu.CREAR_MENU,
                          submenu.EDITAR_MENU,
                          submenu.VER_MENU,
                          submenu.APROBACION_MENU,
                          submenu.REENVIO_MENU,
                          submenu.CREAR_PERMISO,
                          submenu.EDITAR_PERMISO,
                          submenu.VER_PERMISO,
                          submenu.APROBACON_PERMISO,
                          submenu.REENVIO_PERMISO,
                          submenu.PK_ID_MENU
                         );

                        ObtenerSubmenus(nodoSubmenu, submenu, listaMenu);

                        nodoPadre.ChildNodes.Add(nodoSubmenu);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
            }

        }
        protected void ddlPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EliminarNodosTreeView();
                CargarTreeViewPermisos();
                tvPermisos.ExpandAll();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);

            }
        }

        protected void tvPermisos_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            try
            {
                TreeNode nodoCheckeado = e.Node;
                TreeNode nodoPadre = nodoCheckeado.Parent ?? nodoCheckeado;
                int contNodosCheckeados = 0;
                IList<TreeNode> listaPadres = CRM.TreeHelpers.GetAncestors(nodoCheckeado, nodo => nodo.Parent).ToList();
                int accionARealizar;

                // identificando si el nodo esta deshabilitado
                if (!nodoCheckeado.Text.Contains("color: grey"))
                {
                    contNodosCheckeados = ObtenerNodosHermanosCheckeados(nodoPadre);
                    accionARealizar = AccionARealizarConNodosPadres(contNodosCheckeados, listaPadres.Count);

                    if (accionARealizar == CHECKEAR_NODOS)
                    {
                        cambiarEstadoNodosPadre(true, listaPadres);

                    }
                    else if (accionARealizar == DESCHECKEAR_NODOS)
                    {
                        cambiarEstadoNodosPadre(false, listaPadres);
                    }

                    CambiarEstadoNodosHijos(nodoCheckeado);
                }
                else
                {
                    nodoCheckeado.Checked = !nodoCheckeado.Checked;
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalErrorInformacion", "$('#modalErroInformacion').modal();", true);
            }
        }


        private int AccionARealizarConNodosPadres(int contNodosCheckeados, int tamListaDesendencia)
        {
            int accion = -1;

            if (contNodosCheckeados == 1 && tamListaDesendencia > 0)
                accion = CHECKEAR_NODOS;

            if (contNodosCheckeados == 0 && tamListaDesendencia > 0)
                accion = DESCHECKEAR_NODOS;

            return accion;

        }
        private void cambiarEstadoNodosPadre(bool estado, IList<TreeNode> nodosPadre)
        {
            int contNodosPadresCheckeados = 0;
            // verificando si existen nodos padres que modificar
            if (nodosPadre.Count > 0)
            {
                for (int i = 0; i < nodosPadre.Count; i++)
                {
                    // cambiando el estado del primer nodo padre
                    nodosPadre[i].Checked = estado;
                    // verificando si se esta descheckeando los nodos padre
                    if (!estado)
                    {
                        // obteniendo la cantidad de nodos padre hermanos que se encuentran checkeados en el caso de que el nodo padre los tenga
                        if (nodosPadre.Count > 1 && i < nodosPadre.Count - 1)
                        {
                            contNodosPadresCheckeados = ObtenerNodosHermanosCheckeados(nodosPadre[i + 1]);
                            // evitando el cambio de estado de los demas padres cuando se encuentra que existen hijos checkeados
                            if (contNodosPadresCheckeados >= 1)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void CambiarEstadoNodosHijos(TreeNode nodoCheckeado)
        {

            IEnumerable<TreeNode> desendencia;
            if (nodoCheckeado.ChildNodes.Count > 0)
            {
                desendencia = ObtenerDesendencia(nodoCheckeado);

                foreach (TreeNode nodoDesendiente in desendencia)
                {
                    nodoDesendiente.Checked = nodoCheckeado.Checked;
                }
            }
        }
        private List<TreeNode> ObtenerDesendencia(TreeNode nodo)
        {
            List<TreeNode> listaNodos = new List<TreeNode>();

            if (nodo.ChildNodes.Count > 0)
            {
                foreach (TreeNode nodoHijo in nodo.ChildNodes)
                {
                    listaNodos.AddRange(ObtenerDesendencia(nodoHijo));

                    listaNodos.Add(nodoHijo);
                }
            }
            else
            {
                listaNodos.Add(nodo);
            }

            return listaNodos;
        }
    }
}