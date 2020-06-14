using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Calculator;

namespace SpaceFlight.Physics.Units
{
    public class Vector
    {
        public Angle Angle { get; }
        public double Value { get; }
        private double Pow => Math.Pow(Value, 2);

        public Vector(Angle angle, double value)
        {
            Angle = angle;
            Value = value;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            var x = PointCalculator.GetVectorX(v1) + PointCalculator.GetVectorX(v2);
            var y = PointCalculator.GetVectorY(v1) + PointCalculator.GetVectorY(v2);

            var point = new PointF((float) x , (float) y);

            var resultingValue = PointCalculator.Distance(new PointF(0, 0), point);
            var resultingAngle = PointCalculator.CalculateAngle(new PointF(0, 0), point);

            if (resultingValue < 0.0001)
                resultingAngle = Angle.FromDegrees(0);

            return new Vector(resultingAngle, resultingValue);
        }
    }
}
