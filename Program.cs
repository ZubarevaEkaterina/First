using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to enter your coordinates? Enter 'n'(no) or 'y'(yes)\nor go to example: 'e' ");
            char answer;
            int count_of_ages = 0;
            int n = 0;
            start2:
            answer = Convert.ToChar(Console.ReadLine());

            if (answer != 'y' && answer != 'n' && answer != 'e')
            {
                Console.WriteLine("Sorry, you made a mistake, please, enter 'n' or 'y' ");
                goto start2;
            }

            if (answer == 'e')
            {
                n = 1;
                count_of_ages = 6;
                goto example;
            }


            Console.WriteLine("Please, enter the count of figures");

            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please, enter the count of angles");

            start1:
            count_of_ages = Convert.ToInt32(Console.ReadLine());

            if (count_of_ages <= 2)
            {
                Console.WriteLine("Sorry, you made a mistake, please, enter the count of angles again ");
                goto start1;
            }


            example:
            Random gen = new Random();


            var triangle = new Triangle[n];
            var polygon = new Polygon[n];

            var points = new Point[count_of_ages];

            int count_of_right_triangles = 0;
            int count_of_isosceles_triangles = 0;

            double perimeter_of_right_triangles = 0;
            double area_of_isosceles_triangles = 0;


            for (int z = 0; z < n; z++)
            {
                Console.WriteLine("\n_________________________________________________________\n\n {0} figure with {1} angles\n", z + 1, count_of_ages);

                start:

                if (answer == 'n')
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new Point(gen.Next(15), gen.Next(15));
                    }
                }

                if (answer == 'e')
                {
                    points[0] = new Point(2, 0);
                    points[1] = new Point(5, 1);
                    points[2] = new Point(5, 3);
                    points[3] = new Point(3, 6);
                    points[4] = new Point(2, 5);
                    points[5] = new Point(1, 2);


                }

                if (answer == 'y')
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        Console.WriteLine("x and y for {0} point:", i + 1);
                        points[i] = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));

                    }
                }

                if (CheckPoint(points) == false)
                {
                    goto start;
                }

                if (count_of_ages == 3)
                {

                    triangle[z] = new Triangle(points);
                    triangle[z].CreateFigure();

                    if (triangle[z].Check() == false)
                    {
                        Console.WriteLine("Triangle doesn't exist \n");
                        goto start;
                    }

                    if (triangle[z].CheckRight() == true)
                    {
                        Console.WriteLine("\nTriangle is right ");

                        perimeter_of_right_triangles = perimeter_of_right_triangles + triangle[z].Perimeter;
                        count_of_right_triangles = count_of_right_triangles + 1;
                    }

                    else if (triangle[z].CheckIsosceles() == true)
                    {
                        Console.WriteLine("\nTriangle is isosceles ");

                        area_of_isosceles_triangles = area_of_isosceles_triangles + triangle[z].Area;
                        count_of_isosceles_triangles = count_of_isosceles_triangles + 1;
                    }

                    else
                    {
                        Console.WriteLine("\nTriangle has no type ");
                    }
                    Console.WriteLine("The perimeter is " + triangle[z].Perimeter);
                    Console.WriteLine("and the area is " + triangle[z].Area);
                }


                if (count_of_ages != 3)
                {
                    polygon[z] = new Polygon(points);
                    polygon[z].CreateFigure();

                    Console.WriteLine("The perimeter is " + polygon[z].Perimeter);
                    Console.WriteLine("and the area is " + polygon[z].Area);
                }
            }

            if (count_of_ages == 3)
            {
                avearage_area_and_perieter(count_of_isosceles_triangles, count_of_right_triangles, area_of_isosceles_triangles, perimeter_of_right_triangles);
            }

            Console.Read();
        }


        public static void avearage_area_and_perieter(int counti, int countr, double areai, double perimeterr)
        {
            if (counti != 0)
            {
                Console.WriteLine("\nThe average area of isosceles triangles is {0}", areai / counti);
            }

            if (countr != 0)
            {
                Console.WriteLine("\nThe average perimeter of right-angled triangles is {0}", perimeterr / countr);
            }

            else Console.WriteLine("\nAll the triangles are untyped");
        }


        public static bool CheckPoint(Point[] point)
        {
            bool tmp = false;
            for (int i = 0; i < point.Length; i++)
            {
                for (int j = point.Length - 1; j > 0; j--)
                {

                    if (point[j].x == point[i].x && point[j].y == point[i].y && i != j)
                    {
                        Console.WriteLine("Figure doesn't exist \n");
                        tmp = false; goto end;
                    }
                    else tmp = true;
                }
            }
            end: return tmp;
        }
    }
}