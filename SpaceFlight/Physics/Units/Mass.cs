using System;

namespace SpaceFlight.Physics.Units
{
    public class Mass
    {
        public double Value { get; }
        public Mass() : base() { }
        public Mass(double value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Mass must be positive and bigger than zero");

            Value = value;
        }

        public static Mass operator +(Mass m1, Mass m2)
        {
            return new Mass(m1.Value + m2.Value);
        }

        public static Mass operator -(Mass m1, Mass m2)
        {
            return new Mass(m1.Value - m2.Value);
        }
    }
}
