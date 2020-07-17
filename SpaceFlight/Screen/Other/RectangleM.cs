using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Screen.Other
{
    class RectangleM
    {
        public SizeM Size;
        public PointM Location;

        public decimal X => Location.X;
        public decimal Y => Location.Y;

        public decimal Height => Size.Height;
        public decimal Width => Size.Width;

        public decimal Left => X;
        public decimal Right => X + Width;

        public decimal Top => Y;
        public decimal Bottom => Y + Height;

        public RectangleM(PointM location, SizeM size)
        {
            Size = size;
            Location = location;
        }

        public RectangleM(decimal x, decimal y, decimal width, decimal height)
        {
            Size = new SizeM(width, height);
            Location = new PointM(x, y);
        }

    }
}
