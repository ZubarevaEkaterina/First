using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Triangle

    {   private Point[] point;
        private Edge[] edge;
       
        
        public Triangle(Point[] point1)
        {
           
            point = point1;
         }


        public void CreateFigure()
        {
            edge = new Edge[point.Length];
            for (int i = 0; i < point.Length - 1; i++)
            {
                    edge[i] = new Edge(point[i], point[i + 1]);
                    edge[point.Length - 1] = new Edge(point[point.Length - 1], point[0]);

                }

            for (int i = 0; i < point.Length; i++)
            {
                Console.WriteLine("The length of the {0} edge is {1}", i + 1, edge[i].get_length);
            }

        }


        public double Perimeter
        { 
            get
            {
               double perimeter = 0;
                {
                    for (int i = 0; i < edge.Length; i++)
                    {
                        perimeter = edge[i].get_length + perimeter;
                    }
                }
                return perimeter;
               
            }
        }

        public double Area
        {
            get
            {
               double area = 0;
                double p = Perimeter/2;
                return area = Math.Sqrt(p * (p - edge[0].get_length) * (p - edge[1].get_length)*(p - edge[2].get_length));

            }
        }

        public bool Check()
        {
            if (edge[0].get_length + edge[1].get_length <= edge[2].get_length ||
                edge[0].get_length + edge[2].get_length <= edge[1].get_length ||
                edge[1].get_length + edge[1].get_length <= edge[0].get_length)
                return false;
            else
                return true;
        }



        public bool CheckIsosceles()
        {
            if (edge[0].get_length == edge[1].get_length || edge[0].get_length == edge[2].get_length || edge[1].get_length == edge[2].get_length)
                return true;
            else
                return false;
        }

        public bool CheckRight()
        {
            if (Math.Pow(edge[0].get_length, 2) + Math.Pow(edge[1].get_length, 2) == Math.Pow(edge[2].get_length, 2)
         || Math.Pow(edge[0].get_length, 2) + Math.Pow(edge[2].get_length, 2) == Math.Pow(edge[1].get_length, 2)
         || Math.Pow(edge[1].get_length, 2) + Math.Pow(edge[2].get_length, 2) == Math.Pow(edge[0].get_length, 2))
                return true;
            else
                return false;
        }


    }
}
