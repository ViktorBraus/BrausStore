using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "bookstore@example.com";
        public bool UseSsl = true;
        public string UserName = "MySmtptUserName";
        public string Password = "MySmtptPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsfile = true;
        public string FileLocation = @"c:\book_store_emails";
    }
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }
            public void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingDetails)
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = emailSettings.UseSsl;
                    smtpClient.Host = emailSettings.ServerName;
                    smtpClient.Port = emailSettings.ServerPort;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                    if(emailSettings.WriteAsfile)
                    {
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                        smtpClient.EnableSsl = false;
                    }
                    StringBuilder body = new StringBuilder()
                        .AppendLine("Нове замовлення прийнято на обробку")
                        .AppendLine("-------")
                        .AppendLine("Товари: ");
                    foreach(var line in cart.Lines)
                    {
                        var subtotal = line.Book.Price * line.Quantity;
                        body.AppendFormat("{0} x {1} (загалом: {2:c}",line.Quantity, line.Book.Name, subtotal);
                    }
                    body.AppendFormat("Загальна вартість: {0:c}", cart.ComputeTotalValue())
                        .AppendLine("-----")
                        .AppendLine("Доставка: ")
                        .AppendLine(shippingDetails.Name)
                        .AppendLine(shippingDetails.Line1)
                        .AppendLine(shippingDetails.City)
                        .AppendLine(shippingDetails.Country)
                        .AppendLine("-----")
                        .AppendFormat("Подарункова упаковка: {0}", shippingDetails.GiftWrap ? "+":"-");
                    MailMessage mailMessage = new MailMessage(
                        emailSettings.MailFromAddress,
                        emailSettings.MailToAddress,
                        "Нове замовлення відправлено!",
                        body.ToString()
                        );
                    if(emailSettings.WriteAsfile)
                    {
                        mailMessage.BodyEncoding = Encoding.UTF8;
                    }
                   smtpClient.Send(mailMessage);
                }
            }
        
    }
}

