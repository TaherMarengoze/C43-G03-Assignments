using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper;

public static class EmailSettings
{
    public static void SendEmail(Email input)
    {
        var client = new SmtpClient("smtp.gmail.com", 587); //TLS => Secured Encrypted
        client.EnableSsl = true;

        client.Credentials = new NetworkCredential("taher.marengoze@gmail.com", ""); //use google password generator for apps
        client.Send("taher.marengoze@gmail.com", input.To, input.Subject, input.Body);
    }
}
