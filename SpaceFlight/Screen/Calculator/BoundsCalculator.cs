using System;
using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Screen.Other;

namespace SpaceFlight.Screen.Calculator
{
    class BoundsCalculator
    {
        public static RectangleM CalculateBounds(List<PointM> points)
        {
            var min = new PointM(Int64.MaxValue,Int64.MaxValue);
            var max = new PointM(Int64.MinValue, Int64.MinValue);

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

            return new RectangleM(min, new SizeM(max.X - min.X, max.Y - min.Y));
        }
    }
}
