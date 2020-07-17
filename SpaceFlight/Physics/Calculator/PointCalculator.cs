using System;
using System.Drawing;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Physics.Calculator
{
    public class PointCalculator
    {
        public static decimal Distance(PointM p1, PointM p2) =>
            (decimal) Math.Sqrt(Math.Pow((double) (p2.X - p1.X), 2) + Math.Pow((double)(p2.Y - p1.Y), 2));

        public static Angle CalculateAngle(PointM p1, PointM p2) =>
            Angle.FromDegrees((Math.Atan2((double)(p2.Y - p1.Y), (double)(p2.X - p1.X)) * -180 / Math.PI) + 90 );

        public static decimal GetVectorX(Vector v) => v.Value * (decimal) Math.Sin(v.Angle.Radian);
        public static decimal GetVectorY(Vector v) => v.Value * (decimal) Math.Cos(v.Angle.Radian);

    }
}
