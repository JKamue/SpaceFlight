using System;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    public class DragCalculator
    {
        public static Force CalculateDrag(Angle dragAngle, decimal cd, decimal p, Speed speed, decimal area)
        {
            var force = cd * 0.5m * p * (decimal) Math.Pow((double) speed.Value, 2) * area;

            return new Force(dragAngle, force);
        }
    }
}
