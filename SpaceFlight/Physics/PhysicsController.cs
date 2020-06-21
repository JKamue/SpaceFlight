using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{
    class PhysicsController
    {
        private List<PhysicsObject> movingObjects;
        private List<PhysicsObject> gravityObjects;

        private readonly Timer _physTimer = new Timer();
        private readonly Label _distanceDebug;

        public PhysicsController(int msPerTick, Label distanceDebug)
        {
            _distanceDebug = distanceDebug;

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
                    var labelText = force.Value / movingObject.Mass.Value + "\n" + (distance - gravityObject.Diameter);
                    movingObject.ExternalForces.Add(force);

                    var altitude = distance - gravityObject.Diameter;
                    if (altitude < 100000)
                    {
                        // Drag Relevant
                        var rocketForceAngle = movingObject.OwnForce.Angle;
                        var dragAngle = Angle.FromDegrees(rocketForceAngle.Degree + 180);
                        var cd = movingObject.Drag.GetDragCoefficient(rocketForceAngle);
                        var a = movingObject.Drag.GetArea(rocketForceAngle);
                        var p = AtmosphereCalculator.CalculateAirDensityAtAltitude(altitude);
                        var dragForce = DragCalculator.CalculateDrag(dragAngle, cd, p, movingObject.Speed, a);
                        movingObject.ExternalForces.Add(dragForce);
                        labelText += "\n" + dragForce.Value;
                    }
                    _distanceDebug.Text = labelText;
                }
                movingObject.Tick();
            }
        }
    }
}
