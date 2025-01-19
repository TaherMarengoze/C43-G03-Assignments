using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Question 01:

Define an interface named IShape with a property Area and a method
DisplayShapeInfo. Create two interfaces, ICircle and IRectangle, that inherit from
IShape. Implement these interfaces in classes Circle and Rectangle. Test your
implementation by creating instances of both classes and displaying their shape
information.
*/

namespace C43_G03_OOP04.Part_02
{
    public interface IShape
    {
        string Area { get; set; }

        void DisplayShapeInfo();
    }

    public interface ICircle : IShape
    {

    }

    public interface IRectangle : IShape
    {

    }



    public class Circle : ICircle
    {
        public string Area { get; set; } = "π * r²";

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle: Area = {Area}");
        }
    }

    public class Rectangle : IRectangle
    {
        public string Area { get; set; } = "l * w";

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle: Area = {Area}");
        }
    }
}
