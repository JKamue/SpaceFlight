using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Objects.Rocket.Sprites;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight.Objects.Rocket
{
    class Rocket : PhysicsObject, IScreenObject
    {
        private Angle angle;
        private float thrustPercentage;
        private float restFuelWeight;
        private bool engineRunning;

        private readonly string _name;
        private readonly RocketInformation _rocketInf;
        private readonly RocketSprite _sprite;

        private DateTime lastCheck;
        private readonly Timer _checkTimer;

        public Rocket(PointF location, Mass mass, Force force, Acceleration acceleration, Speed speed,
            Angle angle, float thrustPercentage, RocketInformation rocketInf) : base(location, mass, force, acceleration, speed)
        {
            this.angle = angle;
            this._rocketInf = rocketInf;
            this.thrustPercentage = thrustPercentage;
            restFuelWeight = rocketInf.FuelWeight;
            _sprite = rocketInf.GetRocketSprite();
            engineRunning = true;

            lastCheck = DateTime.Now;

            var rnd = new Random();
            int r = rnd.Next(rocketInf.Names.Count);
            this._name = rocketInf.Names[r];
        }

        public override void Tick()
        {
            CalculateFuelUsage();
            Recalculate();
        }

        private void CalculateFuelUsage()
        {
            if (!engineRunning)
                return;

            var burnedFuelPerSec = _rocketInf.FuelWeight / _rocketInf.BurnTime;
            TimeSpan span = DateTime.Now - lastCheck;
            var ms = span.TotalMilliseconds;
            var burnedFuel = (ms / 1000) * burnedFuelPerSec * thrustPercentage;
            lastCheck = DateTime.Now;

            restFuelWeight -= (restFuelWeight - burnedFuel <= 0) ? restFuelWeight : (float) burnedFuel;

            if (restFuelWeight <= 0)
                engineRunning = false;

            if (engineRunning)
            {
                OwnForce = new Force(angle, _rocketInf.Thrust * thrustPercentage);
            }
            else
            {
                OwnForce = new Force(Angle.FromDegrees(0), 0);
            }

            Mass = new Mass(restFuelWeight + _rocketInf.Weight - _rocketInf.FuelWeight);
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen, bool showStats)
        {
            var aCalc = new AngularCalculator((float) angle.Degree * -1, Location);
            var spritePieces =
                _sprite.CalculatePolygons(Location, ppCalc, aCalc);

            foreach (RocketSpritePiece piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }

            if (showStats)
                DrawStats(g, ppCalc);
            
            if (engineRunning)
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
            g.DrawString((restFuelWeight /_rocketInf.FuelWeight * 100).ToString() + "% Fuel", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 2.5F;
            g.DrawString((restFuelWeight + _rocketInf.Weight - _rocketInf.FuelWeight).ToString() + "kg", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 7.5F;
            g.DrawString(((Acceleration.Value)).ToString() + "m/s^2", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
            point.Y = y - 12.5F;
            g.DrawString(((Speed.Value)).ToString() + "m/s", new Font("Arial", 10), new SolidBrush(Color.Black), ppCalc.ProjectPoint(point));
        }

        private void DrawFlames(Graphics g, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            foreach (var thrustArea in _rocketInf.ThrustAreas)
            {
                var width = (thrustArea.Stop.X - Math.Abs(thrustArea.Start.X));

                var points = new List<PointF>();

                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + thrustArea.Start.X, Location.Y + thrustArea.Stop.Y))));
                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + thrustArea.Stop.X, Location.Y + thrustArea.Stop.Y))));
                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(Location.X + width / 2, Location.Y + thrustArea.Stop.Y - Math.Abs(thrustArea.Stop.X - thrustArea.Start.X) * thrustPercentage * (float) GetRandomNumber(3.5,6)))));


                g.FillPolygon(new SolidBrush(Color.OrangeRed), points.ToArray());
            }
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public RectangleF GetBounds() => _sprite.GetBounds(Location, new AngularCalculator((float)angle.Degree * -1, Location));

        public PointF GetMiddle() => Location;

        public int GetPriority() => 7;
    }
}
