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
            Console.WriteLine("Please, enter the count of angles");
            
            Random gen = new Random();
            int count_of_ages = 0;
            count_of_ages = Convert.ToInt32(Console.ReadLine());
            var triangle = new Triangle[10];
            var polygon = new Polygon[10];
            var points = new Point[count_of_ages];
            var edge = new Edge[count_of_ages];


            int count_of_right_triangles = 0;
            int count_of_isosceles_triangles = 0;

            double perimeter_of_right_triangles = 0;
            double area_of_isosceles_triangles = 0;


            for (int z = 0; z < 10; z++)
            {
                Console.WriteLine("\n_________________________________________________________\n\n {0} figure with {1} angles\n", z + 1, count_of_ages);
                start:
                for (int i = 0; i < points.Length; i++)
                {

                    points[i] = new Point(gen.Next(10), gen.Next(10));


                }


                for (int i = 0; i < count_of_ages; i++)
                {

                    if (i < count_of_ages - 1)
                    {
                        edge[i] = new Edge(points[i], points[i + 1]);
                    }
                    else
                    {
                        edge[i] = new Edge(points[i], points[0]);

                    }
                }

                if (count_of_ages == 3)
                {
                    triangle[z] = new Triangle(edge, points);
                    if (triangle[z].Check() == false)
                    {
                        goto start;
                    }
                    for (int i = 0; i < points.Length; i++)
                    {
                        Console.WriteLine("The length of the {0} edge is {1}", i + 1, edge[i].get_length);
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
                        polygon[z] = new Polygon(edge, points);
                    for (int i = 0; i < points.Length; i++)
                    {
                        Console.WriteLine("The length of the {0} edge is {1}", i + 1, edge[i].get_length);
                    }

                }

            }
                
            
            if (count_of_isosceles_triangles != 0)
            {
                Console.WriteLine("\nThe average area of isosceles triangles is {0}", area_of_isosceles_triangles / count_of_isosceles_triangles);
            }
            if (count_of_right_triangles != 0)
            {
                Console.WriteLine("\nThe average perimeter of right-angled triangles is {0}", perimeter_of_right_triangles / count_of_right_triangles);
            }

            else Console.WriteLine("\nAll the triangles are untyped");


            Console.Read();


        }

    }
}