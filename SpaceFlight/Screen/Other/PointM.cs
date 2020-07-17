using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SpaceFlight.Screen
{
    public struct PointM
    {
        public decimal X;
        public decimal Y;

        public PointM(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public PointM(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
