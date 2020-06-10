using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Mass
    {
        public double Value { get; }

        public Mass(double value)
        {
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
