using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class UsuarioModelo
    {
        UsuarioDAO dao_usuario = new UsuarioDAO();
        Mail dao_mail = new Mail();

        public string agregar_usuario(Usuario user, string usuario)
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
            users.USUARIO_CREACION = usuario;

            int result = dao_usuario.AgregarUsuario(users);

            dao_mail.agregar_usuario_mail(users.CORREO, users.CONTRASENNA);



            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_usuario(Usuario user, string usuario)
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
            users.USUARIO_MODIFICACION = usuario;

            int result = dao_usuario.ActualizarUsuario(users);



            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_Habilitar_Usuario(int id_usuario, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Usuario usuario = new Usuario(id_usuario, dato, Usuario_Edita);


            int result = dao_usuario.ActualizarEstadoHabilitarUsuario(usuario);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_deshabilitar_Usuario(int id_usuario, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Usuario usuario = new Usuario(id_usuario, dato, Usuario_Edita);


            int result = dao_usuario.ActualizarEstadoDeshabilitarUsuarioo(usuario);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

    }
}
