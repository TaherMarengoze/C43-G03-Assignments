namespace C43_G03_OOP06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration d1 = new (4, 45, 45);
            Duration d2 = new (1, 25, 35);

            Console.WriteLine("d1 = " + d1.ToString());
            Console.WriteLine("d2 = " + d2.ToString());

            
            Console.WriteLine();


            Console.WriteLine("d1 + d2 = ");
            Duration d3 = d1 + d2;
            Console.WriteLine(d3);

            
            Console.WriteLine();


            Console.WriteLine("d1 + 7800 = ");
            d3 = d1 + 7800;
            Console.WriteLine(d3);

            
            Console.WriteLine();


            Console.WriteLine("666 + d3 = ");
            d3 = 666 + d3;
            Console.WriteLine(d3);

            
            Console.WriteLine();


            Console.WriteLine("++d1 = ");
            d3 = ++d1;
            Console.WriteLine(d3);

            
            Console.WriteLine();


            Console.WriteLine("--d2 = ");
            d3 = --d2;
            Console.WriteLine(d3);

            
            Console.WriteLine();


            Console.WriteLine("d1 - d2 = ");
            d1 = d1 - d2;
            Console.WriteLine(d1);

            
            Console.WriteLine();


            Console.WriteLine("If (d1 > d2)");
            if (d1 > d2)
            {
                Console.WriteLine("d1 is greater than d2");
            }

            
            Console.WriteLine();


            Console.WriteLine("If (d1 <= d2)");
            if (d1 <= d2)
            {
                Console.WriteLine("d1 is less than or equal to d2");
            }

            
            Console.WriteLine();


            Console.WriteLine("If (d1)");
            if (d1)
            {
                Console.WriteLine("d1 is true");
            }


            Console.WriteLine("Casting d1 to DateTime");
            DateTime obj = (DateTime)d1;
            Console.WriteLine(obj);

            Console.WriteLine();
            Console.WriteLine("Press ENTER key to exit...");
            Console.ReadLine();
        }
    }
}
/*

 • D3=D1+D2
 • D3=D1 + 7800
 • D3=666+D3
 • D3= ++D1 (Increase One Minute)
 • D3 = --D2 (Decrease One Minute)
 • D1= D1 -D2
 • If (D1>D2)
 • If (D1<=D2)
 • If (D1)
 • DateTime Obj = (DateTime) D1

*/