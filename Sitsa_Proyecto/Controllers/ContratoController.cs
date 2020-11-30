using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Modelos;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ContratoController : Controller
    {
        ContratoDAO dao_contrato = new ContratoDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
        ContactoDAO dao_contacto = new ContactoDAO();

        ContratoModelo ContratoModelo = new ContratoModelo();

        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult actualizar_estado_Habilitar_Contrato(int id_contrato)
        {
            string validacion = ContratoModelo.actualizar_estado_Habilitar_Contrato(id_contrato, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_Contrato(int id_contrato)
        {
            string validacion = ContratoModelo.actualizar_estado_deshabilitar_Contrato(id_contrato, (string)(Session["User"])); ;

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agregar_contrato(Contrato contrato, List<string> servicios)
        {
            string validacion = ContratoModelo.agregar_contrato(contrato, servicios, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_servicios_contrato(string id)
        {
            List<Servicio> servicios = new List<Servicio>();
            servicios = ContratoModelo.listar_servicios_contrato(id);

            return Json(servicios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult modificar_contrato(Contrato contrato, List<string> servicios)
        {
            string validacion = ContratoModelo.modificar_contrato(contrato, servicios, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_cliente(int id)
        {
            Cliente cliente = new Cliente();
            cliente = ContratoModelo.devuelve_cliente(id);

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_tipo_contrato(int id)
        {
            Tipo_Contrato tipo_Contrato = new Tipo_Contrato();
            tipo_Contrato = ContratoModelo.devuelve_tipo_contrato(id);

            return Json(tipo_Contrato, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_contactos_cliente(int id)
        {
            List<Contacto> contactos = new List<Contacto>();
            contactos = dao_contacto.BuscarDatosContacto(id);

            return Json(contactos, JsonRequestBehavior.AllowGet);
        }

    }
}