using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Other;

namespace SpaceFlight.Objects.Calculator
{
    class CollisionDetector
    {
        private readonly ScreenObjectCollection _objects;
        private readonly Timer _collisionChecker = new Timer();

        public CollisionDetector(ScreenObjectCollection objects)
        {
            _objects = objects;
            _collisionChecker.Interval = 100;
            _collisionChecker.Tick += CheckForCollisions;
            _collisionChecker.Enabled = true;
        }

        private void CheckForCollisions(object sender, EventArgs e)
        {
            var rockets = _objects.Rockets;
            for (int i = rockets.Count - 1; i >= 0; i--)
            {
                if (rockets.ElementAtOrDefault(i) == null)
                    return;

                var rocket = rockets[i];
                var corners = rocket.GetBoundPointsList();

                foreach (var planet in _objects.Terrains)
                {
                    if (RocketCollidedWithPlanet(planet, corners))
                    {
                        _objects.Remove(rocket);
                        DialogResult dialog = MessageBox.Show($@"{rocket.ToString()} collided with a planet at {Math.Round(rocket.Speed.Value,2)} m/s");
                        break;
                    }
                }
            }
        }

        private bool RocketCollidedWithPlanet(Terrain.Terrain planet, List<PointF> corners)
        {
            foreach (var corner in corners)
                if (PointCalculator.Distance(corner, planet.Location) < planet.Diameter)
                    return true;

            return false;
        }
    }
}
