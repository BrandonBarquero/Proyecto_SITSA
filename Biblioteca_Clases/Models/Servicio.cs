namespace Biblioteca_Clases.Models
{
    public class Servicio
    {

        public int ID_SERVICIO { set; get; }
        public string DESCRIPCION { set; get; }
        public int ESTADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }

        public Servicio()
        {

        }

        public Servicio(int P_ID_SERVICIO, string P_DESCRIPCION)
        {
            ID_SERVICIO = P_ID_SERVICIO;
            DESCRIPCION = P_DESCRIPCION;

        }

        public Servicio(int P_ID_SERVICIO, string dato, string usuario_Edita)
        {
            ID_SERVICIO = P_ID_SERVICIO;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;

        }

        public Servicio(string descripcion, string dato, string usuario_Edita)
        {
            DESCRIPCION = descripcion;
            FECHA_CREACION = dato;
            USUARIO_CREACION = usuario_Edita;
        }

        public Servicio(int idservicio, string descripcion, string dato, string usuario_Edita)
        {
            ID_SERVICIO = idservicio;
            DESCRIPCION = descripcion;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
        }
    }
}
