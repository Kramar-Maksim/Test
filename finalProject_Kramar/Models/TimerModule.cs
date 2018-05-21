using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace finalProject_Kramar.Models
{
    public class TimerModule : IHttpModule
    {
        static Timer timer;
        long interval = 30000; //30 секунд
        static object synclock = new object();
        static bool sent = false;

        public void Init(HttpApplication app)
        {
            timer = new Timer(new TimerCallback(SendEmail), null, 0, interval);
        }

        private void SendEmail(object obj)
        {
            lock (synclock)
            {
                DateTime dd = DateTime.Now;
                if (dd.Hour == 1 && dd.Minute == 30 && sent == false)
                {
                    // настройки smtp-сервера, с которого мы и будем отправлять письмо
                    SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("somemail@gmail.com", "password");

                    // наш email с заголовком письма
                    MailAddress from = new MailAddress("somemail@gmail.com", "Test");
                    // кому отправляем
                    MailAddress to = new MailAddress("othermail@yandex.ru");
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Test mail";
                    // текст письма
                    m.Body = "Рассылка сайта";
                    smtp.Send(m);
                    sent = true;
                }
                else if (dd.Hour != 1 && dd.Minute != 30)
                {
                    sent = false;
                }
            }
        }
        public void Dispose()
        { }
    }
}