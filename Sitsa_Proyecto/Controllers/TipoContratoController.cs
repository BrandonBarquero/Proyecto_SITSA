using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Modelos;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class TipoContratoController : Controller
    {
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
        TipoContratoModelo TipoContratoModelo = new TipoContratoModelo();

        // GET: TipoContrato
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listar_tipo_contrato(int id)
        {            
            Tipo_Contrato tipo_Contrato = TipoContratoModelo.listar_tipo_contrato(id);

            return Json(tipo_Contrato, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_Tipo_Contrato(int id_tipo_contrato)
        {
            string validacion = TipoContratoModelo.actualizar_estado_Habilitar_Tipo_Contrato(id_tipo_contrato, (string)(Session["User"]));
                       
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_Tipo_Contrato(int id_tipo_contrato)
        {
            string validacion = TipoContratoModelo.actualizar_estado_deshabilitar_Tipo_Contrato(id_tipo_contrato, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult agregar_tipo_contrato(Tipo_Contrato tipo)
        {            
            string validacion = TipoContratoModelo.agregar_tipo_contrato(tipo, (string)(Session["User"]));
            
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult modificar_tipo_contrato(Tipo_Contrato tipo)
        {
            string validacion = TipoContratoModelo.modificar_tipo_contrato(tipo, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_activos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = TipoContratoModelo.listar_activos();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_inactivos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = TipoContratoModelo.listar_inactivos();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }


}