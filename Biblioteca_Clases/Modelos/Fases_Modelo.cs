using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class Fases_Modelo
    {

        Fase_TiempoDAO dao_fase = new Fase_TiempoDAO();


        public string agregar_fase(Fase_Tiempo fase, string user)
        {
            var t = fase;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Fase_Tiempo fase_tiempo = new Fase_Tiempo();
            fase_tiempo.DESCRIPCION = t.DESCRIPCION;
            fase_tiempo.TIEMPO = t.TIEMPO;
            fase_tiempo.FECHA_CREACION = fecha.fecha();
            fase_tiempo.USUARIO_CREACION = user;
            fase_tiempo.FK_ID_PROYECTO = t.FK_ID_PROYECTO;

            //int result = dao_fase.AgregarFase_Tiempo(fase_tiempo);

            //if (result == 1)
            //{
            //    validacion = "sucess";
            //}
            return validacion;
        }
        public string actualizar_estado_deshabilitar_fase_tiempo(Fase_Tiempo fase, string user)
        {
            var t = fase;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Fase_Tiempo fase_tiempo = new Fase_Tiempo();
            fase_tiempo.ID_FASE = t.ID_FASE;
            fase_tiempo.FECHA_MODIFICACION = fecha.fecha();
            fase_tiempo.USUARIO_MODIFICACION = user;

            int result = dao_fase.ActualizarEstadoDeshabilitarFase(fase_tiempo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string Listar_Fases_Proyecto(string id)
        {
            List<Fase_Tiempo> fase_Tiempos = new List<Fase_Tiempo>();
            int val = int.Parse(id);
            fase_Tiempos = dao_fase.Listar_Fase_Tiempo_Filtrado(val);
            string sJSONResponse = JsonConvert.SerializeObject(fase_Tiempos, Formatting.Indented);
            return sJSONResponse;
        }

    }
}
