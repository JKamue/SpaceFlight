using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceFlight.Physics
{

    class Force
    {
        private double DirectionAngle;
        private double Newton;

        public Force(double directionAngle, double newton)
        {
            DirectionAngle = directionAngle * Math.PI / 180;
            Newton = newton;
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
            {
                return f2;
            }

            var alpha = f1.Rad - f2.Rad;
            var resultingForce = Math.Sqrt(f1.Pow + f2.Pow + 2 * f1.Val * f2.Val * Math.Cos(alpha));
            var resultingAngle = Math.Acos((f1.Pow + Math.Pow(resultingForce, 2) - f2.Pow) / (2 * f1.Val * resultingForce)) *
                180 / Math.PI;


            Console.WriteLine(resultingAngle);

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


            if (resultingForce == 0)
                return new Force(0, 0);

            return new Force(resultingAngle, resultingForce);
        }

        public double Pow => Math.Pow(Newton, 2);
        public double Val => Newton;
        public double Rad => DirectionAngle;
        public double Deg => DirectionAngle * 180 / Math.PI;
    }

}
