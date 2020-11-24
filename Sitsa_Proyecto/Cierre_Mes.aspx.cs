using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace WebApplication2
{
    public partial class Cierre_Mes : System.Web.UI.Page
    {
        ClienteDAO dao_cliente = new ClienteDAO();
        Cierre_MesDAO dao_contacto = new Cierre_MesDAO();

        List<Cliente> list_clientes = new List<Cliente>();
        List<Contacto> list_contacto = new List<Contacto>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Cliente> Lista_Clientes()
        {
            list_clientes = dao_cliente.listaClientes();
            return list_clientes;
        }
    }
}