using static System.Console;
using static System.Math;

namespace C43_G03_OOP02;

internal class Program
{
    static void Main(string[] args)
    {
        #region 1: Person Details
        // 1. Define a struct "Person" with properties "Name" and "Age".
        //    Create an array of three "Person" objects and populate it with data.
        //    Then, write a C# program to display the details of all the persons in the array.

        Person[] people =
        [
            new Person("Ahmed",28),
            new Person("Mohamed",30),
            new Person("Ali",27),
        ];

        foreach (Person person in people)
        {
            WriteLine($"{person.Name} is {person.Age} yeras old.");
        }
        #endregion

        DrawLine();

        #region 2: Distance between 2 points
        // 2. Create a struct called "Point" to represent a 2D point with properties "X" and "Y".
        // Write a C# program that takes two points as input from the user and
        // calculates the distance between them.

        bool isValid = false;
        int p1X, p1Y;
        int p2X, p2Y;

        
        do
        {
            Write("Point 1: X = ");
            isValid = int.TryParse(ReadLine(), out p1X);

            if (!isValid)
            {
                WriteLine(" >> Invalid Input. Try again");
            }

        } while (!isValid);

        do
        {
            Write($"Point 1: X = {p1X} , Y = ");
            isValid = int.TryParse(ReadLine(), out p1Y);

            if (!isValid)
            {
                WriteLine(" >> Invalid Input. Try again");
            }

        } while (!isValid);

        do
        {
            Write("Point 2: X = ");
            isValid = int.TryParse(ReadLine(), out p2X);

            if (!isValid)
            {
                WriteLine(" >> Invalid Input. Try again");
            }

        } while (!isValid);

        do
        {
            Write($"Point 2: X = {p1X} , Y = ");
            isValid = int.TryParse(ReadLine(), out p2Y);

            if (!isValid)
            {
                WriteLine(" >> Invalid Input. Try again.");
            }

        } while (!isValid);

        Point p1 = new Point(p1X, p1Y);
        Point p2 = new Point(p2X, p2Y);

        double distance = Sqrt(Pow((p2.X - p1.X), 2) + Pow((p2.Y - p1.Y), 2));

        WriteLine($"The distance between ({p1.X},{p1.Y}) and ({p2.X},{p2.Y}) = {distance:#,0.##}");

        #endregion

        DrawLine();

        #region 3: Person Data from User Input
        // 3. Create a struct called "Person" with properties "Name" and "Age".
        // Write a C# program that takes details of 3 persons as input from the user and
        // displays the name and age of the oldest person.

        people = new Person[3];
        int oldest = 0;
        int oldestIndex = -1;
        string inputName;

        for (int i = 0; i < people.Length; i++)
        {
            WriteLine($"Enter person {i + 1} data");
            do
            {
                Write(" > Name: ");
                inputName = ReadLine() ?? "";
            } while (inputName.Trim().Length <= 0);

            int inputAge;

            do
            {
                Write(" > Age: ");
                isValid = int.TryParse(ReadLine(), out inputAge);

                if (!isValid)
                    WriteLine("Invalid Input. Try again.");

            } while (!isValid);

            people[i] = new Person(inputName, inputAge);

            if (inputAge > oldest)
            {
                oldest = inputAge;
                oldestIndex = i;
            }
            WriteLine();
        }

        WriteLine($"The oldest person is {people[oldestIndex].Name} with age {people[oldestIndex].Age} years old.");


        #endregion

        WriteLine("Press ENTER to exit ...");
        ReadLine();
    }

    private static void DrawLine()
    {
        WriteLine("".PadRight(60, '='));
    }
}