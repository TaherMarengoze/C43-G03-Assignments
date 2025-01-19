using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Question 03:
we define the INotificationService interface with a method SendNotification that
takes a recipient and a message as parameters.
We then create three classes: EmailNotificationService, SmsNotificationService,
and PushNotificationService, which implement the INotificationService interface.
In each implementation, we provide the logic to send notifications through the
respective communication channel:
The EmailNotificationService class simulates sending an email by outputting a
message to the console.
The SmsNotificationService class simulates sending an SMS by outputting a
message to the console.
*/

namespace C43_G03_OOP04.Part_02
{
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            //do some logic: like checking if the recipient is valid email
            //format and style the message as html for the email, etc
            Console.WriteLine($"Simulating Email Notification:\n" +
                              $"Sending email to {recipient} with message:\n" +
                              $"\"{message}\"");
        }
    }

    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            //verify the recipient is a valid phone number
            //call the api of SMS service for example, etc ...
            Console.WriteLine($"Simulating SMS Notification:\n" +
                              $"Sending sms to {recipient} with message:\n" +
                              $"\"{message}\"");
        }
    }

    public class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            //Consume the Push notification services API, etc
            Console.WriteLine($"Simulating Push Notification:\n" +
                              $"Sending push notification to {recipient} with message:\n" +
                              $"\"{message}\"");
        }
    }

}
