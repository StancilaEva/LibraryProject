using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public class UserObserver : IUserObserver
    {
        public string Email { get; set; }
        public UserObserver(string email)
        {
            Email = email;
        }
        public void Notify(ComicBook book)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "this.comic.book.project@gmail.com",
                    Password = "cevaParola"
                }
            };
            MailAddress fromAdress = new MailAddress("this.comic.book.project@gmail.com");
            MailAddress toAdress = new MailAddress(Email);
            MailMessage message = new MailMessage()
            {
                From = fromAdress,
                Subject = $"Your comic {book.Title} is available!",
                Body = $"Hello!\n{book.Title} by {book.Author} is now available!"
            };
            message.To.Add(Email);
            smtpClient.SendMailAsync(message);
        }

    } 

      
}
