using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class TipoContratoController : Controller
    {
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();

        // GET: TipoContrato
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listar_tipo_contrato(int id)
        {

            Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
            Tipo_Contrato tipo_Contrato = dao_tipo_contrato.listar_TipoContrato(id);

            return Json(tipo_Contrato, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_Tipo_Contrato(int id_tipo_contrato)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Tipo_Contrato tipo_Contrato = new Tipo_Contrato(id_tipo_contrato, dato, Usuario_Edita);


            int result = dao_tipo_contrato.ActualizarEstadoHabilitarTipoContrato(tipo_Contrato);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_Tipo_Contrato(int id_tipo_contrato)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Tipo_Contrato tipo_Contrato = new Tipo_Contrato(id_tipo_contrato, dato, Usuario_Edita);


            int result = dao_tipo_contrato.ActualizarEstadoDeshabilitarTipoContrato(tipo_Contrato);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agregar_tipo_contrato(Tipo_Contrato tipo)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();

            tipo.FECHA_CREACION = fecha.fecha();
            tipo.USUARIO_CREACION = (string)(Session["User"]);

            int result = dao_tipo_contrato.AgregarTipoContrato(tipo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult modificar_tipo_contrato(Tipo_Contrato tipo)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();

            tipo.FECHA_MODIFICACION = fecha.fecha();
            tipo.USUARIO_MODIFICACION = (string)(Session["User"]);

            int result = dao_tipo_contrato.ModificarTipoContrato(tipo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_activos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = dao_tipo_contrato.listaTipoContratos();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_inactivos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = dao_tipo_contrato.listaTipoContratosInactivos();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }


}