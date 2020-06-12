using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{
    public class PhysicsObject
    {
        public PointF Location;
        public Mass Mass;
        public Force Force;
        public Acceleration Acceleration;
        public Speed Speed;

        private DateTime _lastRecalculation;

        public PhysicsObject(PointF location, Mass mass, Force force, Acceleration acceleration, Speed speed)
        {
            Location = location;
            Mass = mass;
            Force = force;
            Acceleration = acceleration;
            Speed = speed;

            _lastRecalculation = DateTime.Now;
            Add(Force.GetAcceleration(Mass));
        }

        public void Add(Force f) => Force += f;
        public void Add(Acceleration a) => Acceleration += a;
        public void Add(Speed s) => Speed += s;

        public void Recalculate()
        {
            var timeSpan = DateTime.Now - _lastRecalculation;
            _lastRecalculation = DateTime.Now;
            Add(Acceleration.GetSpeed(timeSpan));
            var distance = Speed.GetDistance(timeSpan).CalculateXAndY();
            Location.X += (float) distance.X;
            Location.Y += (float) distance.Y;
        }
    }
}
