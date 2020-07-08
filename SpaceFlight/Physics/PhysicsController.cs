using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{
    class PhysicsController
    {
        private List<PhysicsObject> movingObjects;
        private List<PhysicsObject> gravityObjects;

        private readonly Timer _physTimer = new Timer();

        public PhysicsController(int msPerTick)
        {

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
                    movingObject.ExternalForces.Add(force);
                    // TODO: Calculate largest of multiple gravities
                    movingObject.LastGravity = force;

                    var altitude = distance - gravityObject.Diameter;
                    if (altitude < 100000)
                    {
                        // Drag Relevant
                        var rocketForceAngle = ((Rocket)movingObject)._angle;
                        var dragAngle = Angle.FromDegrees(rocketForceAngle.Degree + 180);
                        var speedDirectionDiff =
                            Angle.FromDegrees(rocketForceAngle.Degree - movingObject.Speed.Angle.Degree);
                        var cd = movingObject.Drag.GetDragCoefficient(speedDirectionDiff);
                        var a = movingObject.Drag.GetArea(speedDirectionDiff);
                        var p = AtmosphereCalculator.CalculateAirDensityAtAltitude(altitude);
                        var dragForce = DragCalculator.CalculateDrag(dragAngle, cd, p, movingObject.Speed, a);
                        movingObject.ExternalForces.Add(dragForce);
                        movingObject.LastDrag = dragForce;
                    }
                    else
                    {
                        movingObject.LastDrag = new Force(Angle.Zero, 0);
                    }
                }
                movingObject.Tick();
            }
        }
    }
}
