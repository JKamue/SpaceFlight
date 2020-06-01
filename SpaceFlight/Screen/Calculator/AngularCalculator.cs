using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    class AngularCalculator
    {
        private readonly float _angle;
        private readonly PointF _center;

        public AngularCalculator(float angle, PointF center)
        {
            _angle = angle;
            _center = center;
        }

        // Changed code from Fraser Chapman: https://stackoverflow.com/a/13695630
        public PointF Turn(PointF p)
        {
            double cosTheta = Math.Cos(_angle);
            double sinTheta = Math.Sin(_angle);
            return new PointF(
                (float)
                (cosTheta * (p.X - _center.X) -
                sinTheta * (p.Y - _center.Y) + _center.X),
                (float)
                (sinTheta * (p.X - _center.X) +
                cosTheta * (p.Y - _center.Y) + _center.Y)
           );
        }
    }
}
