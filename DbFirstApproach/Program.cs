using DbFirstApproachPowerTools.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach;

internal class Program
{
    static void Main(string[] args)
    {

        using (NORTHWNDContext context = new NORTHWNDContext())
        {
            #region Working with Stored Procedures
            NORTHWNDContextProcedures contextProcedures = new NORTHWNDContextProcedures(context);

            var customerOrders = contextProcedures.GetCustomerOrderHistoryAsync("ALFKI").Result;

            Console.WriteLine($"ALFKI's orders count: {customerOrders.Count}");

            contextProcedures = null!;
            #endregion

            Console.WriteLine();

            #region Lazy Loading
            Console.WriteLine("Lazy Loading");
            Console.WriteLine("============");
            Console.WriteLine();

            List<Category> categoriesOnly = [.. context.Categories];

            foreach (var cat in categoriesOnly)
            {
                Console.WriteLine(
                    $"{cat.CategoryName}: {(cat.Products.Count > 0 ? $"{cat.Products.Count} product(s)" : "undetermined products count")}");
            }

            #endregion

            Console.WriteLine();

            #region Eager Loading
            Console.WriteLine("Eager Loading");
            Console.WriteLine("=============");
            Console.WriteLine();

            List<Category> categoriesWithProducts = [.. context.Categories
                .Include( e => e.Products ).ThenInclude( e => e.Supplier)];

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

            #endregion

            Console.WriteLine();

            #region Explicit Loading
            Console.WriteLine("Explicit Loading");
            Console.WriteLine("================");
            Console.WriteLine();

            Product product = context.Products.First(p => p.ProductName.ToLower().Contains("chai"));

            //load another navigation property (Refrence)
            context.Entry(product).Reference(x => x.Category).Load();

            //load another navigation property (Collection)
            context.Entry(product).Collection(x => x.OrderDetails).Load();

            Console.WriteLine($"Product: {product.ProductName}");
            Console.WriteLine($"Category: {product.Category.CategoryName}");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{"Order Number"} | {"Quantity"} | {"Unit Price"} | {"Total"}");
            Console.ResetColor();

            foreach (var orderDetail in product.OrderDetails)
            {
                Console.WriteLine(
                    $"{orderDetail.OrderId,+12} | {orderDetail.Quantity,+8} | {orderDetail.UnitPrice,+10} | {orderDetail.Quantity * orderDetail.UnitPrice}");
            }

            #endregion

            Console.WriteLine();

            #region Local vs Remote
            Console.WriteLine("Local vs Remote (Entity Caching)");
            Console.WriteLine("================================");
            Console.WriteLine();

            context.Customers.Load();

            Microsoft.EntityFrameworkCore.ChangeTracking.LocalView<Customer> localCustomers = context.Customers.Local;

            var maxCustLength = localCustomers.Max(x => x.CompanyName.Length);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"            Customer Name              | {"City"}");
            Console.ResetColor();
            foreach (var cust in localCustomers)
            {
                Console.WriteLine($"  {cust.CompanyName.PadRight(maxCustLength)} | {cust.City}");

            }
            #endregion

        }

    }
}
