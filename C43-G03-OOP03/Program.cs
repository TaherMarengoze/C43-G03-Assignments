using C43_G03_OOP03.Part02;

namespace C43_G03_OOP03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, to Assignment OOP 03");
            //========================================================

            InputEmployees();
            SortEmployees();

            //============================================
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        #region Part01
        //refer to folder Part 01
        #endregion


        #region Part02
        //refer to folder Part 02

        public static Employee[] EmpArr = new Employee[3];



        static void InputEmployees()
        {
            string name;
            object genderObj;
            Gender gender;
            double salary;
            DateOnly hireDate;
            
            bool isValidInput;

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter Employee #{i + 1} name: ");
                name = Console.ReadLine()!;

                //============================================================================================

                do
                {
                    Console.Write("ENter Gender (M = Male | F = Female): ");
                    isValidInput = Enum.TryParse(typeof(Gender), Console.ReadLine(), true, out genderObj);
                    DisplayErrorIfInvalid(!isValidInput);

                } while (!isValidInput);
                gender = (Gender)genderObj!;

                EmpArr[i] = new Employee(i, name!, gender);

                //============================================================================================

                do
                {
                    Console.Write("Enter Salary: ");
                    isValidInput = double.TryParse(Console.ReadLine(), out salary);
                    DisplayErrorIfInvalid(!isValidInput);
                }
                while (!isValidInput);

                EmpArr[i].Salary = salary;

                //============================================================================================

                do
                {
                    Console.Write("Enter Hire Date: ");
                    isValidInput = DateOnly.TryParse(Console.ReadLine(), out hireDate);
                    DisplayErrorIfInvalid(!isValidInput);
                }
                while (!isValidInput);

                EmpArr[i].HireDate = new HireDate(hireDate);

                Console.WriteLine("\n");
            }

            EmpArr[0].SecurityLevel = Privileges.DBA;
            EmpArr[1].SecurityLevel = Privileges.Guest;
            EmpArr[2].SecurityLevel = Privileges.Guest
                                    | Privileges.Developer
                                    | Privileges.Secretary
                                    | Privileges.DBA;

            Console.WriteLine("\n");
        }

        #region 4: Sort the employees based on their hire date then Print the sorted array
        static void SortEmployees()
        {
            DateOnly hireDate1;
            DateOnly hireDate2;
            Employee temp;

            Console.WriteLine("Sorting ASC by hire date");

            for (int i = 0; i < EmpArr.Length; i++)
            {
                for (int j = i+1; j < EmpArr.Length; j++)
                {
                    hireDate1 = DateOnly.Parse(EmpArr[i].HireDate.ToString());
                    hireDate2 = DateOnly.Parse(EmpArr[j].HireDate.ToString());

                    if (hireDate1 > hireDate2)
                    {
                        temp = EmpArr[i];
                        EmpArr[i] = EmpArr[j];
                        EmpArr[j] = temp;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Employee #{i + 1}");
                Console.WriteLine(EmpArr[i].ToString());
                Console.WriteLine("".PadLeft(40,'='));
            }
        }
        #endregion

        static void DisplayErrorIfInvalid(bool isInvalidInput)
        {
            if (isInvalidInput)
            {
                Console.WriteLine("Invalid Input, Try again");
            }
        }

        #endregion
    }
}
