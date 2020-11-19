using System;

namespace Biblioteca_Clases.Models
{
    public class Proyecto
    {
        public int ID_PROYECTO { set; get; }
        public string DESCRIPCION { set; get; }
        public string NOMBRE { set; get; }
        public Double PRECIO { set; get; }
        public int ESTADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int FK_ID_CLIENTE { set; get; }

        public Proyecto()
        {

        }

        public Proyecto(int id_proyecto, string dato, string usuario_Edita)
        {
            ID_PROYECTO = id_proyecto;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
        }

        public Proyecto(string nOMBRE, string dESCRIPCION, double pRECIO, int fK_ID_CLIENTE)
        {
            NOMBRE = nOMBRE;
            DESCRIPCION = dESCRIPCION;
            PRECIO = pRECIO;
            FK_ID_CLIENTE = fK_ID_CLIENTE;
        }
        public int Prueba { set; get; }

    }
}
