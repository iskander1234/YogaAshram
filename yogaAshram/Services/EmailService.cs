using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace yogaAshram.Services
{
    public class EmailService
    {
       

        public static async Task SendMessageAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта",
                "busindavis@yandex.kz"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new BodyBuilder() { HtmlBody = message }.ToMessageBody();
            emailMessage.Prepare(EncodingConstraint.EightBit);
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 25, false);
            await client.AuthenticateAsync("busindavis@yandex.kz", "rindoman666");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
            
        }
        public static async Task SendPassword(string email, string password, string url)
        {
            string message = $"<p>Здравствуйте!</p><p>Вы были зарегистрированы на сайте <a href=" + '"'+ url + '"' + $">{url}</a></p>" +
                             $"<p>Используйте одноразовый пароль для входа <b>{password}</b></p>" +
                             $"<p>Войти с ним можно только один раз. Как авторизуетесь, тут же поменяйте пароль. Никому его не говорите!</p>" +
                             $"<p>Переходите по <a href=" + '"' + url  +'"' + ">ссылке</a> для авторизации</p>";
            await SendMessageAsync(email, "Регистрация в Yoga Ashram", message);
        }
        
    }
}