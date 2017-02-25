using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Polygon
    {
        private Point[] point;
        private Edge[] edge;


        public Polygon(Point[] point1)
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
                for (int i = 0; i < point.Length - 1; i++)
                {
                    area = area + (point[i].x * point[i + 1].y - point[i].y * point[i + 1].x);
                }
                area = area + (point[point.Length - 1].x * point[0].y - point[point.Length - 1].y * point[0].x);
                return Math.Abs(area / 2);

            }
        }
    }
}






