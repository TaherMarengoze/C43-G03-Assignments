using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C43_G03_ADV02
{
    public static class Helper
    {
        public static int[] GenerateRandomArray(int size, int lowerBound, int upperBound)
        {
            int[] array = new int[size];

            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(lowerBound, upperBound);
            }

            return array;
        }

        public static int GenerateRandomNumber(int lowerBound, int upperBound)
        {
            return new Random().Next(lowerBound, upperBound);
        }

        public static int[] GeneratePalindromArray(int size)
        {
            int[] numbers = new int[size];
            int randomNumber;

            for (int i = 0; i < size / 2; i++)
            {
                randomNumber = GenerateRandomNumber(1, 10);
                numbers[i] = randomNumber;
                numbers[size - i - 1] = randomNumber;
            }

            if (size % 2 != 0)
            {
                numbers[size / 2] = GenerateRandomNumber(10, 20);
            }

            return numbers;
        }

        public static bool IsPalindrome(int[] numbers)
        {
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                if (numbers[i] != numbers[numbers.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsParanthesisBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            char topOfStack;

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    topOfStack = stack.Pop();
                    if ((c == ')' && topOfStack != '(') || (c == ']' && topOfStack != '[') || (c == '}' && topOfStack != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        public static void PrintList<T>(this IEnumerable<T> list,
                                        string separator = ",",
                                        string prefix = "[ ",
                                        string suffix = " ]",
                                        bool appendSeparatorToFirstElement = false)
        {
            Console.WriteLine($"{prefix}{(appendSeparatorToFirstElement ? separator : "")}{string.Join(separator, list)}{suffix}");
        }

        
    }
}
