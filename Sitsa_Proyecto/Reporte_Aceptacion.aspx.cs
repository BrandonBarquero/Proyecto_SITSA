using Biblioteca_Clases.DAO;
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
        string datoUrl = null;
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
            if (DropDownList1.SelectedValue.Equals("Aceptar")) {
                dao.aceptar_reporte(aux.Decrypt(HttpUtility.UrlDecode(Request.QueryString["key"])));
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





    }
}