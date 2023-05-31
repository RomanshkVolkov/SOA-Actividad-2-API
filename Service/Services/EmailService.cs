using Service.IServices;
using System.Net.Mail;
using System.Net;


namespace Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly IPersona _persona;

        public EmailService(IPersona persona)
        {
            _persona = persona;
        }

        public void SendEmail(string filePath)
        {

            string subject = "Bienvenido!!! {{name}}";
            var empleados = _persona.GetEmpleados();
            string htmlContent = System.IO.File.ReadAllText(filePath);

            // Configurar los detalles del remitente y destinatario
            string senderEmail = "202000075@estudiantes.upqroo.edu.mx";
            string senderPassword = "upqroopasskey1";

            // Configurar el cliente SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;
        


            // Enviar el correo electrónico
            empleados.ForEach((empleado) =>
            {
                // Lógica para enviar el correo electrónico a cada empleado
                string to = empleado.Correo;
            MailAddress fromAddress = new MailAddress(senderEmail);
            MailAddress toAddress = new MailAddress(to);
            // Configurar el mensaje de correo electrónico
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.Subject = subject.Replace("{{name}}", $"{empleado.Nombre} {empleado.Apellidos}");

            // Adjuntar el contenido HTML como una vista alternativa
                string body = htmlContent.Replace("{{nombreEmpleado}}", $"{empleado.Nombre} {empleado.Apellidos}");
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

            smtpClient.Send(mailMessage);
            });
        }
    }

}


