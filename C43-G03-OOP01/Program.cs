using static System.Console;
using MyNamespace;
using MyNamespace2;

namespace C43_G03_OOP01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Print.WeekDays();
            DrawLine();

            //2
            Print.SeasonMonthRange();
            DrawLine();

            //3
            _ = new PermissionManagment();
            DrawLine();

            //4
            Print.PrimaryColorCheck();
            DrawLine();

            //Close
            Hold();
        }

        static void DrawLine()
        {
            WriteLine("\n".PadRight(60,'=') + "\n");
        }

        static void Hold()
        {
            WriteLine("Press ENTER to exit");
            ReadLine();
        }


    }

    #region Part #1

    //Please, check the MyClassLibrary project

    //accessing internal members from outside the assembly

    class Part1Demo
    {
        // Uncommenting any of the below will give this compile error: inaccessible due to its protection level

        //MyClass myClass = new();
        //MyStruct myStruct = new();
        //IMyInterface myInterface;
        //MyEnum enumValue = MyEnum.A;

        // public objects can be accessed normally without any error
        MyPublicClass myPublicClass = new();
        MyPublicStruct myPublicStruct = new();
        IMyPublicInterface myPublicInterface;
        MyPublicEnum myPublicEnum = MyPublicEnum.X;
    }

    public class ClassA : DemoClass
    {
        public ClassA()
        {
            //_private = 1; //private
            //_privateProtected = 2; //depite inheritance private will make it inaccessible from outside the assembly
            _protected = 3; //accessible due to being protected despite being outside the assembly
            //_internal = 4; //internal will not be accessible outside the assembly
            _protectedInternal = 5; //same as protected
            _public = 6; //public accessible anywhere
        }
    }

    public class ClassB
    {
        DemoClass demo = new();

        public ClassB()
        {
            demo._public = 6; //only public will be accessible
            //other level of access will not be accessible because this class is not inheriting
            //and its outside the assembly of the DemoClass
        }
    }

    enum Rating
    {
        OneStar = 1,
        TwoStars,
        ThreeStars,
        FourStars,
        FiveStars
    }

    //combined enum values
    [Flags]
    enum Articles
    {
        Programing = 1,
        History = 2,
        Innovation = 4,
        Health = 8,
        Economics = 16
    }

    public class EnumMethods
    {
        public EnumMethods()
        {
            _ = Enum.TryParse(typeof(Rating), "ThreeStars", false, out object rating);
            Console.WriteLine(rating); //Prints: ThreeStars

            _ = Enum.TryParse(typeof(Rating), "6", false, out rating);
            Console.WriteLine(rating); //Prints: 6


            //=======================================================

            Articles subscribedArticles =
                Articles.Programing |
                Articles.History |
                Articles.Innovation |
                Articles.Health |
                Articles.Economics;

            Console.WriteLine(subscribedArticles);

            //Leave only programing
            subscribedArticles &= Articles.Programing;
            Console.WriteLine(subscribedArticles);

            subscribedArticles ^= Articles.Innovation;
            Console.WriteLine(subscribedArticles);

            //=======================================================

            Console.WriteLine(Enum.GetNames(typeof(Rating)));

            //=======================================================

            Console.WriteLine(Enum.IsDefined(typeof(Rating), 6));

        }
    }
    #endregion

    #region Part #2

    #region 1. Weekdays Enum
    //1. Create an enum called "WeekDays" with the days of the week (Monday to Sunday) as its members.
    //   Then, write a C# program that prints out all the days of the week using this enum.

    enum WeekDays
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    #endregion

    #region 2. Seasons Months Range

    //2. Create an enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as  its members.
    //   Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season.
    //   Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)

    enum Seas
    {
        Spring = 1, Summer, Autumn, Winter
    }

    #endregion

    #region 3. Permissions
    //3. Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum.
    //   • Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission is existed inside variable

    [Flags]
    enum Permission
    {
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    class PermissionManagment
    {
        Permission permission;

        public PermissionManagment()
        {
            //Add all permissions
            permission = Permission.Read | Permission.Write | Permission.Delete | Permission.Execute;
            WriteLine(permission);

            //Remove all except Read
            permission &= Permission.Read;
            WriteLine(permission);

            //Add Write if not exist or remove if exists (Toggle)
            permission ^= Permission.Write;
            WriteLine(permission);

            permission ^= Permission.Write;
            WriteLine(permission);

            if (permission.HasFlag(Permission.Read))
            {
                WriteLine("Has " + Permission.Read);
            }
            else
            {
                WriteLine("Don't have " + Permission.Read);
            }
        }


    }

    #endregion

    #region 4. Primary Colors
    //4. Create an enum called "Colors" with the basic colors (Red, Green, Blue) as its members.
    //   Write a C# program that takes a color name as input from the user and
    //   displays a message indicating whether the input color is a primary color or not.

    enum Colors
    {
        Red = 1,
        Green = 2,
        Blue = 3,
    }


    #endregion

    class Print
    {
        public static void WeekDays()
        {
            WriteLine(JoinList(Enum.GetNames(typeof(WeekDays))));
        }

        public static void SeasonMonthRange()
        {
            object result;
            bool isValid;

            do
            {
                Write("Enter Season Name: ");

                isValid = Enum.TryParse(typeof(Seas), ReadLine(), true, out result!);

                if (isValid)
                    isValid = Enum.IsDefined(typeof(Seas), result);

                if (!isValid)
                    InvalidInput();
            }
            while (!isValid);

            Seas inputSeason = (Seas)result!;

            switch (inputSeason)
            {
                case Seas.Spring:
                WriteLine($"{inputSeason} ranges from March to May");
                break;

                case Seas.Summer:
                WriteLine($"{inputSeason} ranges from June to August");
                break;

                case Seas.Autumn:
                WriteLine($"{inputSeason} ranges from September to November");
                break;

                case Seas.Winter:
                WriteLine($"{inputSeason} ranges from December to February");
                break;

                default:
                WriteLine("There are 4 seasons in a year, perhaps there is more in another alternate reality");
                break;
            }
        }

        public static void PrimaryColorCheck()
        {
            object result;
            bool isValid;

            do
            {
                Write("Enter Color: ");

                isValid = Enum.TryParse(typeof(Colors), ReadLine(), true, out result!);

                if (isValid)
                    isValid = Enum.IsDefined(typeof(Colors), result);

                if (!isValid)
                    InvalidInput();
            }
            while (!isValid);

            WriteLine($"Is Primary Color: {isValid}");
        }

        private static string JoinList(string[] list)
        {
            string joinedList = "";

            foreach (string item in list)
            {
                joinedList += $"{item},";
            }

            return joinedList.Remove(joinedList.Length - 1);
        }

        static void InvalidInput()
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("Invalid Input! ... Try Again");
            ForegroundColor = ConsoleColor.Gray;
        }
    }

    #endregion
}
