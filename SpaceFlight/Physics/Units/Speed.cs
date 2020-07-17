using System;

namespace SpaceFlight.Physics.Units
{
    public class Speed : Vector
    {
        public Speed(Angle angle, decimal mPerSec) : base(angle, mPerSec) { }
        public Speed(Vector v) : base(v.Angle, v.Value) { }

        public static Speed operator +(Speed acc1, Speed acc2) => new Speed((Vector)acc1 + (Vector)acc2);

        public Distance GetDistance(TimeSpan span) => new Distance(Angle, Value * (decimal) span.TotalSeconds);
    }
}
