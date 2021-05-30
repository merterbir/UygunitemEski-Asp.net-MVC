using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace Uygunitem
{
    public class mailGonder
    {
        public string Gonder(string urunIsim, float urunFiyat, string urunMail)
        {
            try
            {
                string konu = "Uygunitem.com - " + urunIsim + " İsimli ürün takibi.";
                string mesaj = urunIsim + " ürününü takibe aldınız. Takibe aldığınız fiyat: " + urunFiyat;
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("Mail adresiniz", "Mail Şifreniz"); // Gönderici bilgilerini giriyoruz
                smtp.Port = 587; // Mail uzantınıza göre bu değişebilir
                smtp.Host = "mail.furkanaktas.com"; // Gmail veya hotmail ise onların host bilgisini almanız gerekiyor 
                smtp.EnableSsl = false;
                mail.IsBodyHtml = true;// HTML tagleri kullanarak mail gönderebilmek için aktif ediyoruz
                mail.From = new MailAddress("Mail adresiniz"); // Gönderen mail adresini yazıyoruz
                mail.To.Add(urunMail); // Gönderilecek mail adresini ekliyoruz
                mail.Subject = konu; // Mesaja konuyu ekliyoruz
                mail.Body = mesaj; // Mesajın içeriğini ekliyoruz

                smtp.Send(mail); // Mesajı gönderiyoruz
                return "basarili";
            }
            catch (Exception)
            {
                return "basarisiz";
            }
        }
    }
}