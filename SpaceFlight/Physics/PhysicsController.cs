using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Physics.Calculator;

namespace SpaceFlight.Physics
{
    class PhysicsController
    {
        private List<PhysicsObject> movingObjects;
        private List<PhysicsObject> gravityObjects;

        private readonly Timer _physTimer;
        private readonly Label _distanceDebug;

        public PhysicsController(int msPerTick, Label distanceDebug)
        {
            _distanceDebug = distanceDebug;

            _physTimer = new Timer();
            _physTimer.Interval = msPerTick;
            _physTimer.Tick += Tick;
            _physTimer.Start();

            movingObjects = new List<PhysicsObject>();
            gravityObjects = new List<PhysicsObject>();
        }

        public void AddMovingObject(PhysicsObject ob) => movingObjects.Add(ob);

        public void AddGravityObject(PhysicsObject ob) => gravityObjects.Add(ob);

        public void Tick(object s, EventArgs e)
        {
            foreach (var movingObject in movingObjects)
            {
                movingObject.ExternalForces = new List<Force>();
                foreach (var gravityObject in gravityObjects)
                {
                    var distance = PointCalculator.Distance(movingObject.Location, gravityObject.Location);
                    var angle = PointCalculator.CalculateAngle(movingObject.Location, gravityObject.Location);
                    var force = GravityCalculator.CalculateGravity(movingObject.Mass, gravityObject.Mass, distance, angle);
                    _distanceDebug.Text = force.Value / movingObject.Mass.Value + "\n" + (distance - 6371000);
                    movingObject.ExternalForces.Add(force);
                }
                movingObject.Tick();
            }
        }
    }
}
