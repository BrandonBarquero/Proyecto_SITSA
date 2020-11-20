using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca_Clases.Models;

namespace Biblioteca_Clases.DAO
{
    public class ReporteDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ReporteDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public string numeroReporte()
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_EXTRAER_NUMERO_REPORTE";
            SqlDataReader list = comando.ExecuteReader();

            string num = "";
            while (list.Read())
            {
                num = (list.GetDecimal(0) + 1).ToString();
            }
            list.Dispose();
            comando.Dispose();
            return num;
        }

        public int AgregarReporte(Reporte reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            if (reporte.TIPO_DOCUMENTO == "Reporte Contrato Facturado")
            {
                reporte.FACTURADO = true;
            }
            else
            {
                reporte.FACTURADO = false;
            }

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_AGREGAR_REPORTE_CONTRATO @TIPO_DOCUMENTO, @FACTURADO, @CANTIDAD_HORAS, @OBSERVACION, @FECHA, @USUARIO, @FECHA_C, @CONTACTO, @CONTRATO";
            comando.Parameters.AddWithValue("@TIPO_DOCUMENTO", reporte.TIPO_DOCUMENTO);
            comando.Parameters.AddWithValue("@FACTURADO", reporte.FACTURADO);
            comando.Parameters.AddWithValue("@CANTIDAD_HORAS", reporte.CANTIDAD_HORAS);
            if (reporte.OBSERVACION != null) { comando.Parameters.AddWithValue("@OBSERVACION", reporte.OBSERVACION); } else { comando.Parameters.AddWithValue("@OBSERVACION", " "); }
            comando.Parameters.AddWithValue("@FECHA", reporte.FECHA);
            comando.Parameters.AddWithValue("@USUARIO", reporte.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_C", reporte.FECHA_CREACION);
            comando.Parameters.AddWithValue("@CONTACTO", reporte.FK_ID_CONTACTO);
            comando.Parameters.AddWithValue("@CONTRATO", reporte.ID_CONTRATO);

            //result = comando.ExecuteNonQuery();
            result = Convert.ToInt32(comando.ExecuteScalar());
            return result;
        }

        public int AgregarDetallesReporte(List<Detalle_Reporte> detalles_reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            //QuitarDetallesReporte(servicios[0].ID_CONTRATO);

            foreach (Detalle_Reporte dato in detalles_reporte)
            {
                comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "execute PA_CTRL_AGREGAR_DETALLES_REPORTE_CONTRATO @HORAS, @TARIFA, @USUARIO, @FECHA, @ID_REPORTE, @OBSERVACION, @ID_SERVICIO";
                comando.Parameters.AddWithValue("@HORAS", dato.HORAS);
                comando.Parameters.AddWithValue("@TARIFA", dato.TARIFA);
                comando.Parameters.AddWithValue("@USUARIO", dato.USUARIO_CREACION);
                comando.Parameters.AddWithValue("@FECHA", dato.FECHA_CREACION);
                comando.Parameters.AddWithValue("@ID_REPORTE", dato.FK_ID_REPORTE);
                if (dato.OBSERVACION != null) { comando.Parameters.AddWithValue("@OBSERVACION", dato.OBSERVACION); } else { comando.Parameters.AddWithValue("@OBSERVACION", " "); } 
                comando.Parameters.AddWithValue("@ID_SERVICIO", dato.ID_SERVICIO);

                result = comando.ExecuteNonQuery();
                //result = Convert.ToInt32(comando.ExecuteScalar());
            }

            return result;
        }

        public int aceptar_reporte(string dato)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_MAN_ACEPTAR_REPORTE] @P_PK_ID_REPORTE";
            comando.Parameters.AddWithValue("@P_PK_ID_REPORTE", dato);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int AgregarReporteProyecto(Reporte reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            if (reporte.TIPO_DOCUMENTO == "Reporte Proyecto Facturado")
            {
                reporte.FACTURADO = true;
            }
            else
            {
                reporte.FACTURADO = false;
            }

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_AGREGAR_REPORTE_PROYECTO @TIPO_DOCUMENTO, @FACTURADO, @OBSERVACION, @FECHA, @USUARIO, @FECHA_C, @CONTACTO, @PROYECTO";
            comando.Parameters.AddWithValue("@TIPO_DOCUMENTO", reporte.TIPO_DOCUMENTO);
            comando.Parameters.AddWithValue("@FACTURADO", reporte.FACTURADO);
            if (reporte.OBSERVACION != null) { comando.Parameters.AddWithValue("@OBSERVACION", reporte.OBSERVACION); } else { comando.Parameters.AddWithValue("@OBSERVACION", " "); }
            comando.Parameters.AddWithValue("@FECHA", reporte.FECHA);
            comando.Parameters.AddWithValue("@USUARIO", reporte.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_C", reporte.FECHA_CREACION);
            comando.Parameters.AddWithValue("@CONTACTO", reporte.FK_ID_CONTACTO);
            comando.Parameters.AddWithValue("@PROYECTO", reporte.ID_PROYECTO);

            //result = comando.ExecuteNonQuery();
            result = Convert.ToInt32(comando.ExecuteScalar());
            return result;
        }

        public List<Detalle_Reporte> BuscaDetallesReporte(int id, int opc)
        {
            Detalle_Reporte detalle_reporte = new Detalle_Reporte();
            List<Detalle_Reporte> detalles_reporte = new List<Detalle_Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "";
            if (opc == 1) {
                comando.CommandText = "PA_CTRL_CON_BUSCAR_DETALLE_REPORTE_CONTRATO @ID";
            } else if (opc == 2) {
                comando.CommandText = "PA_CTRL_CON_BUSCAR_DETALLE_REPORTE_PROYECTO @ID";
            }
            comando.Parameters.AddWithValue("@ID", id);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                detalle_reporte = new Detalle_Reporte();
                detalle_reporte.PK_ID_DETALLE_REPORTE = list.GetInt32(0);
                if(!list.IsDBNull(1)){
                    detalle_reporte.HORAS = list.GetDouble(1);
                }
                
                detalle_reporte.TARIFA = list.GetDouble(2);
                detalle_reporte.FK_ID_REPORTE = list.GetInt32(3);
                detalle_reporte.OBSERVACION = list.GetString(4);
                if (!list.IsDBNull(5)){
                    detalle_reporte.ID_SERVICIO = list.GetInt32(5);
                }
                detalles_reporte.Add(detalle_reporte);
            }
            list.Dispose();
            comando.Dispose();
            return detalles_reporte;
        }

        public void EliminarDetallesReporte(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "execute PA_MAN_ELIMINAR_DETALLES_REPORTE @ID";
            comando.Parameters.AddWithValue("@ID", id);

            comando.ExecuteNonQuery();
        }

        public int ModificarReporteProyecto(Reporte reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            if (reporte.TIPO_DOCUMENTO == "Reporte Proyecto Facturado")
            {
                reporte.FACTURADO = true;
            }
            else
            {
                reporte.FACTURADO = false;
            }

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MODIFICAR_REPORTE_PROYECTO @ID, @TIPO_DOCUMENTO, @FACTURADO, @OBSERVACION, @FECHA, @USUARIO, @FECHA_C, @CONTACTO, @PROYECTO";
            comando.Parameters.AddWithValue("@ID", reporte.PK_ID_REPORTE);
            comando.Parameters.AddWithValue("@TIPO_DOCUMENTO", reporte.TIPO_DOCUMENTO);
            comando.Parameters.AddWithValue("@FACTURADO", reporte.FACTURADO);
            comando.Parameters.AddWithValue("@OBSERVACION", reporte.OBSERVACION);
            comando.Parameters.AddWithValue("@FECHA", reporte.FECHA);
            comando.Parameters.AddWithValue("@USUARIO", reporte.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_C", reporte.FECHA_CREACION);
            comando.Parameters.AddWithValue("@CONTACTO", reporte.FK_ID_CONTACTO);
            comando.Parameters.AddWithValue("@PROYECTO", reporte.ID_PROYECTO);

            result = comando.ExecuteNonQuery();
            //result = Convert.ToInt32(comando.ExecuteScalar());
            return result;
        }

        public int ActivarContratoProyecto(int id, int opc)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_ACTIVAR_CONTRATO_PROYECTO @ID, @OPC";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Parameters.AddWithValue("@OPC", opc);
            result = comando.ExecuteNonQuery();
            comando.Dispose();

            return result;
        }

        public int ModificarReporteContrato(Reporte reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            if (reporte.TIPO_DOCUMENTO == "Reporte Contrato Facturado")
            {
                reporte.FACTURADO = true;
            }
            else
            {
                reporte.FACTURADO = false;
            }

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MODIFICAR_REPORTE_CONTRATO @ID, @TIPO_DOCUMENTO, @FACTURADO, @CANTIDAD_HORAS, @OBSERVACION, @FECHA, @USUARIO, @FECHA_C, @CONTACTO, @CONTRATO";
            comando.Parameters.AddWithValue("@ID", reporte.PK_ID_REPORTE);
            comando.Parameters.AddWithValue("@TIPO_DOCUMENTO", reporte.TIPO_DOCUMENTO);
            comando.Parameters.AddWithValue("@FACTURADO", reporte.FACTURADO);
            comando.Parameters.AddWithValue("@CANTIDAD_HORAS", reporte.CANTIDAD_HORAS);
            comando.Parameters.AddWithValue("@OBSERVACION", reporte.OBSERVACION);
            comando.Parameters.AddWithValue("@FECHA", reporte.FECHA);
            comando.Parameters.AddWithValue("@USUARIO", reporte.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA_C", reporte.FECHA_CREACION);
            comando.Parameters.AddWithValue("@CONTACTO", reporte.FK_ID_CONTACTO);
            comando.Parameters.AddWithValue("@CONTRATO", reporte.ID_CONTRATO);

            result = comando.ExecuteNonQuery();
            comando.Dispose();
            //result = Convert.ToInt32(comando.ExecuteScalar());
            return result;
        }

        public Reporte devuelve_reporte(int id)
        {
            Reporte reporte = new Reporte();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_DEVUELVE_REPORTE @ID";
            comando.Parameters.AddWithValue("@ID", id);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                reporte = new Reporte();
                reporte.PK_ID_REPORTE = list.GetInt32(0);
                reporte.TIPO_DOCUMENTO = list.GetString(1);
                reporte.FACTURADO = list.GetBoolean(2);
                if (!list.IsDBNull(3)){
                    reporte.CANTIDAD_HORAS = list.GetDouble(3);
                }
                reporte.OBSERVACION = list.GetString(4);
                reporte.FK_ID_CONTACTO = list.GetInt32(5);
                
                if (!list.IsDBNull(6)) {
                    reporte.ID_CONTRATO = list.GetInt32(6);
                }

                if (!list.IsDBNull(7)){
                    reporte.ID_PROYECTO = list.GetInt32(7);
                }

                reporte.FECHA_CREACION = (list.GetDateTime(8).ToShortDateString());

            }
            list.Dispose();
            comando.Dispose();
            return reporte;
        }

        public int AgregarDetalleReporteProyecto(Detalle_Reporte detalle_Reporte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            //QuitarDetallesReporte(servicios[0].ID_CONTRATO);

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_AGREGAR_DETALLES_REPORTE_PROYECTO @TARIFA, @USUARIO, @FECHA, @ID_REPORTE, @OBSERVACION";
            comando.Parameters.AddWithValue("@TARIFA", detalle_Reporte.TARIFA);
            comando.Parameters.AddWithValue("@USUARIO", detalle_Reporte.USUARIO_CREACION);
            comando.Parameters.AddWithValue("@FECHA", detalle_Reporte.FECHA_CREACION);
            comando.Parameters.AddWithValue("@ID_REPORTE", detalle_Reporte.FK_ID_REPORTE);
            if (detalle_Reporte.OBSERVACION != null) { comando.Parameters.AddWithValue("@OBSERVACION", detalle_Reporte.OBSERVACION); } else { comando.Parameters.AddWithValue("@OBSERVACION", " "); }

            //result = comando.ExecuteNonQuery();
            result = Convert.ToInt32(comando.ExecuteScalar());

            return result;
        }

        public int CambiarEstadoReporteProyecto(int id_proyecto, string usuario, string fecha)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_CAMBIAR_ESTADO_REPORTE_PROYECTO @ID, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@ID", id_proyecto);
            comando.Parameters.AddWithValue("@USUARIO", usuario);
            comando.Parameters.AddWithValue("@FECHA", fecha);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public int CambiarEstadoReporteContrato(int id_contrato, string usuario, string fecha)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute PA_CTRL_MAN_CAMBIAR_ESTADO_REPORTE_CONTRATO @ID, @USUARIO, @FECHA";
            comando.Parameters.AddWithValue("@ID", id_contrato);
            comando.Parameters.AddWithValue("@USUARIO", usuario);
            comando.Parameters.AddWithValue("@FECHA", fecha);

            result = comando.ExecuteNonQuery();

            return result;
        }

        public bool consultarevision(string dato)
        {
            bool result = false;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CON_BUSCAR_REVISION] @dato";
            comando.Parameters.AddWithValue("@dato", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetBoolean(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;


        }

        public int rechazoreporte(string FK_REPORTE, string motivo)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_MAN_AGREGAR_RECHAZO_REPORTE] @P_FK_REPORTE, @NOMBRE";
            comando.Parameters.AddWithValue("@P_FK_REPORTE", FK_REPORTE);
            comando.Parameters.AddWithValue("@NOMBRE", motivo);

            result = comando.ExecuteNonQuery();

            return result;

        }
        public List<Reporte> listaReporte(string dato)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_NUMERO_REPORTE @dato";
            comando.Parameters.AddWithValue("@dato", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                if (!list.IsDBNull(1))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(1);
                }
                
                serv.TIPO_DOCUMENTO = list.GetString(2);
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listaReportefacturados(string dato)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_NUMERO_REPORTE_FACTURADO] @dato";
            comando.Parameters.AddWithValue("@dato", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                if (!list.IsDBNull(1))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(1);
                }
                serv.TIPO_DOCUMENTO = list.GetString(2);
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listaCliente(string dato)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_CLIENTE @dato";
            comando.Parameters.AddWithValue("@dato", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                serv.TIPO_DOCUMENTO = list.GetString(1);
                if (!list.IsDBNull(2))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(2);
                }
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listaClienteFacturado(string dato)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_CLIENTE_FACTURADO] @dato";
            comando.Parameters.AddWithValue("@dato", dato);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                serv.TIPO_DOCUMENTO = list.GetString(1);
                if (!list.IsDBNull(2))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(2);
                }
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listaFechas(string dato, string dato1)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_FECHAS @dato, @dato1";
            comando.Parameters.AddWithValue("@dato", dato);
            comando.Parameters.AddWithValue("@dato1", dato1);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                serv.TIPO_DOCUMENTO = list.GetString(1);
                if (!list.IsDBNull(2))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(2);
                }
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }

        public List<Reporte> listaFechasfacturado(string dato, string dato1)
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CTRL_MAN_LISTAR_REPORTES_FILTRADO_FECHAS_FACTURADO] @dato, @dato1";
            comando.Parameters.AddWithValue("@dato", dato);
            comando.Parameters.AddWithValue("@dato1", dato1);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                serv.TIPO_DOCUMENTO = list.GetString(1);
                if (!list.IsDBNull(2))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(2);
                }
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listarfacturados()
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CON_LISTAR_MAN_Reportes_FACTURADOS] ";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                if (!list.IsDBNull(1))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(1);
                }
                serv.TIPO_DOCUMENTO = list.GetString(2);
              
                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public List<Reporte> listar()
        {
            List<Reporte> listareportes = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CON_LISTAR_MAN_Reportes] ";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte serv = new Reporte();
                serv.PK_ID_REPORTE = list.GetInt32(0);
                if (!list.IsDBNull(1))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(1);
                }
                serv.TIPO_DOCUMENTO = list.GetString(2);

                listareportes.Add(serv);
            }
            list.Dispose();
            comando.Dispose();
            return listareportes;

        }
        public int aceptarreporte(string FK_REPORTE, string usuario, string fecha)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_CAMBIAR_ESTADO_REPORTE] @P_FK_REPORTE, @usuario, @fecha";
            comando.Parameters.AddWithValue("@P_FK_REPORTE", FK_REPORTE);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@fecha", fecha);
            result = comando.ExecuteNonQuery();

            return result;

        }


        public int RechazarReporte(string FK_REPORTE, string usuario, string fecha)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "execute [PA_CTRL_MAN_CAMBIAR_ESTADO_REPORTE_DESAPROBAR] @P_FK_REPORTE, @usuario, @fecha";
            comando.Parameters.AddWithValue("@P_FK_REPORTE", FK_REPORTE);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@fecha", fecha);
            result = comando.ExecuteNonQuery();

            return result;

        }


        public Reporte LISTAR_REPORTE(string dato)
        {
            Reporte serv = new Reporte();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec [PA_CON_LISTAR_REPORTE] @dato";
            comando.Parameters.AddWithValue("@dato", dato);
    
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {              
                serv.PK_ID_REPORTE = list.GetInt32(0);
                serv.TIPO_DOCUMENTO = list.GetString(1);
                if (!list.IsDBNull(2))
                {
                    serv.CANTIDAD_HORAS = list.GetDouble(2);
                }               
            }
            list.Dispose();
            comando.Dispose();
            return serv;

        }

        public List<Reporte> listaReporte(int id)
        {
            List<Reporte> listaContactos = new List<Reporte>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_REG_LISTAR_REPORTE_APROBACION_RECHAZO @PK_REPORTE";
            comando.Parameters.AddWithValue("@PK_REPORTE", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Reporte cont = new Reporte();
                cont.PK_ID_REPORTE = list.GetInt32(0);
                cont.TIPO_DOCUMENTO = list.GetString(1);
                cont.CANTIDAD_HORAS = list.GetDouble(3);
                cont.OBSERVACION = list.GetString(4);
               // cont.FECHA = list.GetString(5);

                listaContactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContactos;

        }

        public List<Cliente> ObtenerNombreCliente(int id)
        {
            List<Cliente> listaContactos = new List<Cliente>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_NOMBRE_CLIENTE_REPORTE @PK_REPORTE";
            comando.Parameters.AddWithValue("@PK_REPORTE", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Cliente cont = new Cliente();
                cont.NOMBRE = list.GetString(0);

                listaContactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContactos;

        }

        public string ObtenerNombreCliente2(int id)
        {

            string result = "";
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_NOMBRE_CLIENTE_REPORTE @PK_REPORTE";
            comando.Parameters.AddWithValue("@PK_REPORTE", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
   
                result = list.GetString(0);


            }
            list.Dispose();
            comando.Dispose();
            return result;


        }

        public string ObtenerNombreServicio(int id)
        {

            string result = "";
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_NOMBRE_SERVICIO_REPORTE @PK_REPORTE";
            comando.Parameters.AddWithValue("@PK_REPORTE", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetString(0);


            }
            list.Dispose();
            comando.Dispose();
            return result;


        }

        public double ObtenerHorasTotales(int id)
        {

            double result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_HORAS_TOTALES @PK_CONTRATO";
            comando.Parameters.AddWithValue("@PK_CONTRATO", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetDouble(0);


            }
            list.Dispose();
            comando.Dispose();
            return result;


        }

        public double ObtenerHorasConsumidas(int id)
        {

            double result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_HORAS_CONSUMIDAS @PK_CONTRATO";
            comando.Parameters.AddWithValue("@PK_CONTRATO", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetDouble(0);


            }
            list.Dispose();
            comando.Dispose();
            return result;


        }



        public List<Contrato> ObtenerNombreContratoProyecto(int id)
        {
            List<Contrato> listaContactos = new List<Contrato>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "exec PA_CTRL_MAN_OBTENER_NOMBRE_CONTRATO_PROYECTO @PK_REPORTE";
            comando.Parameters.AddWithValue("@PK_REPORTE", id);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Contrato cont = new Contrato();
                cont.NOMBRE_CONTRATO = list.GetString(0);

                listaContactos.Add(cont);
            }
            list.Dispose();
            comando.Dispose();
            return listaContactos;

        }
    }
}
