using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        ServicioModelo servicio_modelo = new ServicioModelo();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult agregar_servicio(string descripcion)
        {
            string validacion = servicio_modelo.agregar_servicio(descripcion, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_servicio(int id_servicio, string descripcion)
        {
            string validacion = servicio_modelo.actualizar_servicio(id_servicio, descripcion, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }


        public JsonResult actualizar_estado_deshabilitar_servicio(int id_servicio)
        {
            string validacion = servicio_modelo.actualizar_estado_deshabilitar_servicio(id_servicio, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_servicio(int id_servicio)
        {
            string validacion = servicio_modelo.actualizar_estado_Habilitar_servicio(id_servicio, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult eliminar_servicio_cliente(string dato)
        {
            string validacion = servicio_modelo.eliminar_servicio_cliente(dato);
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
    }
}