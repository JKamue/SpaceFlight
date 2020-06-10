using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Acceleration
    {
        public double Value { get; }

        public Acceleration(double value)
        {
            Value = value;
        }

        public Speed GetSpeed(TimeSpan span) => new Speed(Value * span.TotalSeconds);

        public static Acceleration operator +(Acceleration acc1, Acceleration acc2)
        {
            return new Acceleration(acc1.Value + acc2.Value);
        }
        public static Acceleration operator -(Acceleration acc1, Acceleration acc2)
        {
            return new Acceleration(acc1.Value - acc2.Value);
        }
    }
}
