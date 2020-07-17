using System;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    class GravityCalculator
    {
        public static readonly decimal GravitationalConstant = 6.67330E-11m;

        public static Force CalculateGravity(Mass p1, Mass p2, double r, Angle angle) =>
            new Force(angle, GravitationalConstant * (p1.Value * p2.Value) / (decimal) Math.Pow(r, 2));
    }
}
