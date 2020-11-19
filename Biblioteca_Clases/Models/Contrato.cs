using System;

namespace Biblioteca_Clases.Models
{
    public class Contrato
    {
        public int ID_CONTRATO { set; get; }
        public string NOMBRE_CONTRATO { set; get; }
        public string DESCRIPCION { set; get; }
        public DateTime FECHA_INICIO { set; get; }
        public DateTime FECHA_VENCE { set; get; }
        public double PRECIO { set; get; }
        public int ESTADO { set; get; }
        public int MONTO { set; get; }
        public double HORAS { set; get; }
        public int RANGO { set; get; }
        public double HORAS_POR_CONSUMIR { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int CLIENTE { set; get; }
        public int SERVICIO { set; get; }
        public string DESCRIPCION_SERVICIO { set; get; }
        public int TIPO_CONTRATO { set; get; }
        public int CONTACTO { set; get; }

        public Contrato()
        {

        }

        public Contrato(int id_contrato, string dato, string usuario_Edita)
        {
            ID_CONTRATO = id_contrato;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
        }
    }
}
