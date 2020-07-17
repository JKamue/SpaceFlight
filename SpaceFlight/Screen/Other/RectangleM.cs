using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Screen.Other
{
    public class RectangleM
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

        public List<PointM> GetCorners()
        {
            return new List<PointM>
            {
                new PointM(Top, Left),
                new PointM(Top, Right),
                new PointM(Bottom, Right),
                new PointM(Bottom, Left)
            };
        }

        public bool Contains(RectangleM rect)
        {
            foreach (var point in rect.GetCorners())
            {
                if (!Contains(point))
                    return false;
            }

            return true;
        }

        public bool IntersectsWith(RectangleM rect)
        {
            foreach (var point in rect.GetCorners())
            {
                if (Contains(point))
                    return true;
            }

            return false;
        }

        public bool Contains(PointM p)
        {
            return (p.X > Left && p.X < Right && p.Y > Top && p.Y < Bottom);
        }
    }
}
