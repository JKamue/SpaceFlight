using System;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Other
{
    public class DragProperties
    {
        public readonly decimal CdUp;
        public readonly decimal CdSide;
        public readonly decimal AreaUp;
        public readonly decimal AreaSide;

        public DragProperties(decimal CdUp, decimal CdSide, decimal AreaUp, decimal AreaSide)
        {
            this.CdUp = CdUp;
            this.CdSide = CdSide;
            this.AreaUp = AreaUp;
            this.AreaSide = AreaSide;
        }

        private static decimal MapAngle(Angle a) => (decimal) Math.Cos(2 * a.Radian);

        private static decimal Map(decimal value, decimal from1, decimal to1, decimal from2, decimal to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public decimal GetArea(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, AreaUp, AreaSide);
        }

        public decimal GetDragCoefficient(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, CdUp, CdSide);
        }
    }
}
