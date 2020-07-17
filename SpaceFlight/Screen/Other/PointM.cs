using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Screen
{
    public struct PointM
    {
        public decimal X;
        public decimal Y;

        public static PointM Empty = new PointM(0,0);
        public PointM(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public PointM(int x, int y)
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
