using System.Text;

namespace C43_G03_CS04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValidInput;
            int inputInt;
            int size;
            StringBuilder sbSeries = new StringBuilder();

            #region 1: Number divisible by 3 and 4
            //  1- Write a program that takes a number from the user then print yes
            //  if that number can be divided by 3 and 4 otherwise print no.

            do
            {
                Console.Write("Enter a number that can be divided by 3 and 4: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Console.WriteLine(inputInt % 3 == 0 && inputInt % 4 == 0 ? "yes" : "no");
            #endregion

            DrawLine();

            #region 2: Positive or Negative
            /*
             * 2- Write a program that allows the user to insert an integer then print 
             * negative if it is negative number otherwise print positive.
             */

            do
            {
                Console.Write("Enter an integer number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Console.WriteLine(inputInt < 0 ? "negative" : "positive");

            #endregion

            DrawLine();

            #region 3: Max. and Min.
            // 3- Write a program that takes 3 integers from the user then prints the max element and the min element.
            int[] numbers = new int[3];
            int max = 0;
            int min = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                do
                {
                    Console.Write($"Enter an integer number #{i + 1}: ");
                    isValidInput = int.TryParse(Console.ReadLine(), out numbers[i]);

                    if (!isValidInput)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid Input, try again");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }


                    if (i == 0)
                    {
                        min = numbers[i];
                        max = numbers[i];
                    }
                    else
                    {
                        if (numbers[i] < min)
                        {
                            min = numbers[i];
                        }

                        if (numbers[i] > max)
                        {
                            max = numbers[i];
                        }
                    }

                }
                while (!isValidInput);
            }

            Console.WriteLine($"Max. = {max} , Min. = {min}");

            #endregion

            DrawLine();

            #region 4: Even or Odd check
            // 4. Write a program that allows the user to insert an integer number then check If a number is even or odd.

            do
            {
                Console.Write("Enter a number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Console.WriteLine(inputInt % 2 == 0 ? "Even" : "Odd");

            #endregion

            DrawLine();

            #region 5: Vowel / Consonant Check
            // 5- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).
            char letter;

            do
            {
                Console.Write("Enter a letter: ");
                isValidInput = char.TryParse(Console.ReadLine(), out letter);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (isValidInput && !char.IsAsciiLetter(letter))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Letters only, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            letter = char.ToLower(letter);

            char[] vowels = ['a', 'e', 'i', 'u', 'o'];

            if (vowels.Contains(letter))
            {
                Console.WriteLine("Vowel");
            }
            else
            {
                Console.WriteLine("Consonant");
            }

            #endregion

            DrawLine();

            #region 6: Print Number Series
            // 6. Write a program that allows the user to insert an integer then print all numbers between 1 to that number.

            do
            {
                Console.Write("6. Enter an integer number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            sbSeries = new StringBuilder();

            for (int i = 1; i <= inputInt; i++)
            {
                sbSeries.Append($"{i},");
            }

            sbSeries.Remove(sbSeries.Length - 1, 1);

            Console.WriteLine(sbSeries);

            #endregion

            DrawLine();

            #region 7: Number Multiplication Table
            // 7. Write a program that allows the user to insert an integer then print a multiplication table up to 12.

            do
            {
                Console.Write("Enter an integer number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            sbSeries.Clear();

            for (int i = 1; i <= 12; i++)
            {
                sbSeries.Append($"{i * inputInt} ");
            }

            Console.WriteLine(sbSeries);

            #endregion

            DrawLine();

            #region 8: Print Even Series
            // 8. Write a program that allows to user to insert number then print all even numbers between 1 to this number

            do
            {
                Console.Write("Enter an integer number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            sbSeries.Clear();

            for (int i = 1; i <= inputInt; i++)
            {
                if (i % 2 == 0)
                {
                    sbSeries.Append($"{i},");
                }
            }

            sbSeries.Remove(sbSeries.Length - 1, 1);

            Console.WriteLine(sbSeries);

            #endregion

            DrawLine();

            #region 9: Print Number Power
            // 9. Write a program that takes two integers then prints the power.

            do
            {
                Console.Write("Enter an integer number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            int inputPower;

            do
            {
                Console.Write($"Enter number power: {inputInt}^");
                isValidInput = int.TryParse(Console.ReadLine(), out inputPower);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Console.WriteLine($"{Math.Pow(inputInt, inputPower)}");
            #endregion

            DrawLine();

            #region 10: Five Subjects Marks
            //10. Write a program to enter marks of five subjects and calculate total, average and percentage.
            int[] marks = new int[5];
            int sum = 0;
            double avg;

            for (int i = 0; i < marks.Length; i++)
            {
                do
                {
                    Console.Write($"Enter a mark of subject #{i + 1}: ");
                    isValidInput = int.TryParse(Console.ReadLine(), out marks[i]);

                    if (!isValidInput)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Invalid Input, try again");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    sum += marks[i];
                }
                while (!isValidInput);
            }

            avg = (double)sum / 5;

            Console.WriteLine($"Total = {sum} | Average = {avg} | Percent = {avg}%");

            #endregion

            DrawLine();

            #region 11: Number of days per month
            //11- Write a program to input the month number and print the number of days in that month.

            do
            {
                Console.Write("Enter a month number [1 => 12]: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (isValidInput)
                {
                    switch (inputInt)
                    {
                        case < 0:
                        case 0:
                        case > 12:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Number not within range [1 => 12] , try again");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        isValidInput = false;
                        break;
                    }
                }
            }
            while (!isValidInput);

            switch (inputInt)
            {
                case 1:
                case 3:
                case 5:
                case 6:
                case 8:
                case 10:
                case 12:
                Console.WriteLine(31 + " days");
                break;

                case 2:
                Console.WriteLine($"{28} days (normal year) and {29} (leap year)");
                break;

                default:
                Console.WriteLine(30 + " days");
                break;
            }
            #endregion

            DrawLine();

            #region 12: Simple Calculator
            //12- Write a program to create a Simple Calculator.

            int n1;
            int n2;
            char operation;
            do
            {
                Console.Write("Enter 1st number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n1);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            do
            {
                Console.Write("Enter 2nd number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n2);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            char[] operations = ['+', '-', '*', '/'];

            do
            {
                Console.Write($"Enter an operation ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("[ + | - | * | / ]");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(": ");
                isValidInput = char.TryParse(Console.ReadLine(), out operation);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (isValidInput && !operations.Contains(operation))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Only [ + | - | * | / ] operations are allowed, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    isValidInput = false;
                }
            }
            while (!isValidInput);

            double result = operation switch
            {
                '+' => n1 + n2,
                '-' => n1 - n2,
                '*' => n1 * n2,
                '/' => (double)n1 / n2,
                _ => 0,
            };
            Console.WriteLine($"{n1} {operation} {n2} = {result}");

            #endregion

            DrawLine();

            #region 13: Reverse String
            //13- Write a program to allow the user to enter a string and print the REVERSE of it.

            string inputString = "";

            do
            {
                Console.Write("Enter a non-whitespace text: ");
                inputString = Console.ReadLine() ?? "";

                isValidInput = (inputString.Trim().Length > 0);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            sbSeries.Clear();

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sbSeries.Append(inputString[i]);
            }

            Console.WriteLine(sbSeries);

            //Console.WriteLine(inputString.Reverse());

            #endregion

            DrawLine();

            #region 14: Reverse Int
            //14- Write a program to allow the user to enter int and print the REVERSED of it.

            do
            {
                Console.Write("Enter a number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            inputString = inputInt.ToString();

            sbSeries.Clear();

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sbSeries.Append(inputString[i]);
            }

            Console.WriteLine($"The REVERSE of {inputString}: {sbSeries}");

            #endregion

            DrawLine();

            #region 15: Prime Number
            //15- Write a program in C# Sharp to find prime numbers within a range of numbers.

            do
            {
                Console.Write("Enter a number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n1);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            do
            {
                Console.Write($"Enter another number greater than {n1}: ");
                isValidInput = int.TryParse(Console.ReadLine(), out n2);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (isValidInput && n2 <= n1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"2nd number must be greater than {n1}, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    isValidInput = false;
                }
            }
            while (!isValidInput);


            sbSeries.Clear();

            for (int i = n1; i <= n2; i++)
            {
                if (IsPrime(i))
                {
                    sbSeries.Append($"{i},");
                }
            }

            sbSeries.Remove(sbSeries.Length - 1, 1);

            Console.WriteLine($"The prime numbers between {n1} and {n2} =");
            Console.WriteLine($"\t {sbSeries}");
            #endregion

            DrawLine();

            #region 16: Decimal to Binary
            //16- . Write a program in C# Sharp to convert a decimal number into binary without using an array.
            do
            {
                Console.Write("Enter a number: ");
                isValidInput = int.TryParse(Console.ReadLine(), out inputInt);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Console.WriteLine(Convert.ToString(inputInt, 2));
            #endregion

            DrawLine();

            #region 17: Linear 3 Points
            //17- Create a program that asks the user to input three points (x1, y1), (x2, y2), and (x3, y3),
            //and determines whether these points lie on a single straight line.

            int x1;
            int y1;
            int x2;
            int y2;
            int x3;
            int y3;

            Console.WriteLine("Enter the coordinates of three points (x1, y1), (x2, y2), and (x3, y3):");

            Console.WriteLine("Point1");
            Console.Write("Enter x1: ");
            x1 = GetValidCoordinate();
            Console.Write("Enter y1: ");
            y1 = GetValidCoordinate();


            Console.WriteLine("Point2");
            Console.Write("Enter x2: ");
            x2 = GetValidCoordinate();
            Console.Write("Enter y2: ");
            y2 = GetValidCoordinate();


            Console.WriteLine("Point3");
            Console.Write("Enter x3: ");
            x3 = GetValidCoordinate();
            Console.Write("Enter y3: ");
            y3 = GetValidCoordinate();

            double slope1 = (double)(y2 - y1) / (x2 - x1);
            double slope2 = (double)(y3 - y2) / (x3 - x2);

            if (Math.Abs(slope1 - slope2) < 0.000001)
            {
                Console.WriteLine("The points are linear.");
            }
            else
            {
                Console.WriteLine("The points are NOT linear.");
            }
            #endregion

            DrawLine();

            #region 18: Working Hours
            // 18. Within a company, the efficiency of workers is evaluated based on the duration required to complete a specific task.
            //     A worker's efficiency level is determined as follows: 
            //     - If the worker completes the job within 2 to 3 hours, they are considered highly efficient. 
            //     - If the worker takes 3 to 4 hours, they are instructed to increase their speed. 
            //     - If the worker takes 4 to 5 hours, they are provided with training to enhance their speed. 
            //     - If the worker takes more than 5 hours, they are required to leave the company. 
            //     To calculate the efficiency of a worker, the time taken for the task is obtained via user input from the keyboard.

            double hours;
            do
            {
                Console.Write("Enter number of hours (decimal is allowed): ");
                isValidInput = double.TryParse(Console.ReadLine(), out hours);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            if (hours <= 3)
            {
                Console.WriteLine("highly efficient");
            }
            else if (hours <= 4)
            {
                Console.WriteLine("increase speed");
            }
            else if (hours <= 5)
            {
                Console.WriteLine("provide training to enhance speed");
            }
            else
            {
                Console.WriteLine("leave the company");
            }

            #endregion

            DrawLine();
            
            #region 19: Identity Matrix
            //19- Write a program that prints an identity matrix using for loop,
            //    in other words takes a value n from the user and shows the identity table of size n * n.

            do
            {
                Console.Write("Enter matrix size: ");
                isValidInput = int.TryParse(Console.ReadLine(), out size);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            for (int i = 1; i <= size; i++)
            {
                Console.Write("| ");
                for (int j = 1; j <= size; j++)
                {
                    if (i == j)
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine("|");
            }

            #endregion

            DrawLine();

            #region 20: Array Sum
            //20- Write a program in C# Sharp to find the sum of all elements of the array.

            int[] arrSum = [1, 2, 3, 4, 5, 6, 7, 8, 9];

            sum = 0;
            for (int i = 0; i <= arrSum.Length; i++)
            {
                sum += arrSum[i];
            }

            Console.WriteLine($"Array Sum = {sum}");
            #endregion
            
            DrawLine();

            #region 21
            //
            #endregion

            DrawLine();

            #region 22
            //
            #endregion

            DrawLine();

            #region 23: Max. Min in Array
            //23- Write a program in C# Sharp to find maximum and minimum element in an array

            do
            {
                Console.Write("Enter size of array: ");
                isValidInput = int.TryParse(Console.ReadLine(), out size);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            // Create an array of the specified size
            int[] arrMinMax = [size];

            // Input array elements from the user
            Console.WriteLine("Fill the array: ");
            for (int i = 0; i < size; i++)
            {
                Console.Write($" element #{i + 1}: ");
                arrMinMax[i] = int.Parse(Console.ReadLine());
            }

            min = arrMinMax[0];
            max = arrMinMax[0];

            for (int i = 1; i < size; i++)
            {
                if (arrMinMax[i] > max)
                {
                    max = arrMinMax[i];
                }
                if (arrMinMax[i] < min)
                {
                    min = arrMinMax[i];
                }
            }

            Console.WriteLine($"Array Minimum and Maximum elements are: {min},{max} respectively");
            #endregion

            DrawLine();

            #region 24: Second Largest
            //24- Write a program in C# Sharp to find the second largest element in an array.

            do
            {
                Console.Write("Enter size of array: ");
                isValidInput = int.TryParse(Console.ReadLine(), out size);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            Random random = new Random();
            int[] arrSecondMax = new int[size];
            for (int i = 0; i < size; i++)
            {
                arrSecondMax[i] = random.Next(101);
            }

            int temp;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (arrSecondMax[i] < arrSecondMax[j])
                    {
                        temp = arrSecondMax[i];
                        arrSecondMax[i] = arrSecondMax[j];
                        arrSecondMax[j] = temp;
                    }
                }
            }

            Console.WriteLine($"2nd largest is: {arrSecondMax[1]}");
            #endregion

            DrawLine();

            #region 25
            //
            #endregion

            DrawLine();

            #region 26: Reverse Words
            //26- Given a list of space separated words, reverse the order of the words.
            Console.Write("Enter a sentence separated by a space: ");

            string[] words = Console.ReadLine().Split(" ");
            string[] reversedWords = new string[words.Length];

            for (int i = words.Length - 1; i >= 0; i--)
            {
                reversedWords[words.Length - 1 - i] = words[i];
            }

            Console.WriteLine($"Reversed Sentence: {string.Join(" ", reversedWords)}");
            #endregion

            DrawLine();

            #region 27: Clone Array
            // 27. Write a program to create two multidimensional arrays of same size.
            //     Accept value from user and store them in first array.
            //     Now copy all the elements of first array on second array and print second array.

            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            rows = Math.Min(rows, 7);

            Console.Write("Enter number of columns: ");
            int cols = int.Parse(Console.ReadLine());
            cols = Math.Min(cols, 7);

            int[,] arr1 = new int[rows, cols];

            Console.WriteLine("");
            Console.WriteLine("Enter values for array 1:");
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Row #{i + 1} >>");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"\tColumn [{j + 1}]: ");
                    arr1[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int[,] arr1Clone = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr1Clone[i, j] = arr1[i, j];
                }
            }

            Console.WriteLine("Cloned Array:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{arr1Clone[i, j]}\t");
                }
                Console.WriteLine();
            }

            #endregion

            DrawLine();

            #region 28: Reverve an array
            //28- Write a Program to Print One Dimensional Array in Reverse Order

            {
                int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

                Console.WriteLine($"Original Array = [{string.Join(", ", arr)}]");

                int[] arrRev = new int[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                    arrRev[arr.Length - 1 - i] = arr[i];

                Console.WriteLine($"Reversed Array = [{string.Join(", ", arrRev)}]");
            }

            #endregion

            DrawLine();

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Press any key to exit");
            Console.ReadLine();
        }

        static void DrawLine() => Console.WriteLine("".PadLeft(100, '='));

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        static int GetValidCoordinate()
        {
            int coordinate;
            bool isValidInput;

            do
            {
                Console.Write("Enter a coordinate: ");
                isValidInput = int.TryParse(Console.ReadLine(), out coordinate);

                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid Input, try again");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (!isValidInput);

            return coordinate;
        }
    }
}
