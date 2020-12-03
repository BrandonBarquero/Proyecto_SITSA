using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
namespace WebApplication2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente

        ClienteModelo cliente_modelo = new ClienteModelo();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agrega(Cliente_Servicio cont)
        {
            string sJSONResponse = cliente_modelo.agrega(cont, (string)(Session["User"]));

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agrega_contactos(Contacto cont)
        {
            string sJSONResponse = cliente_modelo.agrega_contactos(cont, (string)(Session["User"]));

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SesionCLeinte(string dato1)
        {
            string sJSONResponse = cliente_modelo.SesionCLeinte(dato1);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ServiciosCliente(string dato1)
        {
            string sJSONResponse = cliente_modelo.ServiciosCliente(dato1);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ContactosCliente(int dato)
        {
            string sJSONResponse = cliente_modelo.ContactosCliente(dato);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProyectosCliente(string dato1)
        {
            string sJSONResponse = cliente_modelo.ProyectosCliente(dato1);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

    }
}