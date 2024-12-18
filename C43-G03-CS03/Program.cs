namespace C43_G03_CS03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Write a program that allows the user to enter a number then print it.
            Console.Write("Enter a number: ");
            Console.WriteLine(Console.ReadLine());
            #endregion

            #region 2. Write C# program that converts a string to an integer, but the string contains non-numeric characters. And mention what will happen
            int number = Convert.ToInt32("123x");
            //will throw System.FormatException
            #endregion

            #region 3. Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen
            float n1 = 1.23f;
            float n2 = 4.56f;
            Console.WriteLine("1.23 + 4.56 = " + (n1 + n2));
            //The result 5.79 will be printed on the console
            #endregion

            #region 4. Write C# program that Extract a substring from a given string.
            string name = "Maher".Substring(1, 4);
            Console.WriteLine("T" + name);
            #endregion

            #region 5. Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            int i1 = 15;
            Console.WriteLine($"i1 (Old) = {i1}");
            int i2 = i1;
            Console.WriteLine($"i1 (New) = {i1}, i2 = {i2}");
            //changing i1 after assigning the value to i2 will keep the value of i2 unchanged, only i1 changed
            #endregion

            #region 6. Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
            Point p1 = new Point { x = 100, y = 200 };
            Point p2 = p1;
            Console.WriteLine($"Point2 (x,y) = ({p2.x},{p2.y})");
            p1.x = 300;
            p1.y = 650;
            Console.WriteLine($"Point2 (x,y) = ({p2.x},{p2.y})");
            //assigning p1 to p2 then changing p1 will affect p2 
            #endregion

            #region 7. Write C# program that take two string variables and print them as one variable
            string s1 = "Taher";
            string s2 = "Mostafa";
            Console.WriteLine($"Name: {s1} {s2}");
            #endregion

            #region 8. Write a program that calculates the simple interest
            /*
                8-	Write a program that calculates the simple interest given the principal amount, rate of interest, and time.
                The formula for simple interest is  Interest = (principal * rate * time ) /100.
              */
            Console.Write("Enter principal amount: ");
            double principal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter rate of interest: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter time: ");
            double time = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Interest = {(principal * rate * time) / 100}");
            #endregion

            #region 9. Write a program that calculates the Body Mass Index (BMI)
            /*
                9. Write a program that calculates the Body Mass Index (BMI) given
                a person's weight in kilograms and height in meters.
                The formula for BMI is BMI = (Weight)/(Height*Height)
             */
            Console.Write("Enter Weight in kg: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Height in meters: ");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"BMI = {(weight)/(height*height)}");
            #endregion

            #region 10. Write a program that uses the ternary operator to check if the temperature
            /*
                10. Write a program that uses the ternary operator to check if the temperature is too hot, too cold, or just good.
                Assign the result in a variable then display the result.
                Assume that below 10 degrees is "Just Cold", above 30 degrees is "Just Hot", and anything else is "Just Good".
            */
            Console.Write("Enter tempratue: ");
            int temprature = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(temprature > 30 ? "Just Hot" : (temprature < 10 ? "Just Cold" : "Just Good"));
            #endregion

            #region 11. Write a program that takes the date from the user and displays it in various formats using string interpolation.
            DateTime inputDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(
                $"Today's date: {inputDate:dd/MM/yyyy}" +
                $"Today's date: {inputDate:yyyy-MM-dd}" +
                $"Today's date: {inputDate:MM dd yyyy}" +
                $"Today's date: {inputDate:MMMM yy}" +
                "");
            #endregion

            #region 12. What is the output of the following C# code?
            DateTime date = new DateTime(2024, 6, 14);
            Console.WriteLine($"The event is on {date:MM/dd/yyyy}");

            // Output =>The event is on 06/14/2024 (answer C)
            #endregion

            #region 13. Which of the following statements is correct about the C#.NET code snippet given below?
            int d;
            d = Convert.ToInt32(!(30 < 20));

            // => f)	A value 1 will be assigned to d
            #endregion

            #region 14. Which of the following is the correct output for the C# code given below?
            Console.WriteLine(13 / 2 + " " + 13 % 2);
            //output => 6 1
            #endregion

            #region 15. What will be the output of the C# code given below?
            int num = 1, z = 5;

            if (!(num <= 0))
                Console.WriteLine(++num + z++ + " " + ++z);
            else
                Console.WriteLine(--num + z-- + " " + --z);

            //output => d)	7 7
            #endregion
        }

        class Point
        {
            public int x, y;
        }
    }
}
