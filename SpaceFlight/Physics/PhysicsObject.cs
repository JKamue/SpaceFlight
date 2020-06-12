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
        public Force OwnForce;
        public List<Force> ExternalForces;
        public Acceleration Acceleration;
        public Speed Speed;

        private DateTime _lastRecalculation;

        public PhysicsObject(PointF location, Mass mass, Force ownForce, Acceleration acceleration, Speed speed)
        {
            Location = location;
            Mass = mass;
            OwnForce = ownForce;
            Acceleration = acceleration;
            Speed = speed;
            ExternalForces = new List<Force>();

            _lastRecalculation = DateTime.Now;
        }

        public void Add(Force f) => OwnForce += f;
        public void Add(Speed s) => Speed += s;

        public void Tick()
        {
            Recalculate();
        }

        public void Recalculate()
        {
            var force = OwnForce;
            foreach (var exForce in ExternalForces)
            {
                force += exForce;
            }

            Acceleration = force.GetAcceleration(Mass);

            var timeSpan = DateTime.Now - _lastRecalculation;
            _lastRecalculation = DateTime.Now;
            Add(Acceleration.GetSpeed(timeSpan));
            var distance = Speed.GetDistance(timeSpan).CalculateXAndY();
            Location.X += (float) distance.X;
            Location.Y += (float) distance.Y;
        }
    }
}
