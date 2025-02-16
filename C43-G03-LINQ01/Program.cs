using LinqDemo;
using static C43_G03_LINQ01.ConsoleFormatter;

namespace C43_G03_LINQ01;

internal class Program
{
    static void Main(string[] args)
    {
        ColoredText("LINQ 01 Assignment", ConsoleColor.DarkRed);
        LineBreak(2);

        #region LINQ - Restriction Operators
        ColoredText("SECTION 1: LINQ - Restriction Operators", ConsoleColor.DarkCyan, true);
        LineBreak();

        //1. Find all products that are out of stock.
        ColoredText("1. Out-of-stock Products:", ConsoleColor.DarkGreen);
        ListGenerator.ProductList.Where(p => p.UnitsInStock <= 0)
            .PrintList();

        HRule();

        //2. Find all products that are in stock and cost more than 3.00 per unit.
        ColoredText("2. In-Stock products with Unit Price more than 3.00", ConsoleColor.DarkGreen);
        ListGenerator.ProductList
            .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.0m)
            .PrintList();

        HRule();

        //3. Returns digits whose name is shorter than their value.
        {
            ColoredText("Digits whose name is shorter than their value", ConsoleColor.DarkGreen);
            string[] arr = [
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
                ];

            arr.Where((n, index) => n.Length < index).PrintList();
        }

        #endregion

        LineBreak(2);

        #region LINQ - Ordering Operators
        ColoredText("SECTION 2: LINQ - Ordering Operators", ConsoleColor.DarkCyan, true);
        LineBreak();

        //1. Sort a list of products by name
        ColoredText("Products Sorted By Name: ", ConsoleColor.DarkGreen);
        ListGenerator.ProductList.OrderBy(p => p.ProductName).PrintList();

        HRule();

        //2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
        {
            string[] arr = [
                "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"
            ];

            ColoredText("Sort Order with Custom Comparer: ", ConsoleColor.DarkGreen);
            arr.Order(new CaseInsensitiveComparer()).PrintList();
            // Should Print the list in this order
            // AbAcUs => aPPLE => BlUeBeRrY => bRaNcH => cHeRry => ClOvEr
        }

        HRule();
        
        //3. Sort a list of products by units in stock from highest to lowest.
        ListGenerator.ProductList.OrderByDescending(p => p.UnitsInStock).PrintList();

        HRule();
        
        //4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
        {
            string[] arr = [
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            ];

            arr.OrderBy(num => num.Length).ThenBy(num => num).PrintList();
        }

        HRule();
        
        //5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
        {
            ColoredText("Sort word by Length then Case-Insensitive characters:", ConsoleColor.DarkGreen);
            string[] arr = [
                "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"
            ];

            arr.OrderBy(word => word.Length).ThenBy(word => word).PrintList();
        }

        HRule();
        
        //6. Sort a list of products, first by category, and then by unit price, from highest to lowest.

        ColoredText("Products sorted by Category then Unit Price descending", ConsoleColor.DarkGreen);
        ListGenerator.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice).PrintList();

        HRule();
        
        //7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
        {
            ColoredText("Sort word by Length then Case-Insensitive characters descending:", ConsoleColor.DarkGreen);
            string[] arr = [
                "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"
            ];

            arr.OrderBy(word => word.Length).ThenByDescending(word => word).PrintList();
        }

        HRule();

        //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
        {
            ColoredText("Digits with i 2nd letter reversed", ConsoleColor.DarkGreen);
            string[] arr = [
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
            ];

            arr.Where(digit => digit[1] == 'i').Reverse().PrintList();


        }

        #endregion

        LineBreak(2);

        #region LINQ – Transformation Operators
        ColoredText("SECTION 3: LINQ - Transformation Operators", ConsoleColor.DarkCyan, true);
        LineBreak();

        //1. Return a sequence of just the names of a list of products.
        ListGenerator.ProductList.Select(p => p.ProductName).PrintList(true);

        HRule();

        //2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
        {
            string[] words = ["aPPLE", "BlUeBeRrY", "cHeRry"];

            var wordsWithCasings = words.Select(word => new
            {
                UpperCase = word.ToUpper(),
                LowerCase = word.ToLower(),
            }).ToList();

            ColoredText("Uppercase version:", ConsoleColor.DarkGreen);
            wordsWithCasings.Select(wCase => wCase.UpperCase).PrintList();
            
            LineBreak();

            ColoredText("Lowercase version:", ConsoleColor.DarkGreen);
            wordsWithCasings.Select(wCase => wCase.LowerCase).PrintList();
        }

        HRule();

        //3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
        ColoredText("Products with Category,Name and Price:", ConsoleColor.DarkGreen);
        ListGenerator.ProductList.Select(p => new
        {
            p.Category,
            Name = p.ProductName,
            Price = p.UnitPrice,
        }).PrintList(prod => $"{prod.Category,-15} | {prod.Name,-35} | @{prod.Price:C}");

        HRule();
        
        //4. Determine if the value of int in an array match their position in the array.
        {
            int[] arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            ColoredText("Array Index Matching:", ConsoleColor.DarkGreen);
            arr.Select((num, index) => new
            {
                Number = num,
                IsMatched = num == index
            }).ToList().ForEach(elem =>
            {
                if (elem.IsMatched)
                {
                    ColoredText($"{elem.Number}: True", ConsoleColor.DarkYellow);
                }
                else
                {
                    Console.WriteLine($"{elem.Number}: False");
                }
            });
        }

        HRule();
        
        //5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
        int[] numbersA = [0, 2, 4, 5, 6, 8, 9];
        int[] numbersB = [1, 3, 5, 7, 8];

        ColoredText("Pairs where a < b", ConsoleColor.DarkGreen);
        numbersA.ToList().ForEach(numA =>
        {
            numbersB.ToList().ForEach(numB =>
            {
                if (numA < numB)
                {
                    Console.WriteLine($"{numA} is less than {numB}");
                }
            });
        });

        HRule();
        
        //6. Select all orders where the order total is less than 500.00.
        ColoredText("Orders with total < 500.0", ConsoleColor.DarkGreen);
        ListGenerator.CustomerList
            .SelectMany(c => c.Orders)
            .Where(o => o.Total < 500m)
            .PrintList(true);

        HRule();

        //7.Select all orders where the order was made in 1998 or later.
        ColoredText("Orders 1998+", ConsoleColor.DarkGreen);
        ListGenerator.CustomerList
            .SelectMany(c => c.Orders)
            .Where(o => o.OrderDate.Year >= 1998)
            .PrintList(true);

        #endregion

        LineBreak(2);

        ColoredText("End of Assignment", ConsoleColor.DarkRed);
    }
}
