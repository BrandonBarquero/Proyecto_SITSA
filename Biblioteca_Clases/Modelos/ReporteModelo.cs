using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Seguridad;

namespace Biblioteca_Clases.Modelos
{
    public class ReporteModelo
    {
        ContratoDAO dao_contrato = new ContratoDAO();
        ProyectoDAO dao_proyecto = new ProyectoDAO();
        ContactoDAO dao_contacto = new ContactoDAO();
        ReporteDAO dao_reporte = new ReporteDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        ServicioDAO dao_servicio = new ServicioDAO();

        Mail mail = new Mail();
        Encryption encryption = new Encryption();
        Contacto contacto = new Contacto();

        public List<Contrato> listar_contrato_cliente(String id, int num)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = dao_contrato.listaContratosCliente(id, num);

            return contratos;
        }

        public List<Contrato> listar_contrato_cliente_garantia(String id, int num)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = dao_contrato.listaContratosCliente(id, num);

            return contratos;
        }

        public List<Proyecto> listar_proyecto_cliente(int id, int num)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = dao_proyecto.listaProyectos_cliente(id, num);

            return proyectos;
        }

        public List<Proyecto> listar_proyecto_cliente_garantia(int id, int num)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = dao_proyecto.listaProyectos_cliente(id, num);

            return proyectos;
        }

        public List<Contacto> buscar_datos_contacto(int id)
        {
            List<Contacto> contactos = new List<Contacto>();
            contactos = dao_contacto.BuscarDatosContacto(id);

            return contactos;
        }

        public int agregar_reporte(Reporte reporte, List<Detalle_Reporte> detalles_reporte, List<Detalle_Reporte> detalles_reporte_extra, string horas_disponibles, string correos, string user)
        {
            int result = 0;

            string[] vector_correo = correos.Split(',');

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = user;

            int id = dao_reporte.AgregarReporte(reporte);

            string nombre_cliente = dao_reporte.ObtenerNombreCliente2(id);

            if (detalles_reporte != null)
            {
                for (int i = 0; i < detalles_reporte.Count; i++)
                {
                    detalles_reporte[i].USUARIO_CREACION = user;
                    detalles_reporte[i].FECHA_CREACION = fecha_asignar;
                    detalles_reporte[i].FK_ID_REPORTE = id;
                }

                result = dao_reporte.AgregarDetallesReporte(detalles_reporte);
            }

            if (detalles_reporte_extra != null)
            {
                for (int i = 0; i < detalles_reporte_extra.Count; i++)
                {
                    detalles_reporte_extra[i].USUARIO_CREACION = user;
                    detalles_reporte_extra[i].FECHA_CREACION = fecha_asignar;
                    detalles_reporte_extra[i].FK_ID_REPORTE = id;
                }

                result = dao_reporte.AgregarDetallesReporteExtra(detalles_reporte_extra);
            }

            if (horas_disponibles != "f" && reporte.TIPO_DOCUMENTO != "Reporte Contrato Garantía")
            {
                double hor = Double.Parse(horas_disponibles);
                dao_contrato.RebajarHorasContrato(reporte.ID_CONTRATO, hor, user, fecha_asignar);

                if (hor == 0)
                {
                    dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, user, fecha_asignar);
                }
            }
            else
            {
                dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, user, fecha_asignar);
            }

            mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()), reporte, detalles_reporte, nombre_cliente, vector_correo);

            return result;
        }

        public int agregar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte, string correos, string user)
        {
            int result = 0;

            string[] vector_correo = correos.Split(',');

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = user;

            int id = dao_reporte.AgregarReporteProyecto(reporte);

            detalle_Reporte.USUARIO_CREACION = user;
            detalle_Reporte.FECHA_CREACION = fecha_asignar;
            detalle_Reporte.FK_ID_REPORTE = id;

            dao_reporte.CambiarEstadoReporteProyecto(reporte.ID_PROYECTO, user, fecha_asignar);

            string nombre_cliente = dao_reporte.ObtenerNombreCliente2(reporte.ID_PROYECTO);

            result = dao_reporte.AgregarDetalleReporteProyecto(detalle_Reporte);

            mail.Enviar_Resporte_Correo_Proyecto(encryption.Encrypt(id.ToString()), reporte, detalle_Reporte, nombre_cliente, vector_correo);

            return result;
        }

        public Reporte devuelve_reporte(int id)
        {
            Reporte reporte = new Reporte();
            reporte = dao_reporte.devuelve_reporte(id);

            return reporte;
        }

        public int devuelve_cliente(int id, int opc)
        {
            int cliente_id = dao_cliente.DevuelveCliente(id, opc);
            return cliente_id;
        }

        public List<Detalle_Reporte> buscar_detalle_reporte(int id, int opc)
        {
            List<Detalle_Reporte> detalles_Reporte = dao_reporte.BuscaDetallesReporte(id, opc);
            return detalles_Reporte;
        }

        public int actualizar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte, string user)
        {
            int result = 0;

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = user;

            int id = dao_reporte.ModificarReporteProyecto(reporte);

            detalle_Reporte.USUARIO_CREACION = user;
            detalle_Reporte.FECHA_CREACION = fecha_asignar;
            detalle_Reporte.FK_ID_REPORTE = reporte.PK_ID_REPORTE;

            dao_reporte.CambiarEstadoReporteProyecto(reporte.ID_PROYECTO, user, fecha_asignar);

            dao_reporte.EliminarDetallesReporte(reporte.PK_ID_REPORTE);

            result = dao_reporte.AgregarDetalleReporteProyecto(detalle_Reporte);

            // mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()));

            return result;

        }

        public int actualizar_reporte_contrato(Reporte reporte, List<Detalle_Reporte> detalles_reporte, List<Detalle_Reporte> detalles_reporte_extra, string horas_disponibles, string user)
        {
            int result = 0;

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = user;

            int id = dao_reporte.ModificarReporteContrato(reporte);

            dao_reporte.EliminarDetallesReporte(reporte.PK_ID_REPORTE);

            if (detalles_reporte != null) {
                for (int i = 0; i < detalles_reporte.Count; i++)
                {
                    detalles_reporte[i].USUARIO_CREACION = user;
                    detalles_reporte[i].FECHA_CREACION = fecha_asignar;
                    detalles_reporte[i].FK_ID_REPORTE = reporte.PK_ID_REPORTE;
                }

                result = dao_reporte.AgregarDetallesReporte(detalles_reporte);
            }
            
            

            if (detalles_reporte_extra != null)
            {
                for (int i = 0; i < detalles_reporte_extra.Count; i++)
                {
                    detalles_reporte_extra[i].USUARIO_CREACION = user;
                    detalles_reporte_extra[i].FECHA_CREACION = fecha_asignar;
                    detalles_reporte_extra[i].FK_ID_REPORTE = reporte.PK_ID_REPORTE;
                }

                result = dao_reporte.AgregarDetallesReporteExtra(detalles_reporte_extra);
            }

            if (horas_disponibles != "f" && reporte.TIPO_DOCUMENTO != "Reporte Contrato Garantía")
            {
                double hor = Double.Parse(horas_disponibles);
                dao_contrato.RebajarHorasContrato(reporte.ID_CONTRATO, hor, user, fecha_asignar);

                if (hor == 0)
                {
                    dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, user, fecha_asignar);
                }
            }
            else
            {
                dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, user, fecha_asignar);
            }

            string nombre_cliente = dao_reporte.ObtenerNombreCliente2(reporte.ID_PROYECTO);

            //   mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()), reporte, detalles_reporte, nombre_cliente);

            return result;
        }

        public int activa_contrato_proyecto(int id, int opc)
        {
            int result = dao_reporte.ActivarContratoProyecto(id, opc);
            return result;
        }

        public List<Servicio> devuelve_servicios()
        {
            List<Servicio> servicios = dao_servicio.listaServicios();
            return servicios;
        }
    }
}
