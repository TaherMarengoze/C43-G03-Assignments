namespace C43_G03_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 2
            Book b = new ("1234",
                          "The Lord of the Rings",
                          "J.K Tolkeins",
                          new DateTime(1999, 9, 19),
                          600);
            Console.WriteLine(b);


            Console.Write("\n\n\n\n\n");


            Book b2 = new("5678",
                "Sherlok Holmes: Game of Shadows",
                "Arthas Conan Doyle",
                new DateTime(1977, 5, 22),
                150);

            List<Book> bList = [b, b2];

            Console.WriteLine("Display Title:");
            LibraryEngine.ProcessBooks(
                bList,
                (BookFunctionsDelegate)BookFunctions.GetTitle);

            Console.Write("\n");

            Console.WriteLine("Display Authors:");
            LibraryEngine.ProcessBooks(
                bList,
                (Func<Book, string>)BookFunctions.GetAuthor);

            Console.Write("\n");

            Console.WriteLine("Display Prices:");
            LibraryEngine.ProcessBooks(
                bList,
                (BookFunctionsDelegate)BookFunctions.GetPrice);

            Console.Write("\n");

            Console.WriteLine("Display ISBNs:");
            LibraryEngine.GetISBN(bList);

            Console.Write("\n");

            Console.WriteLine("Display Publication Dates:");
            LibraryEngine.GetPublicationDate(bList);

            Console.Write("\n\n\n\n\n");
            #endregion

            Console.WriteLine("".PadRight(50, '='));

            #region Part 3
            /*
             ● Exist (No overload)
             ● Find (No overload)
             ● Find All (No overload)
             ● Find index (2 overloads)
             ● Find Last (No overload)
             ● Find Last Index (2 overloads)
             ● Foreach (No overload)
             ● TrueForAll (No overload)
            */

            List<int> numbers = [
                .. Enumerable.Range(1, 10),
                11,
                .. Enumerable.Range(1, 10).Reverse()
                ];


            Console.WriteLine("5, Exists ?");
            Console.WriteLine(ListMethods.Exist(numbers, 5));

            Console.WriteLine("==========\n");

            Console.WriteLine("Find 4");
            Console.WriteLine(ListMethods.Find(numbers, 4));

            Console.WriteLine();

            Console.WriteLine("Find 50");
            Console.WriteLine(ListMethods.Find(numbers, 50));

            Console.WriteLine("==========\n");

            Console.WriteLine("Find All 4");
            Console.WriteLine(ListMethods.FindAll(numbers, 4)?.Count);

            Console.WriteLine("==========\n");

            Console.WriteLine("Find Index of 6");
            Console.WriteLine(ListMethods.FindIndex(numbers, 6));

            Console.WriteLine();

            Console.WriteLine("Find Index of 6 starting from 8");
            Console.WriteLine(ListMethods.FindIndex(numbers, 8, 6));

            Console.WriteLine("==========\n");

            Console.WriteLine("Find Last 3");
            Console.WriteLine(ListMethods.FindLast(numbers, 3));

            Console.WriteLine("==========\n");

            Console.WriteLine("Find Last Index 3");
            Console.WriteLine(ListMethods.FindLastIndex(numbers, 3));

            Console.WriteLine("==========\n");

            Console.WriteLine("ForEach");
            ListMethods.ForEach(numbers,
                num => Console.WriteLine(num % 2 == 0 ? $"{num}: Even" : $"{num}: Odd"));

            Console.WriteLine("==========\n");

            Console.WriteLine("TrueForAll");
            Console.WriteLine("All numbers less than 30 ?");
            Console.WriteLine(ListMethods.TrueForAll(numbers, num => num < 30));

            #endregion
        }
    }
}
