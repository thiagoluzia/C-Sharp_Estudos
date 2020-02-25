using System.Net.Mail;
using CSharpOO.SOLID.DIP.Solucao.Interfaces;

//DIP = Princ�pio da Invers�o de Depend�ncia
namespace CSharpOO.SOLID.DIP.Solucao
{
    public class EmailServices : IEmailServices
    {
        public bool IsValid(string email)
        {
            return email.Contains("@");
        }

        public void Enviar(string de, string para, string assunto, string mensagem)
        {
            var mail = new MailMessage(de, para);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = mensagem;
            client.Send(mail);
        }
    }
}