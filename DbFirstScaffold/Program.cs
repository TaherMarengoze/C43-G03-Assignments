using DbFirstScaffold.Models;

namespace DbFirstScaffold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwndContext context = new NorthwndContext();

            List<Category> categoriesWithProducts = [.. context.Categories];

            foreach (var cat in categoriesWithProducts)
            {
                Console.WriteLine($"{cat.CategoryName}");

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"{" ProductName",-36} | Supplier Name");
                Console.ResetColor();

                foreach (var prod in cat.Products)
                {
                    Console.WriteLine($"  - {prod.ProductName,-32} | {prod.Supplier.CompanyName}");
                }
                Console.WriteLine();
            }
        }
    }
}
