using MailKit.Net.Smtp;
using AWF.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace AWF.Services.Implementation
{
    public class CorreoService : ICorreoService
    {

        private readonly IConfiguration _configuration;
        private readonly string _host;
        private readonly int _port;
        private readonly string _user;
        private readonly string _pass;
        public CorreoService(IConfiguration configuration)
        {
            _configuration = configuration;

            _host = _configuration["Smtp:host"]!;
            _port = Convert.ToInt32(_configuration["Smtp:port"]!);
            _user = _configuration["Smtp:user"]!;
            _pass = _configuration["Smtp:pass"]!;
        }

        public async Task Enviar(string para, string asunto, string msjHtml)
        {
            using var _smtp = new SmtpClient();
            _smtp.Connect(_host, _port, SecureSocketOptions.StartTls);
            _smtp.Authenticate(_user, _pass);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_user));
            email.To.Add(MailboxAddress.Parse(para));
            email.Subject = asunto;
            email.Body = new TextPart(TextFormat.Html) { Text = msjHtml };

            await _smtp.SendAsync(email);
            await _smtp.DisconnectAsync(true);
        }

    }
}