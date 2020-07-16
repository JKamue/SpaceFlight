using System;
using System.Drawing;
using SpaceFlight.Physics.Calculator;

namespace SpaceFlight.Physics.Units
{
    public class Vector
    {
        public Angle Angle { get; }
        public double Value { get; }

        public Vector(Angle angle, double value)
        {
            Angle = angle;
            Value = value;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            var x = PointCalculator.GetVectorX(v1) + PointCalculator.GetVectorX(v2);
            var y = PointCalculator.GetVectorY(v1) + PointCalculator.GetVectorY(v2);

            var point = new PointF((float) x, (float) y);

            var resultingValue = PointCalculator.Distance(new PointF(0, 0), point);
            var resultingAngle = PointCalculator.CalculateAngle(new PointF(0, 0), point);

            if (resultingValue < 0.0001)
                resultingAngle = Angle.Zero;

            return new Vector(resultingAngle, resultingValue);
        }
    }
}
