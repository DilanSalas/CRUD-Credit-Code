using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;

namespace CreditFullSA.Models
{
    public class Email
    {
        public void Enviar(Credito credito, string html)
        {
            try
            {
                MailMessage email = new MailMessage();
                email.Subject = "Datos de registro en la plataforma";
                email.To.Add(new MailAddress(credito.email));
                email.Bcc.Add(new MailAddress("Lenguajes2023G2@outlook.com"));
                email.From = new MailAddress("Lenguajes2023G2@outlook.com");
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;
                AlternateView view = AlternateView.CreateAlternateViewFromString(html,Encoding.UTF8,MediaTypeNames.Text.Html);
                email.AlternateViews.Add(view);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("Lenguajes2023G2@outlook.com", "Ucr2023*");
                smtp.Send(email);
                smtp.Dispose();
                email.Dispose();

            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }//Enviar
    }//class
}//namesspace
