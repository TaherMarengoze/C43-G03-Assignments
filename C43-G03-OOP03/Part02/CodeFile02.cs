using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C43_G03_OOP03.Part02
{
    #region 1: Design and implement a Class for the employees in a company
    public class Employee
    {
        /*
         - Employee is identified by an ID, Name, security level, salary, hire date and Gender.
         - We need to restrict the Gender field to be only M or F [Male or Female]
         - Assign the following security privileges to the employee (guest, Developer, secretary and DBA) in a form of Enum.
         - We want to provide the Employee Class to represent Employee data in a string Form (override ToString ()),
            display employee salary in a currency format. [Use String.Format() Function]
         */

        public Employee(int id, string name, Gender gender)
        {
            Id = id;
            Name = name;
            Gender = gender;
        }

        public Employee(int id, string name, Gender gender,
                        Privileges privileges, double salary, HireDate hireDate)
            : this(id,name,gender)
        {
            SecurityLevel = privileges;
            Salary = salary;
            HireDate = hireDate;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Privileges SecurityLevel { get; set; }

        public double Salary { get; set; }

        public HireDate HireDate { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {1}\nName: \nHire Date: {3}\n{2}\nSalary: {0:C2}",
                Salary,
                Id,
                Name,
                HireDate.ToString()
                );

        }
    }

    public enum Gender
    {
        M = 1,
        F = 2
    }

    [Flags]
    public enum Privileges
    {
        Guest = 1,
        Developer = 2,
        Secretary = 4,
        DBA = 8
    }

    #endregion



    #region 2: Develop a Class to represent the Hiring Date Data
    //Consisting of fields to hold the day, month and Years

    public class HireDate
    {
        public HireDate()
        {
            
        }

        public HireDate(string dateString)
        {
            if (!DateOnly.TryParse(dateString, out DateOnly date))
                date = DateOnly.MinValue;

            Day = (byte)date.Day;
            Month = (byte)date.Month;
            Year = (short)date.Year;
        }

        public HireDate(DateOnly date)
        {
            Day = (byte)date.Day;

            Month = (byte)date.Month;

            Year = (short)date.Year;
        }

        public HireDate(byte day, byte month, short year)
        {
            if (month < 1) month = 1;
            if (month > 12) month = 12;
            
            if (year < 1919) year = 1919;
            if (year > 2919) year = 2919;

            int maxMonthDay = DateTime.DaysInMonth(year, month);
            if (day < 1) day = 1;
            if (day > maxMonthDay) day = (byte)maxMonthDay;

            Day = day;
            Month = month;
            Year = year;
        }

        public byte Day { get; private set; }

        public byte Month { get; private set; }

        public short Year { get; private set; }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    #endregion

    public class Dummy
    {
        public Employee[] EmpArr = new Employee[3];
    }
}
