namespace Biblioteca_Clases.Models
{
    public class Contacto
    {
        public int ID_CONTACTO { set; get; }
        public string ENCARGADO { set; get; }
        public int TELEFONO { set; get; }
        public string CORREO { set; get; }
        public string TIPO_ENCARGADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int AUX { set; get; }
        public int AUX2 { set; get; }
        public Contacto()
        {

        }

        public Contacto(int id_contacto, string encargado, int telefono, string correo, string tipo_encargado, string dato, string usuario_Edita, int aux)
        {
            ID_CONTACTO = id_contacto;
            ENCARGADO = encargado;
            TELEFONO = telefono;
            CORREO = correo;
            TIPO_ENCARGADO = tipo_encargado;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
            AUX = aux;
        }

        public Contacto(int id_contacto, string encargado, int telefono, string correo, string tipo_encargado, string dato, string usuario_Edita, int aux, int aux2)
        {
            ID_CONTACTO = id_contacto;
            ENCARGADO = encargado;
            TELEFONO = telefono;
            CORREO = correo;
            TIPO_ENCARGADO = tipo_encargado;
            FECHA_MODIFICACION = dato;
            USUARIO_MODIFICACION = usuario_Edita;
            AUX = aux;
            AUX2 = aux2;
        }


    }


}
