namespace Biblioteca_Clases.Models
{
    public class Servicio_Contrato
    {
        public int ID_CONTRATO { set; get; }
        public int ID_SERVICIO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }

        public Servicio_Contrato()
        {
        }
    }
}
