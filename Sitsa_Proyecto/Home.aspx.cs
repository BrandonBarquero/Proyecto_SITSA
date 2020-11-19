using Biblioteca_Clases.DAO;
using System;

namespace Control_Visitas
{



    public partial class WebForm1 : System.Web.UI.Page
    {

        ContadoresDAO contador = new ContadoresDAO();

    
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        public int Contar_Cliente()
        {
            int Contador_Cliente = contador.Contar_Clientes();

            return Contador_Cliente;
        }

        public int Contar_Usuarios()
        {
           int Contador_Usuarios = contador.Contar_Usuarios();

            return Contador_Usuarios;
        }

        public int Contar_Contratos()
        {
            int Contador_Contratos = contador.Contar_Contratos();

            return Contador_Contratos;
        }
        public int Contar_Servicios()
        {
            int Contador_Servicios = contador.Contar_Servicios();

            return Contador_Servicios;
        }
        public int Contar_Proyectos()
        {
            int Contador_Proyectos = contador.Contar_Proyectos();

            return Contador_Proyectos;
        }
        public int Contar_Cierre_Mes()
        {
            int Contador_Cierre_Mes = contador.Contar_Cierre_Mes();

            return Contador_Cierre_Mes;
        }


    }
}