using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using System.Web.Mvc;



namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        UsuarioDAO dao_usuario = new UsuarioDAO();

        UsuarioModelo usuario_modelo = new UsuarioModelo();  

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_usuario(Usuario user)
        {
            string validacion = usuario_modelo.agregar_usuario(user, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult actualizar_usuario(Usuario user)
        {
            string validacion = usuario_modelo.actualizar_usuario(user, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_Usuario(int id_usuario)
        {
            string validacion = usuario_modelo.actualizar_estado_Habilitar_Usuario(id_usuario, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizar_estado_deshabilitar_Usuario(int id_usuario)
        {
            string validacion = usuario_modelo.actualizar_estado_deshabilitar_Usuario(id_usuario, (string)(Session["User"]));

            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
    }
}