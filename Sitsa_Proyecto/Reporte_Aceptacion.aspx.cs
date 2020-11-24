using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitsa_Proyecto
{
    public partial class Reporte_Aceptacion : System.Web.UI.Page
    {
        Encryption aux = new Encryption();
        ReporteDAO dao = new ReporteDAO();
        Cierre_MesDAO dao_cierre = new Cierre_MesDAO();
        Fecha fecha = new Fecha();
        string datoUrl = null;
        List<Reporte> list = new List<Reporte>();
        List<Cliente> list2 = new List<Cliente>();
        List<Contrato> list3 = new List<Contrato>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                 
               bool valor = dao.consultarevision(aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"])));
                if (valor == true) {
                    Div3.Visible = false;
                    Div2.Visible = true;
                }

            }

        }


        public void Mostrar(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("Aceptar"))
            {
                Div1.Visible = false;
            }

            if (DropDownList1.SelectedValue.Equals("Rechazar"))
            {
                Div1.Visible = true;
            }



        }



        public void Cambio(Object sender, EventArgs e)
        {
            string id_reporte = aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"]));
            int fk_id_reporte = int.Parse(id_reporte);

            if (DropDownList1.SelectedValue.Equals("Aceptar")) {
                dao.aceptar_reporte(aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"])));
                list2 = dao.ObtenerNombreCliente(fk_id_reporte);

                var firstItem = list2.ElementAt(0);
                string usuario = firstItem.NOMBRE.ToString();

                dao_cierre.AgregarCierreMes(fk_id_reporte, usuario, fecha.fecha());

                Div3.Visible = false;
                Div2.Visible = true;
                Label3.Text = "Verificación realizada";
            }
            if (DropDownList1.SelectedValue.Equals("Rechazar"))
            {

                string motivo = TextBox1.Text;

                dao.rechazoreporte(aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"])), motivo);
                Div3.Visible = false;
                Div2.Visible = true;
                Label3.Text = "Verificacion realizada";

            }

        }

        public List<Reporte> Datos_Reporte()
        {

            ReporteDAO dao = new ReporteDAO();

            string val_reporte = aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"]));

            int id_reporte = int.Parse(val_reporte);

            list = dao.listaReporte(id_reporte);

            return list;
        }

        public List<Cliente> Nombre_Cliente_Reporte()
        {

            ReporteDAO dao = new ReporteDAO();

            string val_reporte = aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"]));

            int id_reporte = int.Parse(val_reporte);

            list2 = dao.ObtenerNombreCliente(id_reporte);

            return list2;
        }

        public List<Contrato> Nombre_Contrato_Proyecto_Reporte()
        {

            ReporteDAO dao = new ReporteDAO();

            string val_reporte = aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"]));

            int id_reporte = int.Parse(val_reporte);

            list3 = dao.ObtenerNombreContratoProyecto(id_reporte);

            return list3;
        }


        



    }
}