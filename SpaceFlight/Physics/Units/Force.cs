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
        public Force(Angle angle, double newton) : base(angle, newton) {}

        public Acceleration GetAcceleration(Mass mass) => new Acceleration(Angle,Value / mass.Value);
        
        public Mass GetMass(Acceleration ac) => new Mass(Value / ac.Value);
    
        public static Force operator +(Force f1, Force f2) => (Force)(f1 + f2);
    }

}
