using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{

    public class Force
    {
        public Angle Angle { get; }
        private double _force;

        public Force(Angle angle, double newton)
        {
            Angle = angle;
            _force = newton;
        }

        public static Force operator +(Force f1, Force f2)
        {
            if (f1.Deg > f2.Deg)
            {
                var t = f1;
                f1 = f2;
                f2 = t;
            }

            if (f1.Val == 0)
                return new Force(f2.Angle, f2.Val);

            var alpha = f1.Rad - f2.Rad;
            var resultingForce = Math.Sqrt(f1.Pow + f2.Pow + 2 * f1.Val * f2.Val * Math.Cos(alpha));
            var resultingAngle = Math.Acos((f1.Pow + Math.Pow(resultingForce, 2) - f2.Pow) / (2 * f1.Val * resultingForce)) *
                180 / Math.PI;

            if (f2.Deg - f1.Deg >= 180)
            {
                resultingAngle = f1.Deg - resultingAngle;
            }
            else
            {
                resultingAngle += f1.Deg;
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

            return new Force(angle, resultingForce);
        }

        
        public double Pow => Math.Pow(_force, 2);
        public double Val => _force;
        public double Rad => Angle.Radian;
        public double Deg => Angle.Degree;
    }

}
