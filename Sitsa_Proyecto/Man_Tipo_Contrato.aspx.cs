using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class Man_Tipo_Contrato : System.Web.UI.Page
    {

        List<Tipo_Contrato> list = new List<Tipo_Contrato>();

        public Permiso_e Permisos;
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();


        protected void Page_Load(object sender, EventArgs e)
        {

            int perfil = (int)(Session["perfil"]);
            Permisos = dao_tipo_contrato.ControlPaginas("Tipo Contrato", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No posee los permisos necesarios'); window.location.href = 'Home.aspx'; </script>");

            }
        }


        public List<Tipo_Contrato> ListaTipo_Contrato(string valor)
        {

            Tipo_ContratoDAO dao = new Tipo_ContratoDAO();


            if (valor == null || valor == "General")
            {
                list = dao.listaTipoContratos();
            }
            if (valor == "Activo")
            {
                list = dao.listaTipoContratosActivos();
            }
            if (valor == "Inactivo")
            {
                list = dao.listaTipoContratosInactivos();
            }

            return list;
        }
    }
}