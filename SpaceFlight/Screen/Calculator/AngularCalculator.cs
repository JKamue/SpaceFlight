using System;
using System.Drawing;

namespace SpaceFlight.Screen.Calculator
{
    class AngularCalculator
    {
        private readonly double _angle;
        private readonly PointM _center;

        public AngularCalculator(decimal angle, PointM center)
        {
            _angle = (double) angle * Math.PI / 180;
            _center = center;
        }

        // Changed code from Fraser Chapman: https://stackoverflow.com/a/13695630
        public PointM Turn(PointM p)
        {
            var cosTheta = (decimal) Math.Cos(_angle);
            var sinTheta = (decimal) Math.Sin(_angle);
            return new PointM(
                (cosTheta * (p.X - _center.X) -
                sinTheta * (p.Y - _center.Y) + _center.X),
                (sinTheta * (p.X - _center.X) +
                cosTheta * (p.Y - _center.Y) + _center.Y)
           );
        }
    }
}
