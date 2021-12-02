using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PruebaAlmacenes.Utilities
{
    public class SendEmail
    {
        // Variable global para dominio
        string urlDomain = "http://localhost:64759";

        public void Send(string EmailDestino, string token)
        {
            try
            {
                string EmailOrigen = "devcsgt@gmail.com";
                string Password = "C#testString";
                string Url = urlDomain + "/Access/Recovery/?token=" + token;                

                MailMessage mail = new MailMessage(EmailOrigen, EmailDestino,  "Almacenes Japon - Recuperar Contraseña",
                    "<p>Correo de recuperación de contraseña.</p>" +
                    "<a href = '" + Url + "'> Clic aquí para recuperar su Contraseña.</a>"
                    );

                mail.IsBodyHtml = true;
                

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(EmailOrigen, Password);

                smtpClient.Send(mail);
                smtpClient.Dispose();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            
        }
    }
}