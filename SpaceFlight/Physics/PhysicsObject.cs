using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{
    class PhysicsObject
    {
        public PointF Location;
        public Mass Mass;
        public Angle DirectionAngle;
        public Force Force;
        public Acceleration Acceleration;
        public Speed Speed;
    }
}
