using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Vector operator +(Vector f1, Vector f2)
        {
            if (f1.Angle.Degree > f2.Angle.Degree)
            {
                var t = f1;
                f1 = f2;
                f2 = t;
            }
            else if (f1.Angle.Degree == f2.Angle.Degree)
            {
                return new Vector(f1.Angle, f1.Value + f2.Value);
            }

            if (f1.Value == 0)
                return new Vector(f2.Angle, f2.Value);

            var alpha = f1.Angle.Radian - f2.Angle.Radian;
            var resultingForce = Math.Sqrt(f1.Pow + f2.Pow + 2 * f1.Value * f2.Value * Math.Cos(alpha));
            var resultingAngle = Math.Acos((f1.Pow + Math.Pow(resultingForce, 2) - f2.Pow) / (2 * f1.Value * resultingForce)) *
                180 / Math.PI;

            if (f2.Angle.Degree - f1.Angle.Degree >= 180)
            {
                resultingAngle = f1.Angle.Degree - resultingAngle;
            }
            else
            {
                resultingAngle += f1.Angle.Degree;
            }

            if (resultingAngle >= 360)
            {
                resultingAngle -= 360;
            }

            if (resultingAngle < 0)
            {
                resultingAngle += 360;
            }

            var angle = Angle.FromDegrees(resultingForce == 0 ? 0 : resultingAngle);

            if (Double.IsNaN(angle.Degree))
            {
                var test = "FUCK";
            }

            return new Vector(angle, resultingForce);
        }
    }
}
