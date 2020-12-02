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

        ProyectoDAO dao_proyecto = new ProyectoDAO();
        Fase_TiempoDAO dao_fase = new Fase_TiempoDAO();




        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_proyecto(Proyecto pro/*, List<Fases> fases*/)
        {

            string validacion = "fail";
            Fecha fecha = new Fecha();

            Proyecto proyect = new Proyecto();
            proyect.NOMBRE = pro.NOMBRE;
            proyect.DESCRIPCION = pro.DESCRIPCION;
            proyect.PRECIO = pro.PRECIO;
            proyect.FECHA_CREACION = fecha.fecha();
            proyect.USUARIO_CREACION = (string)(Session["User"]);
            proyect.FK_ID_CLIENTE = pro.FK_ID_CLIENTE;

            Session["id_proyecto"] = dao_proyecto.AgregarProyecto(proyect);



            if ((int)(Session["id_proyecto"]) != 0)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agregar_fases(List<Fase_Tiempo> fases)
        {
            if (fases == null)
            {
                return Json("sucess", JsonRequestBehavior.AllowGet);
            }

            string validacion = "fail";
            Fecha fecha = new Fecha();
            string date = fecha.fecha();
            int result = 0;

            foreach (Fase_Tiempo dato in fases)
            {
                result = dao_fase.AgregarFase_Tiempo(dato, (int)(Session["id_proyecto"]), (string)(Session["User"]), date);
            }

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult actualizar_proyecto(Proyecto cont)
        {
            var t = cont;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Proyecto proyect = new Proyecto();
            proyect.ID_PROYECTO = t.ID_PROYECTO;
            proyect.NOMBRE = t.NOMBRE;
            proyect.DESCRIPCION = t.DESCRIPCION;
            proyect.PRECIO = t.PRECIO;
            proyect.FECHA_CREACION = fecha.fecha();
            proyect.USUARIO_CREACION = (string)(Session["User"]);
            proyect.FK_ID_CLIENTE = t.FK_ID_CLIENTE;
            Session["id_proyecto"] = t.ID_PROYECTO;
            int result = dao_proyecto.ActualizarProyecto(proyect);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_proyecto(int id_proyecto)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Proyecto proy = new Proyecto(id_proyecto, dato, Usuario_Edita);


            int result = dao_proyecto.ActualizarEstadoDeshabilitarProyecto(proy);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_habilitar_proyecto(int id_proyecto)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Proyecto proy = new Proyecto(id_proyecto, dato, Usuario_Edita);


            int result = dao_proyecto.ActualizarEstadoHabilitarProyecto(proy);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }



        public JsonResult Eliminar_Fases(int id)
        {

            int result = dao_fase.EliminarFase(id);

            return Json(result, JsonRequestBehavior.AllowGet);

        }


    }
}