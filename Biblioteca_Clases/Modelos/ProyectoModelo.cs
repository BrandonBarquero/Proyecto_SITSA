using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class ProyectoModelo
    {

        ProyectoDAO dao_proyecto = new ProyectoDAO();
        Fase_TiempoDAO dao_fase = new Fase_TiempoDAO();

        public int agregar_proyecto(Proyecto pro, string user)
        {

            
            Fecha fecha = new Fecha();

            Proyecto proyect = new Proyecto();
            proyect.NOMBRE = pro.NOMBRE;
            proyect.DESCRIPCION = pro.DESCRIPCION;
            proyect.PRECIO = pro.PRECIO;
            proyect.FECHA_CREACION = fecha.fecha();
            proyect.USUARIO_CREACION = user;
            proyect.FK_ID_CLIENTE = pro.FK_ID_CLIENTE;

            int validacion = dao_proyecto.AgregarProyecto(proyect);

            return validacion;
        }

        public string agregar_fases(List<Fase_Tiempo> fases, int id_proyecto, string user)
        {
            if (fases == null)
            {
                return "sucess";
            }

            string validacion = "fail";
            Fecha fecha = new Fecha();
            string date = fecha.fecha();
            int result = 0;

            foreach (Fase_Tiempo dato in fases)
            {
                result = dao_fase.AgregarFase_Tiempo(dato, id_proyecto, user, date);
            }

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_proyecto(Proyecto cont, string user)
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
            proyect.USUARIO_CREACION = user;
            proyect.FK_ID_CLIENTE = t.FK_ID_CLIENTE;
            int result = dao_proyecto.ActualizarProyecto(proyect);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_deshabilitar_proyecto(int id_proyecto, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Proyecto proy = new Proyecto(id_proyecto, dato, Usuario_Edita);


            int result = dao_proyecto.ActualizarEstadoDeshabilitarProyecto(proy);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_habilitar_proyecto(int id_proyecto, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Proyecto proy = new Proyecto(id_proyecto, dato, Usuario_Edita);


            int result = dao_proyecto.ActualizarEstadoHabilitarProyecto(proy);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public int Eliminar_Fases(int id)
        {

            int result = dao_fase.EliminarFase(id);

            return result;

        }

        public Proyecto devuelve_proyecto(int id)
        {
            Proyecto proyecto = new Proyecto();
            proyecto = dao_proyecto.devuelve_proyecto(id);

            return proyecto;
        }
    }
}
