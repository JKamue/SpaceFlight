using System;
using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Physics.Other;
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
        public DragProperties Drag;
        public double Diameter;
        public Force LastDrag;
        public Force LastGravity;

        private DateTime _lastRecalculation;

        public PhysicsObject(PointF location, Mass mass, double diameter)
        {
            Location = location;
            Mass = mass;
            OwnForce = new Force();
            Acceleration = new Acceleration();
            Speed = new Speed();
            Drag = new DragProperties(0,0,0,0);
            Diameter = diameter;
        }

        public PhysicsObject(PointF location, Mass mass, Force ownForce, Acceleration acceleration, Speed speed, DragProperties drag)
        {
            Location = location;
            Mass = mass;
            OwnForce = ownForce;
            Acceleration = acceleration;
            Speed = speed;
            ExternalForces = new List<Force>();
            Drag = drag;
            Diameter = 0;

            _lastRecalculation = DateTime.Now;
        }

        public virtual void Tick()
        {
            Recalculate();
        }

        public void Recalculate()
        {
            // Calculate resulting force
            var force = OwnForce;
            foreach (var exForce in ExternalForces)
            {
                force += exForce;
            }

            // Calculate Acceleration -> Speed -> Distance
            Acceleration = force.GetAcceleration(Mass);
            var timeSpan = DateTime.Now - _lastRecalculation;
            _lastRecalculation = DateTime.Now;
            Speed += Acceleration.GetSpeed(timeSpan);
            var distance = Speed.GetDistance(timeSpan).CalculateXAndY();

            // Move it
            Location.X += (float) distance.X;
            Location.Y += (float) distance.Y;
        }
    }
}
