using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto

        ContactoDAO dao_contacto = new ContactoDAO();
        ContactoModelo ContactoModelo = new ContactoModelo();

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult agregar_contacto(Contacto cont)
        {
            string validacion = ContactoModelo.agregar_contacto(cont, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult modificar_contacto(Contacto contac)
        {
            string validacion = ContactoModelo.modificar_contacto(contac, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult eliminar_contacto(Contacto contac)
        {
            string validacion = ContactoModelo.eliminar_contacto(contac);

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminar_contacto_cliente(string dato)
        {

            string validacion = ContactoModelo.eliminar_contacto_cliente(dato);

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

    }

}