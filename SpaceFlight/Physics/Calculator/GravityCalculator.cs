using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    class GravityCalculator
    {
        public static readonly double GravitationalConstant = 6.67330E-11;

        public static Force CalculateGravity(Mass p1, Mass p2, double r, Angle angle) =>
            new Force(angle, GravitationalConstant * (p1.Value * p2.Value) / Math.Pow(r, 2));
    }
}
