using static System.Console;
using static C43_G03_LINQ02.ConsoleFormatter;
using static ASSLINQ.ListGenerators;

namespace C43_G03_LINQ02;

internal class Program
{
    static void Main(string[] args)
    {
        ColoredText("LINQ 01 Assignment", ConsoleColor.DarkRed);
        LineBreak(2);

        #region LINQ - Element Operators
        ColoredText("###   LINQ - Element Operators   ###", ConsoleColor.DarkCyan, true, true);
        LineBreak();

        //1. Get first Product out of Stock
        ColoredText("1. First Product out of Stock:", ConsoleColor.DarkGreen);
        WriteLine(ProductList.First(p => p.UnitsInStock <= 0));

        HRule();

        //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
        ColoredText("2. First Product with Price > 1k:", ConsoleColor.DarkGreen);
        WriteLine((ProductList.FirstOrDefault(p => p.UnitPrice > 1_000m)?.ToString() ?? "No match found"));

        HRule();

        //3. Retrieve the second number greater than 5
        {
            int[] Arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            ColoredText("3. 2nd number > 5:", ConsoleColor.DarkGreen);
            WriteLine(Arr.Where(n => n > 5).ElementAt(1));
        }

        HRule();

        #endregion

        #region LINQ - Aggregate Operators
        ColoredText("###   LINQ - Aggregate Operators   ###", ConsoleColor.DarkCyan, true, true);
        LineBreak();

        //1. Uses Count to get the number of odd numbers in the array
        {
            int[] Arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

            ColoredText("3. Odd numbers count:", ConsoleColor.DarkGreen);
            foreach (var number in Arr)
            {
                if (number % 2 != 0)
                {
                    ForegroundColor = ConsoleColor.Magenta;
                    Write(number);
                    ResetColor();
                }
                else
                {
                    Write(number);
                }

                Write("  ");
            }
            WriteLine();
            WriteLine(Arr.Count(n => n % 2 != 0));
        }

        HRule();

        //2. Return a list of customers and how many orders each has.
        ColoredText("2. Customers and Orders count:", ConsoleColor.DarkGreen);
        CustomerList.Select(cust => new
        {
            Customer = cust,
            OrdersCount = cust.Orders.Length
        }).PrintList(listItem => $"{listItem.Customer}, Orders No. = {listItem.OrdersCount}");

        //3. Return a list of categories and how many products each has
        ColoredText("3. Categories and Products count:", ConsoleColor.DarkGreen);
        var categories = ProductList.Select(p => p.Category).Distinct().ToList();

        categories.Select(cat => new
        {
            Category = cat,
            ProductsCount = ProductList.Count(p => p.Category == cat)
        }).PrintList(listItem => $"{listItem.Category,-15} | {listItem.ProductsCount} product(s)");

        HRule();

        //4. Get the total of the numbers in an array.
        ColoredText("4. total of the numbers:", ConsoleColor.DarkGreen);
        {
            int[] Arr = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];
            WriteLine(Arr.Sum());
        }

        //5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

        HRule();

        //6. Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

        HRule();

        //7. Get the length of the longest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

        HRule();

        //8. Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

        HRule();

        //9. Get the total units in stock for each product category.
        ColoredText("9. total units in stock for each product category:", ConsoleColor.DarkGreen);

        HRule();

        //10. Get the cheapest price among each category's products
        ColoredText("10. categories cheapest product price:", ConsoleColor.DarkGreen);
        Categories.Select(cat => new
        {
            Category = cat,
            Price = ProductList.Where(p => p.Category == cat).Min(p => p.UnitPrice)
        }).PrintList(listItem => $"{listItem.Category,-15}| {listItem.Price}");

        HRule();

        //11. Get the products with the cheapest price in each category(Use Let)

        HRule();

        //12. Get the most expensive price among each category's products.
        ColoredText("12. categories expensive product price:", ConsoleColor.DarkGreen);
        Categories.Select(cat => new
        {
            Category = cat,
            Price = ProductList.Where(p => p.Category == cat).Max(p => p.UnitPrice)
        }).PrintList(listItem => $"{listItem.Category,-15}| {listItem.Price}");

        HRule();

        //13. Get the products with the most expensive price in each category.
        ColoredText("13. categories expensive product:", ConsoleColor.DarkGreen);
        Categories.Select(cat => new
        {
            Category = cat,
            Product = ProductList.Where(p => p.Category == cat).MaxBy(p => p.UnitPrice)
        }).PrintList(listItem => $"{listItem.Category,-15}| {listItem.Product}");

        HRule();

        //14. Get the average price of each category's products.
        ColoredText("14. categories average product price:", ConsoleColor.DarkGreen);
        Categories.Select(cat => new
        {
            Category = cat,
            AvgPrice = ProductList.Where(p => p.Category == cat).Average(p => p.UnitPrice)
        }).PrintList(listItem => $"{listItem.Category,-15}| {listItem.AvgPrice}");

        HRule();

        #endregion

        #region LINQ - Set Operators

        ColoredText("###   LINQ - Set Operators   ###", ConsoleColor.DarkCyan, true, true);
        LineBreak();

        //1. Find the unique Category names from Product List
        ColoredText("1. Find the unique Category names from Product List:", ConsoleColor.DarkGreen);
        ProductList.Select(p => p.Category).Distinct().PrintList();

        HRule();
        
        //shared variables for the next questions
        var productsFirstLetterList = ProductList.Select(p => p.ProductName[0]).ToList();
        var customersFirstLetterList = CustomerList.Select(c => c.CustomerName[0]).ToList();

        //2. Produce a Sequence containing the unique first letter from both product and customer names.
        ColoredText("2. Produce a Sequence containing the unique first letter from both product and customer names.:", ConsoleColor.DarkGreen);
        productsFirstLetterList.Union(customersFirstLetterList).PrintListInline();
        
        WriteLine("\nOrdered");
        productsFirstLetterList.Union(customersFirstLetterList).Order().PrintListInline();

        HRule();

        //3. Create one sequence that contains the common first letter from both product and customer names.
        ColoredText("3. Create one sequence that contains the common first letter from both product and customer names.:", ConsoleColor.DarkGreen);
        productsFirstLetterList.Concat(customersFirstLetterList).PrintListInline();
        
        WriteLine("\nOrdered");
        productsFirstLetterList.Concat(customersFirstLetterList).Order().PrintListInline();

        HRule();

        //4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
        ColoredText("4. Create one sequence that contains the first letters of product names that are not also first letters of customer names:", ConsoleColor.DarkGreen);
        productsFirstLetterList.Except(customersFirstLetterList).PrintList();

        HRule();

        //5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates
        ColoredText("5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates:", ConsoleColor.DarkGreen);
        var customersLast3Letters = CustomerList.Select(c => c.CustomerName[^3..]).ToList();
        var productsLast3Letters = ProductList.Select(p => p.ProductName[^3..]).ToList();
        customersLast3Letters.Concat(productsLast3Letters).PrintListInline();

        HRule();

        #endregion

        #region LINQ - Quantifiers
        ColoredText("###   LINQ - Quantifiers   ###", ConsoleColor.DarkCyan, true, true);
        LineBreak();

        //1. Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
        ColoredText("1. Determine if any of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First) contain the substring 'ei'.:", ConsoleColor.DarkGreen);

        HRule();

        //2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
        ColoredText("2. Return a grouped a list of products only for categories that have at least one product that is out of stock.:", ConsoleColor.DarkGreen);

        HRule();

        //3. Return a grouped a list of products only for categories that have all of their products in stock.
        ColoredText("3. Return a grouped a list of products only for categories that have all of their products in stock.:", ConsoleColor.DarkGreen);

        HRule();
        
        #endregion

        LineBreak(2);

        ColoredText("End of Assignment", ConsoleColor.DarkRed);
    }
}
