using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Seguridad;
using Pechkin;

namespace Biblioteca_Clases.DAO
{
    public class Mail
    {

        string Correo = "", SMTP = "", Puerto = "", Contrasenna1 = "";
        List<Tabla_Configuracion> listaConfiguracion = new List<Tabla_Configuracion>();
        Encryption encryption = new Encryption();
        Tabla_ConfiguracionDAO dao = new Tabla_ConfiguracionDAO();
        ReporteDAO dao_reporte = new ReporteDAO();
        public string Contrasenna()
        {

            Random rdn = new Random();
            // string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }

        public void mail(string correo, string contrasenna)
        {
            try
            {
                listaConfiguracion = dao.Correo_Configuracion();

                foreach (var dato in listaConfiguracion)
                {

                    if (dato.LLAVE04.Equals("CORREO"))
                    {
                        Correo = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("SMTP"))
                    {
                        SMTP = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("PUERTO"))
                    {
                        Puerto = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("CONTRASENNA"))
                    {
                        Contrasenna1 = dato.VALOR;
                    }
                }
                MailMessage email = new MailMessage();

                email.To.Add(new MailAddress(correo));
                email.From = new MailAddress(Correo);
                email.Subject = "Cambio de contraseña ";
                email.Body = "<html >" +
                "<body style='margin: 0; padding: 0;'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                "<tr>" +
                "<td style='padding: 20px 0 30px 0;'>" +
                "<table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse; border: 1px solid #cccccc;'>" +
                "<tr>" +
                "<td align='center' bgcolor='#1B252F' style='padding: 0px 0 0px 0;'>" +
                "<img src='http://www.sitsacr.net/Media/IMG/Dynamic/Home/Carousel/1Imagen%201.png' alt='Creating Email Magic.' width='600' height='280' style='display: block;' />" +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;'>" +
                "<tr>" +
                "<td style='color: #153643; font-family: Arial, sans-serif;'>" +
                "<h1 style='font-size: 24px; margin: 0;'> Estimado Usuario:</h1>" +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px; padding: 20px 0 30px 0;'>" +
                "<p style='margin: 0;'> Su nueva contraseña es:<br><br> <center><strong> " + contrasenna + "</strong></center><br> <br>Podrá cambiarla en el sistema por una personalizada una vez iniciada la sesión.</p>" +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td bgcolor='#1B252F' style='padding: 30px 30px;'>'" +
                "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;'>" +
                "<tr>" +
                "<td style='color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;'>" +
                "<p style='margin: 0;'>  &reg; SITSA <br/> Soluciones Integrales en Tecnología</p>" +
                "</td>" +
                "<td align='right'>" +
                "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
                "<tr>" +
                "<td>" +
                "<a href='https://www.facebook.com/SITSACostaRica'>" +
                "<img src='https://cdn.icon-icons.com/icons2/220/PNG/512/facebook_25551.png' alt='Twitter.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='https://api.whatsapp.com/send?phone=50661934435&text=Hola%20SITSA!%20Me%20gustaría%20adquirir%20información%20de%20sus%20productos%20y%20servicios'>" +
                "<img src='https://cdn.icon-icons.com/icons2/373/PNG/256/Whatsapp_37229.png' alt='whatsapp.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='tel:+506 24312925'>" +
                "<img src='https://cdn.icon-icons.com/icons2/196/PNG/128/phone_23732.png' alt='Telefono.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='mailto:comercial@sitsacr.net'>" +
                "<img src='https://cdn.icon-icons.com/icons2/1195/PNG/512/1490889681-email_82528.png' alt='Email.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</body>" +
                "</html>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;




                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP;
                smtp.Port = Int32.Parse(Puerto);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(correo, Contrasenna1);

                string output = null;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);

            }
            catch (Exception e)
            {
                string hola = e.Message;

            }


        }

        public void agregar_usuario_mail(string correo, string contrasenna)
        {

            try
            {
                listaConfiguracion = dao.Correo_Configuracion();

                foreach (var dato in listaConfiguracion)
                {

                    if (dato.LLAVE04.Equals("CORREO"))
                    {
                        Correo = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("SMTP"))
                    {
                        SMTP = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("PUERTO"))
                    {
                        Puerto = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("CONTRASENNA"))
                    {
                        Contrasenna1 = dato.VALOR;
                    }
                }

                MailMessage email = new MailMessage();


                email.To.Add(new MailAddress(correo));


                email.From = new MailAddress(Correo);
                email.Subject = "Registro de usuario";
                email.Body =
                                  "<html >" +
                   "<body style='margin: 0; padding: 0;'>" +
                   "<table role='presentation' border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                   "<tr>" +
                   "<td style='padding: 20px 0 30px 0;'>" +
                   "<table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border-collapse: collapse; border: 1px solid #cccccc;'>" +
                   "<tr>" +
                   "<td align='center' bgcolor='#1B252F' style='padding: 0px 0 0px 0;'>" +
                   "<img src='http://www.sitsacr.net/Media/IMG/Dynamic/Home/Carousel/1Imagen%201.png' alt='Creating Email Magic.' width='600' height='280' style='display: block;' />" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td bgcolor='#ffffff' style='padding: 40px 30px 40px 30px;'>" +
                   "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;'>" +
                   "<tr>" +
                   "<td style='color: #153643; font-family: Arial, sans-serif;'>" +
                   "<h1 style='font-size: 24px; margin: 0;'> Estimado Usuario:</h1>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td style='color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px; padding: 20px 0 30px 0;'>" +
                   "<p style='margin: 0;'> La contraseña autogenerada de su cuenta es:<br><br><center><strong> " + contrasenna + "</strong></center><br><br> Podrá cambiarla en el sistema por una personalizada una vez iniciada la sesión.</p>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "<tr>" +
                   "<td bgcolor='#1B252F' style='padding: 30px 30px;'>'" +
                   "<table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse: collapse;'>" +
                   "<tr>" +
                   "<td style='color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;'>" +
                   "<p style='margin: 0;'>  &reg; SITSA <br/> Soluciones Integrales en Tecnología</p>" +
                   "</td>" +
                   "<td align='right'>" +
                   "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
                   "<tr>" +
                   "<td>" +
                   "<a href='https://www.facebook.com/SITSACostaRica'>" +
                   "<img src='https://cdn.icon-icons.com/icons2/220/PNG/512/facebook_25551.png' alt='Twitter.' width='38' height='38' style='display: block;' border='0' />" +
                   "</a>" +
                   "</td>" +
                   "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                   "<td>" +
                   "<a href='https://api.whatsapp.com/send?phone=50661934435&text=Hola%20SITSA!%20Me%20gustaría%20adquirir%20información%20de%20sus%20productos%20y%20servicios'>" +
                   "<img src='https://cdn.icon-icons.com/icons2/373/PNG/256/Whatsapp_37229.png' alt='whatsapp.' width='38' height='38' style='display: block;' border='0' />" +
                   "</a>" +
                   "</td>" +
                   "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                   "<td>" +
                   "<a href='tel:+506 24312925'>" +
                   "<img src='https://cdn.icon-icons.com/icons2/196/PNG/128/phone_23732.png' alt='Telefono.' width='38' height='38' style='display: block;' border='0' />" +
                   "</a>" +
                   "</td>" +
                   "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                   "<td>" +
                   "<a href='mailto:comercial@sitsacr.net'>" +
                   "<img src='https://cdn.icon-icons.com/icons2/1195/PNG/512/1490889681-email_82528.png' alt='Email.' width='38' height='38' style='display: block;' border='0' />" +
                   "</a>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</td>" +
                   "</tr>" +
                   "</table>" +
                   "</body>" +
                   "</html>";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;




                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP;
                smtp.Port = Int32.Parse(Puerto);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Correo, Contrasenna1);

                string output = null;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);








            }
            catch (Exception e)
            {
                string hola = e.Message;

            }


        }

        public void Enviar_Resporte_Correo(string PK_ID_REPORTE, Reporte reporte, List<Detalle_Reporte> detalles_reporte, String Nombre_cliente, string[] correos)
        {
           
            GenerarPDF(PK_ID_REPORTE, reporte, detalles_reporte, Nombre_cliente);
            string pk_reporte = encryption.Decrypt(PK_ID_REPORTE);
            try
            {
                string filename = @"c:\\Pdf\\Reporte#"+pk_reporte+".pdf";
                Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
                listaConfiguracion = dao.Correo_Configuracion();

                foreach (var dato in listaConfiguracion)
                {

                    if (dato.LLAVE04.Equals("CORREO"))
                    {
                        Correo = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("SMTP"))
                    {
                        SMTP = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("PUERTO"))
                    {
                        Puerto = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("CONTRASENNA"))
                    {
                        Contrasenna1 = dato.VALOR;
                    }
                }

                MailMessage email = new MailMessage();
             

                for (int i = 0; i < correos.Length - 1; i++)
                {
                 
                    email.To.Add(new MailAddress(correos[i]));

                  
                }

                email.From = new MailAddress(Correo);
                email.Subject = "Informe de contrato";
                email.Body =  
                "<html>" +
                "<body style = 'margin: 0; padding: 0;' >" +
                "<table role = 'presentation' border = '0' cellpadding = '0' cellspacing = '0' width = '100%' >       <tr >" +
                "<td style = 'padding: 20px 0 30px 0;' >" +
                "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600' style = 'border-collapse: collapse; border: 1px solid #cccccc;' >" +
                "<tr >" +
                "<td align = 'center' bgcolor = '#1B252F' style = 'padding: 0px 0 0px 0;' >" +
                "<img src = 'http://www.sitsacr.net/Media/IMG/Dynamic/Home/Carousel/1Imagen%201.png?v=6899' alt = 'Creating Email Magic.' width = '600' height = '280' style = 'display: block;' />" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td bgcolor = '#ffffff' style = 'padding: 40px 30px 40px 30px;' >" +
                "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'border-collapse: collapse;' >" +
                "<tr >" +
                "<td style = 'color: #153643; font-family: Arial, sans-serif;' >" +
                "<h1 style = 'font-size: 24px; margin: 0;' > Estimado cliente:</h1 >" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td style = 'color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px; padding: 20px 0 30px 0;' >" +
                "<p style = 'margin: 0;' > Adjunto se encuentra el estado del informe del contrato. <br><br>Por medio del <a href = 'https://localhost:44375/Reporte_Aceptacion.aspx?key="+PK_ID_REPORTE+ "'> enlace</a> puede realizar la aprobación o rechazo del mismo. </p >" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td >" +
                "</td >" +
                "</tr >" +
                "</table >" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td bgcolor = '#1B252F' style = 'padding: 30px 30px;' >" +
                "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'border-collapse: collapse;' >" +
                "<tr >" +
                "<td style = 'color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' >" +
                "<p style = 'margin: 0;' > &reg; SITSA <br />" +
                "Soluciones Integrales en Tecnología </p >" +
                "</td >" +
                "<td align = 'right' >" +
                "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
                "<tr>" +
                "<td>" +
                "<a href='https://www.facebook.com/SITSACostaRica'>" +
                "<img src='https://cdn.icon-icons.com/icons2/220/PNG/512/facebook_25551.png' alt='Twitter.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='https://api.whatsapp.com/send?phone=50661934435&text=Hola%20SITSA!%20Me%20gustaría%20adquirir%20información%20de%20sus%20productos%20y%20servicios'>" +
                "<img src='https://cdn.icon-icons.com/icons2/373/PNG/256/Whatsapp_37229.png' alt='whatsapp.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='tel:+506 24312925'>" +
                "<img src='https://cdn.icon-icons.com/icons2/196/PNG/128/phone_23732.png' alt='Telefono.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                "<td>" +
                "<a href='mailto:comercial@sitsacr.net'>" +
                "<img src='https://cdn.icon-icons.com/icons2/1195/PNG/512/1490889681-email_82528.png' alt='Email.' width='38' height='38' style='display: block;' border='0' />" +
                "</a>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td >" +
                "</tr >" +
                "</table >" +
                "</td>" +
                "</tr >" +
                "</table >" +
                "</td >" +
                "</tr >" +
                "</table >" +
                "</body >" +
                "</html > ";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;
                email.Attachments.Add(data);



                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP;
                smtp.Port = Int32.Parse(Puerto);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Correo, Contrasenna1);

                string output = null;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);


            }
            catch (Exception e)
            {
                string hola = e.Message;

            }

        }

        public void Enviar_Resporte_Correo_Proyecto(string PK_ID_REPORTE, Reporte reporte, Detalle_Reporte detalle_Reporte, String nombre_cliente, string[] correos)
        {
            GenerarPDFProyecto(PK_ID_REPORTE, reporte, detalle_Reporte, nombre_cliente);
            string pk_reporte = encryption.Decrypt(PK_ID_REPORTE);
            try
            {
                string filename = @"c:\\Pdf\\Reporte#"+pk_reporte+".pdf";
                Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);

                listaConfiguracion = dao.Correo_Configuracion();

                foreach (var dato in listaConfiguracion)
                {

                    if (dato.LLAVE04.Equals("CORREO"))
                    {
                        Correo = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("SMTP"))
                    {
                        SMTP = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("PUERTO"))
                    {
                        Puerto = dato.VALOR;
                    }
                    if (dato.LLAVE04.Equals("CONTRASENNA"))
                    {
                        Contrasenna1 = dato.VALOR;
                    }
                }
                MailMessage email = new MailMessage();

               


                for (int i = 0; i < correos.Length - 1; i++)
                {

                    email.To.Add(new MailAddress(correos[i]));


                }

                email.From = new MailAddress(Correo);
                email.Subject = "Cambio de contrasenna ";
                email.Body =
                    "<html>" +
                    "<body style = 'margin: 0; padding: 0;' >" +
                    "<table role = 'presentation' border = '0' cellpadding = '0' cellspacing = '0' width = '100%' >       <tr >" +
                    "<td style = 'padding: 20px 0 30px 0;' >" +
                    "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600' style = 'border-collapse: collapse; border: 1px solid #cccccc;' >" +
                    "<tr >" +
                    "<td align = 'center' bgcolor = '#1B252F' style = 'padding: 0px 0 0px 0;' >" +
                    "<img src = 'http://www.sitsacr.net/Media/IMG/Dynamic/Home/Carousel/1Imagen%201.png?v=6899' alt = 'Creating Email Magic.' width = '600' height = '280' style = 'display: block;' />" +
                    "</td >" +
                    "</tr >" +
                    "<tr >" +
                    "<td bgcolor = '#ffffff' style = 'padding: 40px 30px 40px 30px;' >" +
                    "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'border-collapse: collapse;' >" +
                    "<tr >" +
                    "<td style = 'color: #153643; font-family: Arial, sans-serif;' >" +
                    "<h1 style = 'font-size: 24px; margin: 0;' > Estimado cliente:</h1 >" +
                    "</td >" +
                    "</tr >" +
                    "<tr >" +
                    "<td style = 'color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px; padding: 20px 0 30px 0;' >" +
                    "<p style = 'margin: 0;' > Adjunto se encuentra el estado del informe del contrato. <br><br>Por medio del <a href = 'https://localhost:44375/Reporte_Aceptacion.aspx?key="+PK_ID_REPORTE+ "'> enlace</a> puede realizar la aprobación o rechazo del mismo. </p >" +
                    "</td >" +
                    "</tr >" +
                    "<tr >" +
                    "<td >" +
                    "</td >" +
                    "</tr >" +
                    "</table >" +
                    "</td >" +
                    "</tr >" +
                    "<tr >" +
                    "<td bgcolor = '#1B252F' style = 'padding: 30px 30px;' >" +
                    "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'border-collapse: collapse;' >" +
                    "<tr >" +
                    "<td style = 'color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' >" +
                    "<p style = 'margin: 0;' > &reg; SITSA <br />" +
                    "Soluciones Integrales en Tecnología </p >" +
                    "</td >" +
                    "<td align = 'right' >" +
                    "<table border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse;'>" +
                    "<tr>" +
                    "<td>" +
                    "<a href='https://www.facebook.com/SITSACostaRica'>" +
                    "<img src='https://cdn.icon-icons.com/icons2/220/PNG/512/facebook_25551.png' alt='Twitter.' width='38' height='38' style='display: block;' border='0' />" +
                    "</a>" +
                    "</td>" +
                    "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                    "<td>" +
                    "<a href='https://api.whatsapp.com/send?phone=50661934435&text=Hola%20SITSA!%20Me%20gustaría%20adquirir%20información%20de%20sus%20productos%20y%20servicios'>" +
                    "<img src='https://cdn.icon-icons.com/icons2/373/PNG/256/Whatsapp_37229.png' alt='whatsapp.' width='38' height='38' style='display: block;' border='0' />" +
                    "</a>" +
                    "</td>" +
                    "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                    "<td>" +
                    "<a href='tel:+506 24312925'>" +
                    "<img src='https://cdn.icon-icons.com/icons2/196/PNG/128/phone_23732.png' alt='Telefono.' width='38' height='38' style='display: block;' border='0' />" +
                    "</a>" +
                    "</td>" +
                    "<td style='font-size: 0; line-height: 0;' width='20'> &nbsp; </td>" +
                    "<td>" +
                    "<a href='mailto:comercial@sitsacr.net'>" +
                    "<img src='https://cdn.icon-icons.com/icons2/1195/PNG/512/1490889681-email_82528.png' alt='Email.' width='38' height='38' style='display: block;' border='0' />" +
                    "</a>" +
                    "</td>" +
                    "</tr>" +
                    "</table>" +
                    "</td >" +
                    "</tr >" +
                    "</table >" +
                    "</td>" +
                    "</tr >" +
                    "</table >" +
                    "</td >" +
                    "</tr >" +
                    "</table >" +
                    "</body >" +
                    "</html > ";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;
                email.Attachments.Add(data);



                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP;
                smtp.Port = Int32.Parse(Puerto);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Correo, Contrasenna1);

                string output = null;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);


            }
            catch (Exception e)
            {
                string hola = e.Message;

                Console.WriteLine(hola);

            }

        }






        public void GenerarPDF(string PK_ID_REPORTE, Reporte reporte, List<Detalle_Reporte> detalles_reporte, String nombre_cliente)
        {
            string cadena = "", tipo = "";

            tipo = "Reporte de contrato";
            string pk_reporte = encryption.Decrypt(PK_ID_REPORTE);

            double horas_totales = dao_reporte.ObtenerHorasTotales(reporte.ID_CONTRATO);
            double horas_consumidas = dao_reporte.ObtenerHorasConsumidas(reporte.ID_CONTRATO);


            double tarifa_total = 0;

            foreach (var dato in detalles_reporte)
            {

                string nombre_servicio = dao_reporte.ObtenerNombreServicio(dato.ID_SERVICIO);


                tarifa_total = tarifa_total + dato.TARIFA;

                cadena = cadena + "<tr><td>" + nombre_servicio + "</td>" +
                    "<td>" + dato.OBSERVACION + "</td>" +
                    "<td>" + dato.TARIFA + "</td>" +
                    "<td>" + dato.HORAS + "</td>";
            }



            byte[] pdfContent = new SimplePechkin(new GlobalConfig()).Convert("<html><body style='background - color: #E3F5FF '><CENTER> <TABLE style = 'font-family: arial;'  WIDTH ='80%'><TR><TD WIDTH ='75%'><h2 style = 'color: #1B252F'> Soluciones <strong> S.I.T.S.A </strong></h2><h4><a href = 'http://www.sitsacr.net'> www.sitsacr.net </a></h4><h4><a> ventas@sitsacr.net </a></h4><p> Tel: 2431 - 2925 </p><hr style = 'border-color: #707070;'><p> 50 m.Sur del Scotiabank Alajuela Centro <br/> <strong> 'Avenida Juan Lopez del corral' </strong></p><TD style = 'font-family: arial;'><center><h1 style = 'color: #1B252F'> S.I.T.S.A </h1> Soluciones Integrales en Tecnología </center><center> </TABLE><TABLE style = 'font-family: arial;'  WIDTH=80%><TR><TD ><hr style ='border-color: #707070;'><center><p style ='font-size: 24px;'> Reporte #" + pk_reporte + "</p> <h2>S.I.T.S.A</h2></center><TR> <TD><hr style = 'border-color: #707070;' ><label style = 'font-size: 18px;'><strong> Cliente:</strong> </label> " + nombre_cliente + " &nbsp &nbsp &nbsp <label style = 'font-size: 18px; font-family: arial;'> <strong> Fecha:</strong > </label > " + reporte.FECHA + "<br><br><br><br> <label style = 'font-size: 18px;'> <strong> Tipo de reporte: </strong > </label > &nbsp  " + tipo + "<br> <br><label style = 'font-size: 18px;'> <strong> Horas totales: </strong > </label > &nbsp " + horas_totales + " <br><br> <label style = 'font-size: 18px;'> <strong> Horas consumidas: </strong> </label > &nbsp " + reporte.CANTIDAD_HORAS + " <br><br> <label style = 'font-size: 18px;'> <strong > Horas disponibles: </strong ></label> &nbsp " + horas_consumidas + "</TABLE> <CENTER><TABLE style = 'font-family: arial;'  WIDTH=80%> <TR > <TR ><TD ><hr style = 'border-color: #707070;' ><label style = 'font-size: 18px;' ><strong > Servicios:</strong > </label > <br><br><table border style = 'width:100%;'> <thead ><tr ><th> Servicio </th ><th > Descripción </th ><th > Monto </th ><th > Horas </th ></tr></thead > <tbody >    " + cadena + "   </tbody>        </table><br><br>         <label style = 'font-size: 18px;' > <strong > Monto total: </strong> </label> &nbsp " + tarifa_total + "<br><br></TABLE><CENTER><TABLE style = 'font-family: arial;'  WIDTH=80%><TR ><TR ><TD ><hr style= 'border-color: #707070;' ><label style= 'font-size: 18px;'><strong> Pendientes / Observaciones:</strong> </label><br><br><textarea  style='width:100%; height: 100px; font-family: arial; font-size: 18px;'>" + reporte.OBSERVACION + "</textarea><br><br><CENTER><a href = 'https://localhost:44375/Reporte_Aceptacion.aspx?key=" + PK_ID_REPORTE + "'><button style='border-radius: 12px; font-family: arial; font-size: 16px; background-color: #e7e7e7; color: black;'>Cambiar estado</button></a></CENTER></TABLE></body</html>");



            // Folder where the file will be created 
            string directory = "C:\\Pdf\\";
            // Name of the PDF
            string filename = "Reporte#"+pk_reporte+".pdf";

            if (ByteArrayToFile(directory + filename, pdfContent))
            {
                Console.WriteLine("PDF Succesfully created");
            }
            else
            {
                Console.WriteLine("Cannot create PDF");
            }
        }
        public void GenerarPDFProyecto(string PK_ID_REPORTE, Reporte reporte, Detalle_Reporte detalle_Reporte, string nombre_cliente)
        {

            string pk_reporte = encryption.Decrypt(PK_ID_REPORTE);


            string tipo = "";
            tipo = "Reporte de Proyecto";






            byte[] pdfContent = new SimplePechkin(new GlobalConfig()).Convert("<html><body style='background - color: #E3F5FF '><CENTER> <TABLE style = 'font-family: arial;'  WIDTH ='80%'><TR><TD WIDTH ='75%'><h2 style = 'color: #1B252F'> Soluciones <strong> S.I.T.S.A </strong></h2><h4><a href = 'http://www.sitsacr.net'> www.sitsacr.net </a></h4><h4><a> ventas@sitsacr.net </a></h4><p> Tel: 2431 - 2925 </p><hr style = 'border-color: #707070;'><p> 50 m.Sur del Scotiabank Alajuela Centro <br/> <strong> 'Avenida Juan Lopez del corral' </strong></p><TD style = 'font-family: arial;'><center><h1 style = 'color: #1B252F'> S.I.T.S.A </h1> Soluciones Integrales en Tecnología </center><center> </TABLE><TABLE style = 'font-family: arial;'  WIDTH=80%><TR><TD ><hr style ='border-color: #707070;'><center><p style ='font-size: 24px;'> Reporte #" + pk_reporte + "</p> <h2>S.I.T.S.A</h2></center><TR> <TD><hr style = 'border-color: #707070;' ><label style = 'font-size: 18px;'><strong> Cliente:</strong> </label> " + nombre_cliente + " &nbsp &nbsp &nbsp <label style = 'font-size: 18px; font-family: arial;'> <strong> Fecha:</strong > </label > " + reporte.FECHA + "<br><br> <label style = 'font-size: 18px;'> <strong> Tipo de reporte: </strong > </label > &nbsp  " + tipo + "<br> <br>      <label style = 'font-size: 18px;' > <strong > Monto consumido: </strong> </label> &nbsp  " + detalle_Reporte.TARIFA + "<br><br></TABLE><CENTER><TABLE style = 'font-family: arial;'  WIDTH=80%><TR ><TR ><TD ><hr style= 'border-color: #707070;' ><label style= 'font-size: 18px;'><strong> Pendientes / Observaciones:</strong> </label><br><br><textarea style='width:100%; height: 100px; font-family: arial; font-size: 18px; font-color:black;'>" + reporte.OBSERVACION + "</textarea><br><br><CENTER><a href = 'https://localhost:44375/Reporte_Aceptacion.aspx?key=" + PK_ID_REPORTE + "'><button style='border-radius: 12px; font-family: arial; font-size: 16px; background-color: #e7e7e7; color: black;'>Cambiar estado</button></a></CENTER></TABLE></body</html>");



            // Folder where the file will be created 
            string directory = "C:\\Pdf\\";
            // Name of the PDF
            string filename = "Reporte#"+pk_reporte+".pdf";

            if (ByteArrayToFile(directory + filename, pdfContent))
            {
                Console.WriteLine("PDF Succesfully created");
            }
            else
            {
                Console.WriteLine("Cannot create PDF");
            }
        }
        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from  a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // Close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process while trying to save : {0}", _Exception.ToString());
            }

            return false;
        }

    }
}