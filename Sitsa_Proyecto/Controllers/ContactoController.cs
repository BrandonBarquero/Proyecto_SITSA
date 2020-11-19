using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ContactoController : Controller
    {
        // GET: Contacto

        ContactoDAO dao_contacto = new ContactoDAO();

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult agregar_contacto(Contacto cont)
        {
            var t = cont;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ENCARGADO = t.ENCARGADO;
            contacto.TELEFONO = t.TELEFONO;
            contacto.CORREO = t.CORREO;
            contacto.TIPO_ENCARGADO = t.TIPO_ENCARGADO;
            contacto.FECHA_CREACION = fecha.fecha();
            contacto.USUARIO_CREACION = (string)(Session["User"]);

            int result = dao_contacto.AgregarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult modificar_contacto(Contacto contac)
        {
            var t = contac;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ID_CONTACTO = t.ID_CONTACTO;
            contacto.ENCARGADO = t.ENCARGADO;
            contacto.TELEFONO = t.TELEFONO;
            contacto.CORREO = t.CORREO;
            contacto.TIPO_ENCARGADO = t.TIPO_ENCARGADO;
            contacto.USUARIO_MODIFICACION = (string)(Session["User"]);
            contacto.FECHA_MODIFICACION = fecha.fecha();


            int result = dao_contacto.ActualizarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult eliminar_contacto(Contacto contac)
        {
            var t = contac;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ID_CONTACTO = t.ID_CONTACTO;

            int result = dao_contacto.EliminarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }

            if (result == 2)
            {
                validacion = "ErrorCont";
            }

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult eliminar_contacto_cliente(string dato)
        {
         
            string validacion = "fail";
          

            int result = dao_contacto.EliminarClienteContacto(dato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

    }

}