namespace Biblioteca_Clases.Models
{
    public class Cliente
    {

        public int ID_CLIENTE { set; get; }
        public string NOMBRE { set; get; }
        public char ESTADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        /*public string CONTACTO_ID { get; set; }
        public string CONTACTO_NOMBRE { get; set; }*/

        public Cliente()
        {

        }


    }
}
