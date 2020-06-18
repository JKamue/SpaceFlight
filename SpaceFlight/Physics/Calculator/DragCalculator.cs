using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    public class DragCalculator
    {
        public static Force CalculateDrag(Angle dragAngle, double cd, double p, Speed speed, double area)
        {
            var force = cd * 0.5 * p * Math.Pow(speed.Value, 2) * area;

            return new Force(dragAngle, force);
        }
    }
}
