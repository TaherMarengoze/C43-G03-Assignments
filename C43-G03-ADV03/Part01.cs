namespace C43_G03_ADV03;

//Points covered

#region Delegates
//Delegates are reference types that hold the reference to a method.

//A delegate is a type that represents references to methods with a particular
// parameter list and return type (signature).

//Delegates are used to pass methods as arguments to other methods.

//Uses:
//1. Functional programming
//2. Event-Driven Programming

//Syntax:
//delegate <return type> <delegate-name> <parameter list>

public delegate int SendMessageDelegate(string msg);

public static class MessageService
{
    public static int SendSms(string message)
    {
        Console.WriteLine("SMS: " + message);
        return 1;
    }

    public static int SendEmail(string message)
    {
        Console.WriteLine("Email: " + message);
        return 1;
    }
}

public class TestDelegate
{
    public static void Test()
    {
        SendMessageDelegate sendMessageDelegate = new SendMessageDelegate(MessageService.SendSms);

        //calling the method using delegate directly
        sendMessageDelegate("Hello World");

        //calling the method using delegate.Invoke
        sendMessageDelegate.Invoke("Hello World");

        //adding multiple methods to the delegate
        sendMessageDelegate += MessageService.SendEmail;

        // += operator adds the method to the invocation list of the delegate
        sendMessageDelegate("Hello World");

        //this should print SMS and Email

        //getting the invocation list
        Delegate[] delegates = sendMessageDelegate.GetInvocationList();

        //use delegate Method property to get the method name
        foreach (Delegate d in delegates) {
            Console.WriteLine(d.Method);
        }

        // -= operator removes the method from the invocation list of the delegate
        sendMessageDelegate -= MessageService.SendSms;
        //this should print only Email
    }
}

//generics can be used with delegates, as well

//example of generic delegate
delegate TResult GenericDelegate<T, TResult>(T arg);

//There are specific keyword the determines the input and output of the delegate
// in, out

delegate TResult GenericDelegate2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

//we can't use the TResult as input parameter, only as output parameter
//and we can't use T1 or T2 as output parameter, only as input parameter


//C# has built-in generic delegates
//Action, Func, Predicate
//Predicate is a delegate that takes one input parameter and returns a boolean value, output is always bool

//Func is a delegate that takes 0 to 16 input parameters and returns a value, output is always the last parameter

//Action is a delegate that takes 0 to 16 input parameters and returns void, output is always void


//Anonymous methods: introduced in C# 2.0 [2005]
//Anonymous methods are not wildly used anymore due to its readability.
//syntax: delegate(parameters) { code }

//example:
class AnonymousMethod
{
    public static void Test()
    {
        SendMessageDelegate sendMessageDelegate = delegate (string message)
        {
            Console.WriteLine("Anonymous: " + message);
            return 1;
        };

        sendMessageDelegate("Hello World");
    }
}


//Lambda expressions: introduced in C# 3.0 [2007]
//Lambda expressions are more readable and concise than anonymous methods.

//lambda expression uses the => operator and is called "Fat Arrow" operator and is read as "goes to"
//ex: x => x * x , is read as x goes to x * x
//ex: (x, y) => x + y, is read as x and y goes to x + y
//paranthesis are optional if there is only one parameter


//Delegates was used in a Bubble Sort algorithm to determine the sorting is ascending or descending
//by passing a delegate to the BubbleSort method
//this delegate returns a boolean value and takes two numbers (generic) as input

#endregion
