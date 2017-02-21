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
            int count_of_ages = 0;
            start1:
            count_of_ages = Convert.ToInt32(Console.ReadLine());

            if (count_of_ages <= 2)
            {
                Console.WriteLine("Sorry, you made a mistake, please, enter the count of angles again ");
                goto start1;
            }
           
            Random gen = new Random();
            

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

                    points[i] = new Point(gen.Next(15), gen.Next(15));


                }

                if (CheckPoint(points) == false)
                {
                    goto start;
                }

               

                for (int i = 0; i < count_of_ages-1; i++)
                {

                   edge[i] = new Edge(points[i], points[i + 1]);
                   edge[count_of_ages - 1] = new Edge(points[count_of_ages - 1], points[0]);

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
                        Console.WriteLine("The x is {0} the y is {1}", points[i].x, points[i].y);

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
                        Console.WriteLine("The x is {0} the y is {1}", points[i].x, points[i].y);
                        
                    }
                    for (int i = 0; i < points.Length; i++)
                    {
                       
                        Console.WriteLine("The length of the {0} edge is {1}", i + 1, edge[i].get_length);
                    }

                    if (polygon[z].Area == 0)
                    {
                        goto start;
                    }


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


        public static bool CheckPoint(Point [] point)
        {
            bool tmp = false;
            for (int i = 0; i < point.Length;i++)
            {
                for (int j = point.Length-1; j > 0; j--)
                {
                    
                    if (point[j].x == point[i].x && point[j].y == point[i].y && i !=j)
                    {
                       
                        tmp = false; goto end;

                    }

                    
                    else tmp = true; 
                    
                }

            }

            end: return tmp;  
        }

    }
}