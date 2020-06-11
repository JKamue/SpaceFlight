using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Acceleration : Vector
    {
        public Acceleration(Angle angle, double mPerSecSquared) : base(angle, mPerSecSquared) {}

        public Speed GetSpeed(TimeSpan span) => new Speed(Angle, Value * span.TotalSeconds);

        public static Acceleration operator +(Acceleration acc1, Acceleration acc2) => (Acceleration) (acc1 + acc2);
    }
}
