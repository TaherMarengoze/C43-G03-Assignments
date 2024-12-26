using static System.Console;

namespace C43_G03_CS05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Swap();

            //2
            Sum();

            //3
            SumAndSubtract();

            //4
            SumNumberDigits();

            //5
            PrimeNumber();

            //6
            MinMax();

            //7
            Factorial();

            //8
            ChangeChar();

            Write("Press ENTER key to exit");
            ReadLine();
        }

        static void DrawLine()
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("\n".PadRight(60, '=') + "\n");
            ForegroundColor = ConsoleColor.Gray;
        }

        #region 1: difference between passing (Value type parameters) by value and by reference
        //1- Explain the difference between passing (Value type parameters) by value and by reference
        //   then write a suitable c# example.

        /*
            when value type is passed to function by value a stack frame is created for the function within its
            scope, any changes to this parameter will not affect the value in the caller function.

            but when passed by reference, the parameter stack frame will be in the caller function and changes
            made in the called function to this parameter will affect the one in the caller function.

            example swap function
            */

        static void Swap()
        {
            int n1 = 1;
            int n2 = 2;
            WriteLine($"By Val\nBefore Swaping: n1 = {n1} | n2 = {n2}");
            SwapByVal(n1, n2);
            WriteLine($"After Swaping: n1 = {n1} | n2 = {n2}");
            //the value will be the same before and after because the value types parameters were passed by value

            n1 = 2;
            n2 = 3;
            WriteLine($"By Ref\nBefore Swaping: n1 = {n1} | n2 = {n2}");
            SwapByRef(ref n1, ref n2);
            WriteLine($"After Swaping: n1 = {n1} | n2 = {n2}");
            //the value will be swapped because parameters were passed by ref

            DrawLine();
        }

        static void SwapByVal(int n1, int n2)
        {
            int tmp = n1;
            n1 = n2;
            n2 = tmp;
        }

        static void SwapByRef(ref int n1,ref int n2)
        {
            int tmp = n1;
            n1 = n2;
            n2 = tmp;
        }

        #endregion

        #region 2: difference between passing (Reference type parameters) by value and by reference
        //2- Explain the difference between passing (Reference type
        //  parameters) by value and by reference then write a suitable c# example.
        
        /* if an element inside the parameter is changed like for example an array of numbers its the same for
          * both passing by value or reference case.
          * 
          * By Val: if the parameter is re-assigned inside the called function the param. will have new hashcode
          * and a new address at the heap but in the scope of the calling function the hashcode/heap address is
          * the same before calling the function
          * 
          * By Ref: re-assigning inside function B (the one called by function A) will make both hashcode/heap
          * address in function A and B the same as per the one assigned in function B
          * 
          
          example sum function
          */

        static void Sum()
        {
            WriteLine("By Val:");
            int[] numbers = [1, 2, 3];
            WriteLine("Sum = " + SumByVal(numbers));
            //outputs 10 but numbers[0] still = 1 and hashcode is not changed after and before
            WriteLine("Element[0] = " + numbers[0]);
            //outputs 1 despite being changed to 5 in SumByVal func.


            WriteLine("\nBy Ref:");
            WriteLine("Sum = " + SumByRef(ref numbers)); //=> 60 instead of 6
            WriteLine("Element[0] = " + numbers[0]); //=> 10 instead of 1

            DrawLine();
        }

        static int SumByVal(int[] numbers)
        {
            // change numbers[0]
            numbers[0] = 5;

            int accum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                accum += numbers[i];
            }

            return accum;
        }

        static int SumByRef(ref int[] numbers)
        {
            numbers = [10, 20, 30];

            int accum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                accum += numbers[i];
            }

            return accum;
        }
        #endregion

        #region 3: summation and subtracting function
        //3- Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers

        static void SumAndSubtract()
        {
            SumAndSubtractTwoNumbers(50, 30, out int sum, out int subtract);
            WriteLine($"50 + 30 = {sum}\n50 - 30 = {subtract}");

            DrawLine();
        }

        static void SumAndSubtractTwoNumbers(int n1, int n2, out int sum, out int subtract)
        {
            sum = n1 + n2;
            subtract = n1 - n2;
        }
        #endregion

        #region 4: sum number individual digits
        //4- Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.

        static void SumNumberDigits()
        {
            WriteLine("12345 => " + CalcSumNumberDigits(12345)); //=> 15

            DrawLine();
        }

        static int CalcSumNumberDigits(int number)
        {
            int sum = 0;
            int last;

            while (number > 0)
            {
                last = number % 10;
                number /= 10;

                sum += last;
            }

            return sum;

        }

        #endregion

        #region 5: Prime Number
        //5- Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not
        static void PrimeNumber()
        {

            WriteLine($"3 prime number ? {IsPrime(3)}");
            WriteLine($"6 prime number ? {IsPrime(6)}");

            DrawLine();
        }

        static bool IsPrime(int number)
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
        #endregion

        #region 6:MinMax Array
        //6- Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters
        static void MinMax()
        {
            int[] numbers = [5, 6, 4, 2, 7, 0, 1, 9, 3, -9];
            int min = numbers[0];
            int max = numbers[numbers.Length - 1];

            MinMaxArray(numbers, ref min, ref max);

            WriteLine($"Array min. = {min} and max. = {max}");

            DrawLine();
        }

        static void MinMaxArray(int[] numbers, ref int min, ref int max)
        {
            foreach (int number in numbers)
            {
                if (min > number)min = number;
                if (max < number) max = number;
            }
            
        }
        #endregion

        #region 7: Factorial
        //7- Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter

        static void Factorial()
        {
            WriteLine("5! = " + CalcFactorial(5));

            DrawLine();
        }

        static int CalcFactorial(int number)
        {
            if (number < 0)
                return 0;

            int fact = number;
            
            for (int i = number - 1; i > 1; i--)
                fact *= i;

            return fact;
        }
        #endregion

        #region 8: Change Char
        //8- Create a function named "ChangeChar" to modify a letter in a certain position(0 based) of a string, replacing it with a different letter

        static void ChangeChar()
        {
            WriteLine($"Tah_r => {ChangeChar("Tah_r", 'e', 3)} ");

            DrawLine();
        }

        static string ChangeChar(string str, char newChar, int position)
        {
            char[] chars = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (i == position)
                {
                    chars[i] = newChar;
                }
                else
                {
                    chars[i] = str[i];
                }
            }

            return string.Join("", chars);
        }

        #endregion
    }
}
