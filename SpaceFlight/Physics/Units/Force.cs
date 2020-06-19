using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{

    public class Force : Vector
    {
        public Force() : base() { }
        public Force(Angle angle, double newton) : base(angle, newton) { }
        public Force(Vector v) : base(v.Angle, v.Value) { }

        public Acceleration GetAcceleration(Mass mass) => new Acceleration(Angle,Value / mass.Value);
        
        public Mass GetMass(Acceleration ac) => new Mass(Value / ac.Value);

        public static Force operator +(Force acc1, Force acc2) => new Force((Vector)acc1 + (Vector)acc2);
    }

}
