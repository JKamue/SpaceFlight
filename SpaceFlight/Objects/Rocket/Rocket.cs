using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using SpaceFlight.Objects.Rocket.Sprites;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Other;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Rocket
{
    class Rocket : PhysicsObject, IScreenObject
    {
        public Angle _angle { get; private set; }

        public Angle targetAngle;

        public float _thrustPercentage { get; private set; }
        public float _restFuelWeight { get; private set; }
        public bool _engineRunning { get; private set; }

        public TimeSpan LiftOffTime = TimeKeeper.Now();

        private readonly RocketSprite _sprite;

        public readonly string _name;
        public readonly RocketInformation _rocketInf;

        private TimeSpan lastCheck;

        public static Rocket getEmptyRocket()
        {
            var angle = Angle.Zero;
            return new Rocket(new PointF(0,0), new Force(angle, 0), new Acceleration(angle, 0), new Speed(angle, 0), angle, 0, RocketInformation.LoadFromName("empty-rocket"));
        }

        public Rocket(PointF location, Force force, Acceleration acceleration, Speed speed,
            Angle angle, float thrustPercentage, RocketInformation rocketInf) : base(location, new Mass(rocketInf.Weight), force, acceleration, speed, rocketInf.DragProperties)
        {
            _angle = angle;
            targetAngle = angle;
            _rocketInf = rocketInf;
            _thrustPercentage = thrustPercentage;
            _restFuelWeight = rocketInf.FuelWeight;
            _sprite = rocketInf.GetRocketSprite();
            _engineRunning = true;

            lastCheck = TimeKeeper.Now();

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
            NearAngleToTargetAngle();
            if (!_engineRunning)
                return;

            var burnedFuelPerSec = _rocketInf.FuelWeight / _rocketInf.BurnTime;
            var span = TimeKeeper.Now() - lastCheck;
            var ms = span.TotalMilliseconds;
            var burnedFuel = (ms / 1000) * burnedFuelPerSec * _thrustPercentage;
            lastCheck = TimeKeeper.Now();

            _restFuelWeight -= (_restFuelWeight - burnedFuel <= 0) ? _restFuelWeight : (float) burnedFuel;

            if (_restFuelWeight <= 0)
                _engineRunning = false;

            OwnForce = _engineRunning ? new Force(_angle, _rocketInf.Thrust * _thrustPercentage) : new Force(Angle.Zero, 0);

            Mass = new Mass(_restFuelWeight + _rocketInf.Weight - _rocketInf.FuelWeight);
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen)
        {
            var aCalc = new AngularCalculator((float) _angle.Degree * -1, Location);
            var spritePieces =
                _sprite.CalculatePolygons(Location, ppCalc, aCalc);

            foreach (var piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }
            
            if (_engineRunning)
                DrawFlames(g, ppCalc, aCalc);
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

        public void NearAngleToTargetAngle()
        {
            var target = targetAngle.Degree - (targetAngle.Degree > 180 ? 360 : 0);
            var angle = _angle.Degree - (_angle.Degree > 180 ? 360 : 0);

            var factor = 0.6 * TimeKeeper.TimeConstant;

            if (angle - factor >= target)
                _angle = new Angle(_angle.Degree - factor);
            else if (angle + factor <= target)
                _angle = new Angle(_angle.Degree + factor);
            else
                _angle = targetAngle;
        }

        public override string ToString()
        {
            return _name + " - " + _rocketInf.Model + " " + _rocketInf.Variant;
        }

        public RectangleF GetBounds() => _sprite.GetBounds(Location, new AngularCalculator((float)_angle.Degree * -1, Location));

        public List<PointF> GetBoundPointsList() => _sprite.GetBoundPointsList(Location, new AngularCalculator((float)_angle.Degree * -1, Location));

        public PointF GetMiddle() => Location;

        public int GetPriority() => 7;

        public void ChangeAngle(float change) => _angle = Angle.FromDegrees(_angle.Degree + change);

        public void SetThrustPercentage(float i) => _thrustPercentage = i;
    }
}
