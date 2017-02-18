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
        public double area;
        public double perimeter;


        public Polygon(Edge[] edge1, Point[] point1)
        {
            edge = edge1;
            point = point1;
      
        }

        public double Perimeter
        {
            get
            {
                perimeter = 0;
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
                area = 0;
                for (int i = 0; i < point.Length - 1; i++)
                {
                    area = area +(point[i].x * point[i + 1].y - point[i].y * point[i + 1].x);
                }
                area = area + (point[point.Length - 1].x * point[0].y - point[point.Length - 1].y * point[0].x);
                return Math.Abs(area / 2);
               
            }
        }


       

        public bool Check
        {???
            
            }
        }

    

}
}