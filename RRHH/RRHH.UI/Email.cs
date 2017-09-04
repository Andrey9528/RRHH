using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RRHH.DS.Interfaces;
using System.IO;
using RRHH.DATA;
using System.Net.Mail;
using System.Net;
namespace RRHH.UI
{
    public class Email
    {
        public static void EnviarEmailAttachment(string Destinatarios, string Asunto, string Cuerpo)
        {
            DATA.Email correo = new DATA.Email();


            correo.Asunto = Asunto;
            correo.Cuerpo = Cuerpo;

            correo.Destinatarios = Destinatarios;

            foreach (var item in correo.Destinatarios)
            {
                MailMessage mail = new MailMessage();
                //mail.To.Add(new MailAddress(item));

                mail.From = new MailAddress("dollars.chat.room@hotmail.com");
                mail.Subject = correo.Asunto;

            }
        }

        public static bool Notificacion(string destino, string contra, string para, string asunto, string cuerpo)
        {
            MailMessage msj = new MailMessage();
            SmtpClient smtp = new SmtpClient();
           
            try
            {


                //parametros
                msj.From = new MailAddress(destino);
                msj.To.Add(new MailAddress(para));
                msj.Subject = asunto;
                msj.Body = cuerpo;

                //host
                smtp.Host = "smtp.live.com";
                smtp.Port = 25;
                smtp.Credentials = new NetworkCredential(destino, contra);
                smtp.EnableSsl = true;
                smtp.Send(msj);


                return true;


            }
            catch (Exception ex)
            {

                return false;

            }


        }

    }
}