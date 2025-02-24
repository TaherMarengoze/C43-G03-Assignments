using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Intrinsics.X86;
using static C43_G03_LINQ03.ConsoleFormatter;

namespace C43_G03_LINQ03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Partinioning Operators
            ColoredText("###   LINQ - Partinioning Operators   ###", ConsoleColor.DarkCyan, true, true);
            LineBreak();

            //1. Get the first 3 orders from customers in Washington
            ColoredText("1. Get the first 3 orders from customers in Washington:", ConsoleColor.DarkGreen);
            ListGenerators.CustomerList
                .Where(c => c.City == "Berlin")
                .SelectMany(c => c.Orders.Skip(2))
                .PrintList();

            HRule();

            //2. Get all but the first 2 orders from customers in Washington.
            ColoredText("2. Get all but the first 2 orders from customers in Washington:", ConsoleColor.DarkGreen);
            ListGenerators.CustomerList
                .Where(c => c.City == "Berlin")
                .SelectMany(c => c.Orders.Take(new Range(2, c.Orders.Length - 1)))
                .PrintList();

            HRule();

            int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            //3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
            ColoredText("3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array:", ConsoleColor.DarkGreen);
            numbers.TakeWhile((num, idx) => num >= idx).PrintListInline();

            HRule();

            //4. Get the elements of the array starting from the first element divisible by 3.
            ColoredText("4. Get the elements of the array starting from the first element divisible by 3:", ConsoleColor.DarkGreen);
            numbers.SkipWhile(n => n % 3 != 0).PrintListInline(); 

            HRule();

            //5. Get the elements of the array starting from the first element less than its position.
            ColoredText("5. Get the elements of the array starting from the first element less than its position:", ConsoleColor.DarkGreen);
            numbers.SkipWhile((num,idx) => idx <= num).PrintListInline();

            HRule();
            #endregion

            #region LINQ - Grouping Operators
            ColoredText("###   LINQ - Grouping Operators   ###", ConsoleColor.DarkCyan, true, true);
            LineBreak();

            //1. Use group by to partition a list of numbers by their remainder when divided by 5
            ColoredText("1. Use group by to partition a list of numbers by their remainder when divided by 5:", ConsoleColor.DarkGreen);
            List<int> _numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];

            var groupedNumbers = _numbers
                .Select(num => new { rem = num % 5, number = num })
                .GroupBy(grp => grp.rem).ToList();

            foreach (var group in groupedNumbers)
            {
                Console.WriteLine($"Numbers with reminder of {group.Key} when divided with 5:");
                foreach (var num in group)
                {
                    Console.Write($" {num.number}");
                }
                LineBreak(2);
            }

            HRule();

            //2. Uses group by to partition a list of words by their first letter. Use dictionary_english.txt for Input
            ColoredText("2. Uses group by to partition a list of words by their first letter:", ConsoleColor.DarkGreen);
            var firtLetterGroupedWords = EnglishDictionary.Words.GroupBy(wrd => wrd[0]);

            foreach (var letterGroup in firtLetterGroupedWords)
            {
                Console.WriteLine($"{letterGroup.Key}");
                foreach (var word in letterGroup)
                {
                    Console.WriteLine($" {word}");
                }
                LineBreak(2);
            }

            HRule();

            //3. Consider this Array as an Input
            string[] Arr = ["from", "salt", "earn", " last", "near", "form"];
            //Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            ColoredText("3. Consider this Array as an Input:", ConsoleColor.DarkGreen);

            var groupedWords = Arr.GroupBy(word => word);

            HRule();

            #endregion
        }
    }
}
