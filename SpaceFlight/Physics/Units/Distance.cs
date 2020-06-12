using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Distance : Vector
    {
        public Distance (Angle angle, double meter) : base(angle, meter) { }

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
