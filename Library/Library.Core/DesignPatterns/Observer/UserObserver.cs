
using System.Net.Mail;
using System.Net;

namespace Library.Core.DesignPatterns.Observer
{
    public class UserObserver : IUserObserver
    {
       public string EmailAddress { get; set; }
        public UserObserver(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
        public void NotifyAsync(ComicBook book)
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
            MailAddress toAdress = new MailAddress(EmailAddress);
            MailMessage message = new MailMessage()
            {
                From = fromAdress,
                Subject = $"Your comic {book.Title} is available!",
                Body = $"Hello!\n{book.Title} by {book.Publisher} is now available!"
            };
            message.To.Add(EmailAddress);
            smtpClient.Send(message);
        }

    } 

      
}
