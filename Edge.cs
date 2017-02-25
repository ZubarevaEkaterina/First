using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Edge
    {
        public Point first_point_of_edge, second_point_of_edge;

        public Edge(Point f, Point s)
        {
            first_point_of_edge = f;
            second_point_of_edge = s;
        }

        public double get_length
        {
            get

            {
                return Math.Sqrt(Math.Pow((first_point_of_edge.x - second_point_of_edge.x), 2) + Math.Pow((first_point_of_edge.y - second_point_of_edge.y), 2));

            }
        }
    }
}