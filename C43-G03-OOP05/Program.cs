namespace C43_G03_OOP05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            #region Part 1
            Console.WriteLine("================================");
            Console.WriteLine("============ Part 1 ============");
            Console.WriteLine("================================");

            #region 2. Override the ToString()
            Console.WriteLine("Question 2");
            Point3D P = new Point3D(10, 10, 10);
            Console.WriteLine(P.ToString());
            #endregion

            Console.WriteLine();

            #region 3. Input Two Points
            Console.WriteLine("Question 3");
            bool isValid;
            double px, py, pz;

            Console.WriteLine("Enter Point 1 coordinates:");
            do
            {
                Console.Write("x: ");
                isValid = double.TryParse(Console.ReadLine(), out px);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            do
            {
                Console.Write("y: ");
                isValid = double.TryParse(Console.ReadLine(), out py);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            do
            {
                Console.Write("z: ");
                isValid = double.TryParse(Console.ReadLine(), out pz);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            Point3D p1 = new Point3D(px, py, pz);


            Console.WriteLine("Enter Point 2 coordinates:");
            do
            {
                Console.Write("x: ");
                isValid = double.TryParse(Console.ReadLine(), out px);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            do
            {
                Console.Write("y: ");
                isValid = double.TryParse(Console.ReadLine(), out py);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            do
            {
                Console.Write("z: ");
                isValid = double.TryParse(Console.ReadLine(), out pz);

                if (!isValid)
                {
                    Console.WriteLine("Invalid Input, try again\n");
                }
            }
            while (!isValid);

            Point3D p2 = new Point3D(px, py, pz);

            p1.ToString();
            p2.ToString();
            #endregion

            Console.WriteLine();

            #region 4. Equality
            Console.WriteLine("Question 4");
            p1 = new Point3D();
            p2 = new Point3D();
            if (p1 == p2)
            {
                Console.WriteLine("p1 equal p2");
            }
            else
            {
                Console.WriteLine("p1 not equal p2");
                Console.WriteLine("== operator will not work properly");
            }
            #endregion

            Console.WriteLine();

            #region 5. Define and Sort Points Array
            Point3D[] points =
            {                            //expected
                new Point3D(15, 25, 30), //4
                new Point3D(10, 25, 30), //2
                new Point3D(25, 15, 30), //5
                new Point3D(10, 20, 30), //1
                new Point3D(15, 20, 30), //3
            };

            for (int i = 0; i < points.Length - 1; i++)
            {
            
                for (int j = i + 1; j < points.Length; j++)
                {
                    if ((points[i].X > points[j].X) ||
                        (points[i].X == points[j].X &&  points[i].Y > points[j].Y))
                    {
                        Point3D temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }
                }
            }

            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i].ToString());
            }

            #endregion
            #endregion

            Console.WriteLine();

            #region Part 2
            Console.WriteLine("================================");
            Console.WriteLine("============ Part 2 ============");
            Console.WriteLine("================================");

            Console.WriteLine("10 + 20 = " + Maths.Add(10,20));
            Console.WriteLine("20 - 10 = " + Maths.Subtract(20,10));
            Console.WriteLine("10 x 20 = " + Maths.Multiply(10,20));
            Console.WriteLine("20 ÷ 10 = " + Maths.Divide(20,10));
            #endregion

            Console.WriteLine();

            #region Part 3
            Console.WriteLine("================================");
            Console.WriteLine("============ Part 3 ============");
            Console.WriteLine("================================");

            Console.WriteLine("Duration 1: 1 hr , 10 min , 15 sec");
            Duration d1 = new Duration(1, 10, 15);
            Console.WriteLine(d1.ToString());

            Console.WriteLine();

            Console.WriteLine("Duration 2: 3600 sec");
            d1 = new Duration(3600);
            Console.WriteLine(d1.ToString());

            Console.WriteLine();

            Console.WriteLine("Duration 3: 7800 sec");
            d1 = new Duration(7800);
            Console.WriteLine(d1.ToString());

            Console.WriteLine();

            Console.WriteLine("Duration 4: 666 sec");
            d1 = new Duration(666);
            Console.WriteLine(d1.ToString());
            #endregion

            Console.WriteLine();

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
