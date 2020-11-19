using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;

namespace WebApplication2
{
    public partial class Man_Contrato : System.Web.UI.Page
    {

        List<Contrato> list = new List<Contrato>();
        List<Cliente> list_clientes = new List<Cliente>();
        List<Tipo_Contrato> list_tipo_contratos = new List<Tipo_Contrato>();
        List<Servicio> list_servicios = new List<Servicio>();

        public Permiso_e Permisos;

        ContratoDAO dao_contrato = new ContratoDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
        ServicioDAO dao_servicio = new ServicioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            int perfil = (int)(Session["perfil"]);
            Permisos = dao_contrato.ControlPaginas("Contratos", perfil.ToString());

            if (Permisos.VER == false)
            {
                Response.Write("<script language='javascript'> alert('No tiene suficientes permisos'); window.location.href = 'Home.aspx'; </script>");


            }
        }

        public List<Contrato> Lista_Contrato(string valor)
        {

            ContratoDAO dao = new ContratoDAO();
            list = dao.listaContratos(valor);

            return list;

        }

        public List<Cliente> Lista_Clientes()
        {

            list_clientes = dao_cliente.listaClientes();

            return list_clientes;
        }

        public List<Tipo_Contrato> Lista_Tipo_Contratos()
        {

            list_tipo_contratos = dao_tipo_contrato.listaTipoContratosActivos();

            return list_tipo_contratos;
        }

        public List<Servicio> Lista_Servicios()
        {

            list_servicios = dao_servicio.listaServicios();

            return list_servicios;
        }

    }
}