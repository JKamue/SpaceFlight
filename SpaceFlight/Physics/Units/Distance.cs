using System;

namespace SpaceFlight.Physics.Units
{
    public class Distance : Vector
    {
        public Distance (Angle angle, decimal meter) : base(angle, meter) { }
        public Distance (Vector v) : base(v.Angle, v.Value) { }

        public static Distance operator +(Distance acc1, Distance acc2) => new Distance((Vector)acc1 + (Vector)acc2);

        public DistanceXAndY CalculateXAndY()
        {
            var distY = (decimal) Math.Cos(Angle.Radian) * Value;
            var distX = (decimal) Math.Sin(Angle.Radian) * Value;

            return new DistanceXAndY(distX, distY);
        }
    }

    public readonly struct DistanceXAndY
    {
        public DistanceXAndY(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public decimal X { get; }
        public decimal Y { get; }
    }
}
