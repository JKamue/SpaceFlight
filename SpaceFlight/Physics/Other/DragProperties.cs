using System;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Other
{
    public class DragProperties
    {
        public readonly double CdUp;
        public readonly double CdSide;
        public readonly double AreaUp;
        public readonly double AreaSide;

        public DragProperties(double CdUp, double CdSide, double AreaUp, double AreaSide)
        {
            this.CdUp = CdUp;
            this.CdSide = CdSide;
            this.AreaUp = AreaUp;
            this.AreaSide = AreaSide;
        }

        private static double MapAngle(Angle a) => Math.Cos(2 * a.Radian);

        private static double Map(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public double GetArea(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, AreaUp, AreaSide);
        }

        public double GetDragCoefficient(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, CdUp, CdSide);
        }
    }
}
