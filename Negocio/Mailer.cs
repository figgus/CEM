using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Mailer
    {
        public string From{ get; set; }
        public string To{ get; set; }
        public string Asunto{ get; set; }
        public string Mensaje { get; set; }
        public string ClienteSTMP{ get; set; }

        //Credenciales del remitente
        public string Username { get; set; }
        public string Password { get; set; }

        public Mailer(string to, string asunto, string mensaje)
        {
            To = to;
            Asunto = asunto;
            Mensaje = mensaje;
            From = "jgamboa007@gmail.com";
            To = "joa.gamboa@alumnos.duoc.cl";
            ClienteSTMP = "smtp.gmail.com";
            Username = "";
            Password = "";
        }

        public void sendEmail()
        {
            MailMessage mail = new MailMessage(From, To, Asunto, Mensaje);
            SmtpClient client = new SmtpClient(ClienteSTMP);
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(Username, Password);
            client.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback =

               delegate (object s

                   , X509Certificate certificate

                   , X509Chain chain

                   , SslPolicyErrors sslPolicyErrors)

               { return true; };
            client.Send(mail);
        }
    }
}
