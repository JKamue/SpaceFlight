using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Physics.Units
{
    public class Speed
    {
        public double Value { get; }

        public Speed(double value)
        {
            Value = value;
        }

        public static Speed operator +(Speed s1, Speed s2)
        {
            return new Speed(s1.Value + s2.Value);
        }

        public static Speed operator -(Speed s1, Speed s2)
        {
            return new Speed(s1.Value - s2.Value);
        }

        public double GetDistance(TimeSpan span)
        {
            return Value * span.TotalSeconds;
        }
    }
}
