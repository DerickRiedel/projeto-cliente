using System.Web;
using System;
using Aula2.Entidades;
using System.Net.Mail;
using System.Net;
namespace Aula2.Output
{
    public class ExportarEmail
    {
        public string NomeArquivo {get; set;}
        public ExportarEmail(string nomeArquivo){
            NomeArquivo = nomeArquivo;
        }
        public void EnviarEmail(string remetente, string destinatario, string assunto,string mensagem,string senha){
            NetworkCredential login = new NetworkCredential(remetente,senha);
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = login;
            var file = new Attachment("Dados\\"+NomeArquivo);
            var de = new MailAddress(remetente);
            var para = new MailAddress(destinatario);

            MailMessage msg = new MailMessage(de,para);

            msg.IsBodyHtml = true;

            msg.Subject = assunto;
            msg.Body = mensagem;
            msg.Attachments.Add(file);
            try
            {
                smtp.Send(msg);
            }
            catch
            {

            }
        }
    }
}
