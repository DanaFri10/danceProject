using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace DanceProject.ServiceClasses
{
    public class EmailService
    {
        public static void SendEmail(string body, string subject, string to)
        {
            MailMessage mail = new MailMessage(); //יצירת אוביקט MailMessage
            mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailAdress"].ToString()); // ממי לשלוח
            mail.Sender = new MailAddress(ConfigurationManager.AppSettings["EmailAdress"].ToString());
            mail.To.Add(to); // למי לשלוח
            mail.IsBodyHtml = true; //הגדרת תוכן ההודעה ל - HTML 
            mail.Subject = subject; // נושא ההודעה
            mail.Body = body; // תוכן ההודעה

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //הגדרת השרת של גוגל
            smtp.UseDefaultCredentials = false; // שימוש בערכי מייל וסיסמה שאני הגדרתי ולא ערכי ברירת מחדל

            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailAdress"].ToString(), ConfigurationManager.AppSettings["EmailPassword"].ToString()); //הגדרת פרטי הכניסה לחשבון גימייל
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true; //אפשור SSL

            smtp.Timeout = 30000;
            //smtp.Send(mail); //שליחת ההודעה
        }
    }
}