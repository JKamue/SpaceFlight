using System;

namespace SpaceFlight.Physics.Units
{
    public class Acceleration : Vector
    {

        public Acceleration(Angle angle, decimal mPerSecSquared) : base(angle, mPerSecSquared) {}

        public Acceleration(Vector v) : base(v.Angle, v.Value) {}

        public Speed GetSpeed(TimeSpan span) => new Speed(Angle, Value * (decimal) span.TotalSeconds);

        public static Acceleration operator +(Acceleration acc1, Acceleration acc2) => new Acceleration((Vector)acc1 + (Vector)acc2);
    }
}
