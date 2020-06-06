using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceFlight.Screen.Calculator
{
    class BoundsCalculator
    {
        public static RectangleF CalculateBounds(List<PointF> points)
        {
            var min = new PointF(Int16.MaxValue,Int16.MaxValue);
            var max = new PointF(Int16.MinValue, Int16.MinValue);

            foreach (var point in points)
            {
                if (point.X > max.X)
                    max.X = point.X;

                if (point.X < min.X)
                    min.X = point.X;

                if (point.Y > max.Y)
                    max.Y = point.Y;

                if (point.Y < min.Y)
                    min.Y = point.Y;
            }

            return new RectangleF(min, new SizeF(max.X - min.X, max.Y - min.Y));
        }
    }
}
