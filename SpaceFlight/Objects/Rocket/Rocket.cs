using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Objects.Rocket.Sprites;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Rocket
{
    class Rocket : PhysicsObject, IScreenObject
    {
        private Angle _angle;
        private float _thrustPercentage;
        private float _restFuelWeight;
        private bool _engineRunning;

        private readonly string _name;
        private readonly RocketInformation _rocketInf;
        private readonly RocketSprite _sprite;

        private DateTime lastCheck;

        public Rocket(PointF location, Force force, Acceleration acceleration, Speed speed,
            Angle angle, float thrustPercentage, RocketInformation rocketInf) : base(location, new Mass(rocketInf.Weight), force, acceleration, speed, rocketInf.DragProperties)
        {
            _angle = angle;
            _rocketInf = rocketInf;
            _thrustPercentage = thrustPercentage;
            _restFuelWeight = rocketInf.FuelWeight;
            _sprite = rocketInf.GetRocketSprite();
            _engineRunning = true;

            lastCheck = DateTime.Now;

            var rnd = new Random();
            var r = rnd.Next(rocketInf.Names.Count);
            _name = rocketInf.Names[r];
        }

        public override void Tick()
        {
            CalculateFuelUsage();
            Recalculate();
        }

        private void CalculateFuelUsage()
        {
            if (!_engineRunning)
                return;

            var burnedFuelPerSec = _rocketInf.FuelWeight / _rocketInf.BurnTime;
            var span = DateTime.Now - lastCheck;
            var ms = span.TotalMilliseconds;
            var burnedFuel = (ms / 1000) * burnedFuelPerSec * _thrustPercentage;
            lastCheck = DateTime.Now;

            _restFuelWeight -= (_restFuelWeight - burnedFuel <= 0) ? _restFuelWeight : (float) burnedFuel;

            if (_restFuelWeight <= 0)
                _engineRunning = false;

            OwnForce = _engineRunning ? new Force(_angle, _rocketInf.Thrust * _thrustPercentage) : new Force();

            Mass = new Mass(_restFuelWeight + _rocketInf.Weight - _rocketInf.FuelWeight);
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen, bool showStats)
        {
            var aCalc = new AngularCalculator((float) _angle.Degree * -1, Location);
            var spritePieces =
                _sprite.CalculatePolygons(Location, ppCalc, aCalc);

            foreach (var piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }

            if (showStats)
                DrawStats(g, ppCalc);
            
            if (_engineRunning)
                DrawFlames(g, ppCalc, aCalc);
        }

        private void DrawStats(Graphics g, ProjectedPositionCalculator ppCalc)
        {
            var point = Location;
            var y = point.Y;
            point.X += 5;

            point.Y = y + 12.5F;
            g.DrawString( _rocketInf.Model + " " + _rocketInf.Variant, new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y + 7.5F;
            g.DrawString(_name + " " + _rocketInf.Manufacturer, new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y + 2.5F;
            g.DrawString((_restFuelWeight /_rocketInf.FuelWeight * 100) + "% Fuel", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 2.5F;
            g.DrawString((_restFuelWeight + _rocketInf.Weight - _rocketInf.FuelWeight) + "kg", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 7.5F;
            g.DrawString(((Acceleration.Value)) + "m/s^2", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 12.5F;
            g.DrawString(((Speed.Value)) + "m/s", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
        }

        private void DrawFlames(Graphics g, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            foreach (var thrustArea in _rocketInf.ThrustAreas)
            {
                var width = (thrustArea.Stop.X - Math.Abs(thrustArea.Start.X));

                var points = new List<PointF>
                {
                    ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + thrustArea.Start.X, Location.Y + thrustArea.Stop.Y))),
                    ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + thrustArea.Stop.X, Location.Y + thrustArea.Stop.Y))),
                    ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + width / 2, Location.Y + thrustArea.Stop.Y - Math.Abs(thrustArea.Stop.X - thrustArea.Start.X) * _thrustPercentage * (float)GetRandomNumber(3.5, 6))))
                };


                g.FillPolygon(new SolidBrush(Color.OrangeRed), points.ToArray());
            }
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public RectangleF GetBounds() => _sprite.GetBounds(Location, new AngularCalculator((float)_angle.Degree * -1, Location));

        public PointF GetMiddle() => Location;

        public int GetPriority() => 7;

        public void ChangeAngle(float change) => _angle = Angle.FromDegrees(_angle.Degree + change);
    }
}
