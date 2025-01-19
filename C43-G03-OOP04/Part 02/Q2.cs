using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
Question 02:
In this example, we start by defining the IAuthenticationService interface with two
methods: AuthenticateUser and AuthorizeUser. The BasicAuthenticationService
class implements this interface and provides the specific implementation for these
methods.
In the BasicAuthenticationService class, the AuthenticateUser method compares
the provided username and password with the stored credentials. It returns true if
the user is authenticated and false otherwise. The AuthorizeUser method checks if
the user with the given username has the specified role. It returns true if the user
is authorized and false otherwise.
In the Main method, we create an instance of the BasicAuthenticationService class
and assign it to the authService variable of type IAuthenticationService. We then
call the AuthenticateUser and AuthorizeUser methods using this interface reference..
This implementation allows you to switch the authentication service implementation
easily by creating a new class that implements the IAuthenticationService interface
and providing the desired logic for authentication and authorization.
*/

namespace C43_G03_OOP04.Part_02
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string userName, string password);

        bool AuthorizeUser(string userName, string role);
    }

    public class BasicAuthenticationService : IAuthenticationService
    {
        private UserCredential[] credentials = [
            new UserCredential("Taher","123","Admin"),
            new UserCredential("Layla","456","Guest"),
            new UserCredential("Ahmed","789","Clerk"),
            ];

        public bool AuthenticateUser(string userName, string password)
        {
            Console.WriteLine($"Authenticating User: {userName} ...");

            foreach (var credential in credentials)
            {
                if (credential.UserName.ToUpper() == userName.ToUpper() &&
                    credential.Password == password)
                {
                    Console.WriteLine("Authenticated");
                    return true;
                }
            }

            Console.WriteLine("Authentication failed!");
            return false;
        }

        public bool AuthorizeUser(string userName, string role)
        {
            Console.WriteLine($"Authorizing User: {userName} ...");

            foreach (var credential in credentials)
            {
                if (credential.UserName.ToUpper() == userName.ToUpper() &&
                    credential.Role.ToUpper() == role.ToUpper())
                {
                    Console.WriteLine("Authorized");
                    return true;
                }
            }

            Console.WriteLine("Not Authorized User");
            return false;
        }
    }

    public class UserCredential
    {
        public UserCredential(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
