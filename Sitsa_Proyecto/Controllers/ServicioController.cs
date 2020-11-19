using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio

        ServicioDAO dao_servicio = new ServicioDAO();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult agregar_servicio(FormCollection formCollection)
        {
            string validacion = "fail";

            string descripcion = formCollection["descripcion"];
            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(descripcion, dato, Usuario_Edita);


            int result = dao_servicio.AgregarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_servicio(int id_servicio, string descripcion)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, descripcion, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }


        public JsonResult actualizar_estado_deshabilitar_servicio(int id_servicio)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarEstadoDeshabilitarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_servicio(int id_servicio)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarEstadoHabilitarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult eliminar_servicio_cliente(string dato)
        {

            string validacion = "fail";


            int result = dao_servicio.EliminarServicioContacto(dato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
    }
}