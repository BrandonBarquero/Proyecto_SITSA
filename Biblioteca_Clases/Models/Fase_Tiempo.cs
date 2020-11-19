using System;

namespace Biblioteca_Clases.Models
{
    public class Fase_Tiempo
    {

        public int ID_FASE { set; get; }
        public string DESCRIPCION { set; get; }
        public Double TIEMPO { set; get; }
        public int ESTADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int FK_ID_PROYECTO { set; get; }

        public Fase_Tiempo(int id_fase, string dato, string usuario_Edita)
        {
            ID_FASE = id_fase;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
        }

        public Fase_Tiempo()
        {
        }


    }
}
