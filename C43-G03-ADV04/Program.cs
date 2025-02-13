namespace C43_G03_ADV04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department engineers = new ()
            {
                DeptID = 1,
                DeptName = "Engineers"
            };

            Club codeMasters = new ()
            {
                ClubID = 1,
                ClubName = "Code Masters"
            };

            //Test Age Threshold
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Age Threshold");
            Console.ResetColor();

            Employee employee1 = new ()
            {
                EmployeeID = 1,
                BirthDate = new DateTime(2025 - 61, 10, 8),
                VacationStock = 21
            };

            engineers.AddStaff(employee1);
            codeMasters.AddMember(employee1);

            employee1.EndOfYearOperation();

            Console.WriteLine();
            Console.WriteLine("".PadRight(50, '='));
            Console.WriteLine();

            //Test Vacation Stock
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Vacation Stock");
            Console.ResetColor();

            Employee employee2 = new()
            {
                EmployeeID = 2,
                BirthDate = new DateTime(2025 - 30, 10, 8),
                VacationStock = 21
            };

            engineers.AddStaff(employee2);
            codeMasters.AddMember(employee2);

            employee2.RequestVacation(DateTime.Now, DateTime.Now.AddDays(25));

            Console.WriteLine();
            Console.WriteLine("".PadRight(50, '='));
            Console.WriteLine();

            //Test Sales Person
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sales Person Target Achievement");
            Console.ResetColor();

            SalesPerson sales = new ()
            {
                EmployeeID = 3,
                BirthDate = new DateTime(2025 - 65, 10, 8),
                VacationStock = 21,
                AchievedTarget = 5_000
            };

            sales.EndOfYearOperation(); //should do nothing
            sales.RequestVacation(DateTime.Now, DateTime.Now.AddDays(25)); //should do nothing
            sales.CheckTarget(4_000); //should fire him/her

            Console.WriteLine();
            Console.WriteLine("".PadRight(50, '='));
            Console.WriteLine();

            //Test Board Member
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Test Board Member Resignation");
            Console.ResetColor();

            BoardMember ceo = new()
            {
                EmployeeID = 4,
                BirthDate = new DateTime(2025 - 69, 10, 8),
                VacationStock = 30
            };

            ceo.EndOfYearOperation(); //should do nothing
            ceo.RequestVacation(DateTime.Now, DateTime.Now.AddDays(25)); //should do nothing
            ceo.Resign(); //should fire him/her
        }
    }
}
