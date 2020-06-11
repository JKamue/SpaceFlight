using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Physics.Units
{
    public class Distance : Vector
    {
        public Distance (Angle angle, double meter) : base(angle, meter) { }
    }
}
