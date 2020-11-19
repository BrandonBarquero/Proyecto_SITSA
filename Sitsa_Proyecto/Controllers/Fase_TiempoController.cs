using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class Fase_TiempoController : Controller
    {
        // GET: Fase_Tiempo

        Fase_TiempoDAO dao_fase = new Fase_TiempoDAO();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_fase(Fase_Tiempo fase)
        {
            var t = fase;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Fase_Tiempo fase_tiempo = new Fase_Tiempo();
            fase_tiempo.DESCRIPCION = t.DESCRIPCION;
            fase_tiempo.TIEMPO = t.TIEMPO;
            fase_tiempo.FECHA_CREACION = fecha.fecha();
            fase_tiempo.USUARIO_CREACION = (string)(Session["User"]);
            fase_tiempo.FK_ID_PROYECTO = t.FK_ID_PROYECTO;

            //int result = dao_fase.AgregarFase_Tiempo(fase_tiempo);

            //if (result == 1)
            //{
            //    validacion = "sucess";
            //}
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult actualizar_estado_deshabilitar_fase_tiempo(Fase_Tiempo fase)
        {
            var t = fase;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Fase_Tiempo fase_tiempo = new Fase_Tiempo();
            fase_tiempo.ID_FASE = t.ID_FASE;
            fase_tiempo.FECHA_MODIFICACION = fecha.fecha();
            fase_tiempo.USUARIO_MODIFICACION = (string)(Session["User"]);

            int result = dao_fase.ActualizarEstadoDeshabilitarFase(fase_tiempo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult Listar_Fases_Proyecto(string id)
        {
            List<Fase_Tiempo> fase_Tiempos = new List<Fase_Tiempo>();
            int val = int.Parse(id);
            fase_Tiempos = dao_fase.Listar_Fase_Tiempo_Filtrado(val);
            string sJSONResponse = JsonConvert.SerializeObject(fase_Tiempos, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }


    }
}