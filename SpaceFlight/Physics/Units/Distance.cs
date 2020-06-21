using System;

namespace SpaceFlight.Physics.Units
{
    public class Distance : Vector
    {
        public Distance() : base() { }
        public Distance (Angle angle, double meter) : base(angle, meter) { }
        public Distance (Vector v) : base(v.Angle, v.Value) { }

        public static Distance operator +(Distance acc1, Distance acc2) => new Distance((Vector)acc1 + (Vector)acc2);

        public DistanceXAndY CalculateXAndY()
        {
            var distY = Math.Cos(Angle.Radian) * Value;
            var distX = Math.Sin(Angle.Radian) * Value;

            return new DistanceXAndY(distX, distY);
        }
    }

    public readonly struct DistanceXAndY
    {
        public DistanceXAndY(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
}
