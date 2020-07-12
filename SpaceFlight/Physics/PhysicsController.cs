using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SpaceFlight.Objects;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics
{
    class PhysicsController
    {
        private readonly ScreenObjectCollection _objects;

        private readonly Timer _physTimer = new Timer();

        public PhysicsController(ScreenObjectCollection objects, int msPerTick)
        {

            _physTimer.Interval = msPerTick;
            _physTimer.Tick += Tick;
            _physTimer.Start();

            _objects = objects;
        }

        public void Tick(object s, EventArgs e)
        {
            foreach (var movingObject in _objects.Rockets)
            {
                movingObject.DragForces = new List<Force>();
                movingObject.GravityForces = new List<Force>();

                foreach (var gravityObject in _objects.Terrains)
                {
                    var distance = PointCalculator.Distance(movingObject.Location, gravityObject.Location);
                    var angle = PointCalculator.CalculateAngle(movingObject.Location, gravityObject.Location);
                    var force = GravityCalculator.CalculateGravity(movingObject.Mass, gravityObject.Mass, distance, angle);
                    movingObject.GravityForces.Add(force);

                    var altitude = distance - gravityObject.Diameter;
                    if (altitude < 100000)
                    {
                        // Drag Relevant
                        var rocketForceAngle = movingObject._angle;
                        var dragAngle = Angle.FromDegrees(movingObject.Speed.Angle.Degree + 180);
                        var speedDirectionDiff =
                            Angle.FromDegrees(rocketForceAngle.Degree - movingObject.Speed.Angle.Degree);
                        var cd = movingObject.Drag.GetDragCoefficient(speedDirectionDiff);
                        var a = movingObject.Drag.GetArea(speedDirectionDiff);
                        var p = AtmosphereCalculator.CalculateAirDensityAtAltitude(altitude);
                        var dragForce = DragCalculator.CalculateDrag(dragAngle, cd, p, movingObject.Speed, a);
                        movingObject.DragForces.Add(dragForce);
                    }
                }
                movingObject.Tick();
            }
        }
    }
}
