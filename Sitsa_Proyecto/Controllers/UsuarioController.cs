using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System.Web.Mvc;



namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        UsuarioDAO dao_usuario = new UsuarioDAO();
        Mail dao_mail = new Mail();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_usuario(Usuario user)
        {
            var t = user;
            string validacion = "fail";
            Fecha fecha = new Fecha();
            Usuario users = new Usuario();

            users.CEDULA = t.CEDULA;
            users.NOMBRE = t.NOMBRE;
            users.CORREO = t.CORREO;
            users.FK_PERFIL = t.FK_PERFIL;
            users.CONTRASENNA = dao_mail.Contrasenna();
            users.FECHA_CREACION = fecha.fecha();
            users.USUARIO_CREACION = (string)(Session["User"]);

            int result = dao_usuario.AgregarUsuario(users);

            dao_mail.agregar_usuario_mail(users.CORREO, users.CONTRASENNA);



            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult actualizar_usuario(Usuario user)
        {
            var t = user;
            string validacion = "fail";
            Fecha fecha = new Fecha();
            Usuario users = new Usuario();

            users.CEDULA = t.CEDULA;
            users.NOMBRE = t.NOMBRE;
            users.CORREO = t.CORREO;
            users.FK_PERFIL = t.FK_PERFIL;
            users.FECHA_MODIFICACION = fecha.fecha();
            users.USUARIO_MODIFICACION = (string)(Session["User"]);

            int result = dao_usuario.ActualizarUsuario(users);



            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_Habilitar_Usuario(int id_usuario)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Usuario usuario = new Usuario(id_usuario, dato, Usuario_Edita);


            int result = dao_usuario.ActualizarEstadoHabilitarUsuario(usuario);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizar_estado_deshabilitar_Usuario(int id_usuario)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Usuario usuario = new Usuario(id_usuario, dato, Usuario_Edita);


            int result = dao_usuario.ActualizarEstadoDeshabilitarUsuarioo(usuario);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
    }
}