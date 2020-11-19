using System;
using System.Web.UI;

namespace Control_Visitas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.AppendHeader("Cache-Control", "no-store");
            }
        }
    }
}