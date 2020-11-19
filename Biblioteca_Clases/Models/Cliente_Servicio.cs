namespace Biblioteca_Clases.Models
{
    public class Cliente_Servicio
    {
        public int PK_CLIENTE_SERVICIO { set; get; }
        public double TARIFA_HORA { set; get; }
        public int ESTADO { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USAURIO_MODIFICACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public int FK_ID_CLIENTE { set; get; }
        public int FK_ID_SERVICIO { set; get; }

        public Cliente_Servicio()
        {
        }

        public Cliente_Servicio(double tARIFA_HORA, int eSTADO, string uSUARIO_CREACION, string fECHA_CREACION, int fK_ID_CLIENTE, int fK_ID_SERVICIO)
        {
            TARIFA_HORA = tARIFA_HORA;
            ESTADO = eSTADO;
            USUARIO_CREACION = uSUARIO_CREACION;
            FECHA_CREACION = fECHA_CREACION;
            FK_ID_CLIENTE = fK_ID_CLIENTE;
            FK_ID_SERVICIO = fK_ID_SERVICIO;
        }

        public Cliente_Servicio(double tARIFA_HORA, int fK_ID_CLIENTE, int fK_ID_SERVICIO)
        {
            TARIFA_HORA = tARIFA_HORA;
            FK_ID_CLIENTE = fK_ID_CLIENTE;
            FK_ID_SERVICIO = fK_ID_SERVICIO;
        }
    }
}
