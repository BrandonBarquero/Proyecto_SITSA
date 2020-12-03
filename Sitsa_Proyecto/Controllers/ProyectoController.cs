using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ProyectoController : Controller
    {
        // GET: Proyecto

        ProyectoModelo proyecto_modelo = new ProyectoModelo();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_proyecto(Proyecto pro)
        {

            string validacion = "fail";

            Session["id_proyecto"] = proyecto_modelo.agregar_proyecto(pro, (string)(Session["User"]));



            if ((int)(Session["id_proyecto"]) != 0)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agregar_fases(List<Fase_Tiempo> fases)
        {

            int id_proyecto = (int)(Session["id_proyecto"]);

            string validacion = proyecto_modelo.agregar_fases(fases, id_proyecto, (string)(Session["User"])); 
            
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult actualizar_proyecto(Proyecto cont)
        {
            var t = cont;
            Session["id_proyecto"] = t.ID_PROYECTO;

            string validacion = proyecto_modelo.actualizar_proyecto(cont, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_proyecto(int id_proyecto)
        {
            string validacion = proyecto_modelo.actualizar_estado_deshabilitar_proyecto(id_proyecto, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_habilitar_proyecto(int id_proyecto)
        {
            string validacion = proyecto_modelo.actualizar_estado_habilitar_proyecto(id_proyecto, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eliminar_Fases(int id)
        {

            int result = proyecto_modelo.Eliminar_Fases(id);

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult devuelve_proyecto(int id)
        {
            Proyecto proyecto = new Proyecto();
            proyecto = proyecto_modelo.devuelve_proyecto(id);

            return Json(proyecto, JsonRequestBehavior.AllowGet);
        }


    }
}