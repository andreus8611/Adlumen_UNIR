using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace AdlumenMVC.WebUI.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            //var text = message.Body;
            //var html = message.Body;

            //var msg = new MailMessage();
            //msg.From = new MailAddress("spirit.tech.solution.adlumen.roberto@outlook.com", "Adlumen.org");
            //msg.To.Add(new MailAddress(message.Destination));
            //msg.Subject = message.Subject;
            //msg.Body = message.Body;
            ////msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            ////msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            //var smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            //var credentials = new NetworkCredential("spirit.tech.solution.adlumen.roberto@outlook.com", "Adlumen2015!");

            //smtpClient.Credentials = credentials;
            //smtpClient.EnableSsl = true;
            //smtpClient.Send(msg);



            var apiKey = ConfigurationManager.AppSettings["emailService:Password"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@adlumen.org", "Adlumen.org");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination);
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);




            //var myMessage = new SendGridMessage();

            //myMessage.AddTo(message.Destination);
            //myMessage.From = new System.Net.Mail.MailAddress("no-reply@adlumen.org", "Recuperar Contraseña");
            //myMessage.Subject = message.Subject;
            //myMessage.Text = message.Body;
            //myMessage.Html = message.Body;

            ////var credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"], 
            ////                                        ConfigurationManager.AppSettings["emailService:Password"]);

            //var apiKey = ConfigurationManager.AppSettings["emailService:Password"];

            //var transportWeb = new SendGrid.Web(apiKey);

            //if (transportWeb != null)
            //{
            //    await transportWeb.DeliverAsync(myMessage);
            //}
            //else
            //{
            //    //Trace.TraceError("Failed to create Web transport.");
            //    await Task.FromResult(0);
            //}
        }
    }
}