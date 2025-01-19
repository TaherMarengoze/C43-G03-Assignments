using C43_G03_OOP04.Part_02;

namespace C43_G03_OOP04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, to OOP Assignment 4");
            Console.WriteLine("".PadLeft(40, '='));
            Console.WriteLine();
            //================================================================================================

            #region Question 1
            Console.WriteLine("Question 1:");

            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            
            circle.DisplayShapeInfo();
            Console.WriteLine();
            rectangle.DisplayShapeInfo();
            #endregion

            Console.WriteLine("".PadLeft(40, '='));
            Console.WriteLine();
            //================================================================================================

            #region Question 2
            Console.WriteLine("Question 2:");

            IAuthenticationService authService = new BasicAuthenticationService();
            string userName = "Taher";
            string password = "123";
            string role = "admin";

            //try with correct credentials
            if (authService.AuthenticateUser(userName, password))
            {
                authService.AuthorizeUser(userName, role);
            }
            Console.WriteLine();

            //try with incorrect credentials
            if (authService.AuthenticateUser(userName, "xyz"))
            {
                authService.AuthorizeUser(userName, role);
            }
            Console.WriteLine();
            #endregion

            Console.WriteLine("".PadLeft(40, '='));
            Console.WriteLine();

            //================================================================================================

            #region Question 3
            Console.WriteLine("Question 3:");

            INotificationService email = new EmailNotificationService();
            INotificationService sms = new SmsNotificationService();
            INotificationService push = new PushNotificationService();

            //email
            email.SendNotification("taher.marengoze@gmail.com", "Your order is shipped, and will arrive in 7 to 10 days.");
            Console.WriteLine();

            //sms
            sms.SendNotification("01022000697", "Your reservation is confirmed, with number 0123456789.");
            Console.WriteLine();

            //push
            push.SendNotification("Taher", "A new product is added to the system.");
            Console.WriteLine();
            #endregion


            //================================================================================================
            Console.WriteLine("".PadLeft(40, '='));
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
}