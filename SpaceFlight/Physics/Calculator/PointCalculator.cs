using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    public class PointCalculator
    {
        public static float Distance(PointF p1, PointF p2) =>
            (float) Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

        public static Angle CalculateAngle(PointF p1, PointF p2) =>
            Angle.FromDegrees((Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * -180 / Math.PI) + 90 );
     
    }
}
