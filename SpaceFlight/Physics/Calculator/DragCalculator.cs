using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    class DragCalculator
    {
        public static Force CalculateDrag(Angle resultingForce, double Cd, double p, Speed speed, double area)
        {
            var angle = Angle.FromDegrees(resultingForce.Degree + 180);
            var force = Cd * 0.5 * p * Math.Pow(speed.Value, 2) * area;

            return new Force(angle, force);
        }
    }
}
