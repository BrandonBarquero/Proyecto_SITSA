using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Modelos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class Fase_TiempoController : Controller
    {
        // GET: Fase_Tiempo

        Fase_TiempoDAO dao_fase = new Fase_TiempoDAO();
        Fases_Modelo fase_modelo = new Fases_Modelo();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_fase(Fase_Tiempo fase)
        {
            string validacion = fase_modelo.agregar_fase(fase, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult actualizar_estado_deshabilitar_fase_tiempo(Fase_Tiempo fase)
        {
            var t = fase;
            string validacion = fase_modelo.actualizar_estado_deshabilitar_fase_tiempo(fase, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult Listar_Fases_Proyecto(string id)
        {
            string sJSONResponse = fase_modelo.Listar_Fases_Proyecto(id); ;

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }


    }
}