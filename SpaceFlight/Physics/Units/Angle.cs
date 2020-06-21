using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Angle
    {
        public static Angle Zero => new Angle(0);
        public static Angle FromDegrees(double degrees) => new Angle(degrees);
        public static Angle FromRadian(double radian) => new Angle(RadToDegree(radian));


        public double Degree { get; }
        public double Radian => DegToRad(Degree);

        public Angle(double degree)
        {
            Degree = AngleToRightRange(degree);
        }

        private static double AngleToRightRange(double angle)
        {
            var times = Math.Floor(angle / 360);
            angle -= times * 360;

            if (angle < 0)
                angle += 360;

            return angle;
        }
        private static double DegToRad(double degree) => degree * Math.PI / 180;
        private static double RadToDegree(double degree) => degree * 180 / Math.PI;
    }
}
