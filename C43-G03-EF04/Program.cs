using C43_G03_EF04.Generation_Ways;
using Microsoft.EntityFrameworkCore;

namespace C43_G03_EF04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using TPHDbContext context = new TPHDbContext();

            //context.Vehicles.Add(new Car { Model = "A8", Make = "Audi", DoorsCount = 2 });
            //context.Add(new Car { Model = "Z4", Make = "BMW", DoorsCount = 3 });
            //context.Set<Truck>().Add(new Truck { Model = "B9", Make = "Chevy", LoadCapacity = 500 });
            //context.Add(new Truck { Model = "BX", Make = "Chevy", LoadCapacity = 800 });
            //context.SaveChanges();

            #region Discrimenator Column and Getting Entity by type

            //1. Using EF.Property
            var cars = context.Vehicles
                .Where(v => EF.Property<string>(v, "VehicleFamily") == "CarFamily")
                .ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Model} ({car.Make}) {(car as Car)?.DoorsCount} door(s)");
            }

            Console.WriteLine("==========");

            //2. OfType
            List<Car> cars2 = [.. context.Vehicles.OfType<Car>()];
            foreach (var car in cars2)
            {
                Console.WriteLine($"{car.Id}: {car.Model} ({car.Make}) {car.DoorsCount} door(s)");
            }

            Console.WriteLine("==========");

            //3. Using DbSet
            var trucks = context.Trucks.ToList();

            foreach (var truck in trucks)
            {
                Console.WriteLine($"{truck.Id}: {truck.Model} ({truck.Make}), Capacity:{truck.LoadCapacity}");
            }

            #endregion
        }
    }
}
