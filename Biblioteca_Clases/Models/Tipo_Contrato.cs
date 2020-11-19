namespace Biblioteca_Clases.Models
{
    public class Tipo_Contrato
    {
        public int ID_TIPO_CONTRATO { set; get; }
        public int ESTADO { set; get; }
        public string NOMBRE { set; get; }
        public bool HORAS { set; get; }
        public bool RANGO_DOCUMENTOS { set; get; }
        public bool MONTO { set; get; }
        public bool ACEPTACION { set; get; }
        public bool HORAS_POR_CONSUMIR { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }

        public Tipo_Contrato()
        {
        }

        public Tipo_Contrato(int id_tipo_contrato, string dato, string usuario_Edita)
        {
            ID_TIPO_CONTRATO = id_tipo_contrato;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
        }

        public Tipo_Contrato(string nOMBRE, bool hORAS, bool rANGO_DOCUMENTOS, bool mONTO, bool aCEPTACION)
        {
            NOMBRE = nOMBRE;
            HORAS = hORAS;
            RANGO_DOCUMENTOS = rANGO_DOCUMENTOS;
            MONTO = mONTO;
            ACEPTACION = aCEPTACION;
        }
    }
}
