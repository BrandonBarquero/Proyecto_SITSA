﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Newtonsoft.Json.Serialization;

namespace WebApplication2
{
    public partial class Reportes : System.Web.UI.Page
    {
        ContratoDAO dao_contrato = new ContratoDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        ReporteDAO dao_reporte = new ReporteDAO();
        ServicioDAO dao_servicio = new ServicioDAO();

        List<Cliente> list_clientes = new List<Cliente>();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Cliente> Lista_Clientes()
        {
            list_clientes = dao_cliente.listaClientes();
            return list_clientes;
        }

        public String Fecha()
        {
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            return dato;
        }

        public String Numero_Reporte()
        {
            return dao_reporte.numeroReporte();
        }

        public List<Servicio> Lista_Servicios()
        {
            return dao_servicio.listaServicios();
        }
    }
}