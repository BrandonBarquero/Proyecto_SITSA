namespace Biblioteca_Clases.Models
{
    public class Cliente_Contacto
    {


        public int PK_CLIENTE_CONTRATO { set; get; }
        public int ESTADO { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USAURIO_MODIFICACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public int FK_ID_CLIENTE { set; get; }
        public int FK_ID_CONTACTO { set; get; }

        public Cliente_Contacto()
        {
        }

        public Cliente_Contacto(int eSTADO, string uSUARIO_CREACION, string fECHA_CREACION, int fK_ID_CLIENTE, int fK_ID_CONTACTO)
        {
            ESTADO = eSTADO;
            USUARIO_CREACION = uSUARIO_CREACION;
            FECHA_CREACION = fECHA_CREACION;
            FK_ID_CLIENTE = fK_ID_CLIENTE;
            FK_ID_CONTACTO = fK_ID_CONTACTO;
        }
    }
}
