using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Physics.Units
{
    public class Speed : Vector
    {

        public Speed(Angle angle, double newton) : base(angle, newton) {}

        public static Speed operator +(Speed s1, Speed s2) => (Speed) (s1 + s2);

        public double GetDistance(TimeSpan span)
        {
            return Value * span.TotalSeconds;
        }
    }
}
