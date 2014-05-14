using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Nucleo
{
    public class Email
    {
        public Email()
        {

        }
        public bool EnviarEmail(string endereco, string titulo, string corpo_email)
        {
            bool sucesso;
            string _to = "jvserrinox@jvserrinox.com.br";
            endereco = "site@jvserrinox.com.br";

            try
            {
                using (MailMessage mm = new MailMessage(endereco, _to))
                {
                    mm.Subject = titulo;
                    mm.Body = corpo_email;
                    //if (fuAttachment.HasFile)
                    //{
                    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                    //}
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.jvserrinox.com.br";
                    NetworkCredential NetworkCred = new NetworkCredential(_to, "JVserrinox#2014");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    sucesso = true;
                }
            }
            catch (Exception exc)
            {
                sucesso = false;
            }
            return sucesso;
        }

        public bool EnviarEmailComAnexo(string endereco, string titulo, string corpo_email , string caminho_anexo)
        {
            System.Net.Mail.MailMessage mensagem = new System.Net.Mail.MailMessage();
            System.Net.Mail.Attachment anexo = new System.Net.Mail.Attachment(caminho_anexo);
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail3.sebsa.com.br");

            bool sucesso;

            try
            {
                //enviada por
                mensagem.From = new System.Net.Mail.MailAddress("naoresponda@sebsa.com.br");
                // enviar para 
                mensagem.To.Add(endereco);
                //titulo mensagem
                mensagem.Subject = titulo;
                // anexo mensagem
                if(caminho_anexo != null)
                mensagem.Attachments.Add(anexo);
                // corpo mensagem 
                mensagem.IsBodyHtml = true;
                mensagem.Body = corpo_email;
                //servidor de saída
                smtp.Send(mensagem);
                sucesso = true;
            }
            catch (Exception)
            {
                sucesso = false;
            }
            finally
            {
                mensagem = null;
                smtp = null;
            }
            return sucesso;
        }
    }
}
