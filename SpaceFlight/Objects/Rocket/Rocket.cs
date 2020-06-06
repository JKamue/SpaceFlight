using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using SpaceFlight.Objects.Rocket.Sprites;
using SpaceFlight.Screen;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight.Objects.Rocket
{
    class Rocket : IScreenObject
    {
        private PointF position;
        private float speedX;
        private float speedY;
        private float angle;
        private float thrustPercentage;
        private float restFuelWeight;
        private bool engineRunning;

        private readonly RocketInformation _rocketInf;
        private readonly RocketSprite _sprite;

        private DateTime lastCheck;
        private readonly Timer _checkTimer;

        public Rocket(PointF position, float speedX, float speedY, float angle, float thrustPercentage, RocketInformation rocketInf)
        {
            this.position = position;
            this.speedX = speedX;
            this.speedY = speedY;
            this.angle = angle;
            this._rocketInf = rocketInf;
            this.thrustPercentage = thrustPercentage;
            restFuelWeight = rocketInf.FuelWeight;
            _sprite = rocketInf.GetRocketSprite();
            engineRunning = true;

            lastCheck = DateTime.Now;

            _checkTimer = new Timer();
            _checkTimer.Interval = 10;
            _checkTimer.Tick += CalculateVelocity;
            _checkTimer.Tick += CalculateFuelUsage;
            _checkTimer.Enabled = true;
        }

        private void CalculateFuelUsage(object sender, EventArgs e)
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
        }

        private void CalculateVelocity(object sender, EventArgs e)
        {
            position.X += speedX;
            position.Y += speedY;
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen)
        {
            var aCalc = new AngularCalculator(angle, position);
            var spritePieces =
                _sprite.CalculatePolygons(position, ppCalc, aCalc);

            foreach (RocketSpritePiece piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }

            if (engineRunning)
                DrawFlames(g, ppCalc, aCalc);
        }

        private void DrawFlames(Graphics g, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            foreach (var thrustArea in _rocketInf.ThrustAreas)
            {
                var width = (thrustArea.Stop.X - Math.Abs(thrustArea.Start.X));

                var points = new List<PointF>();

                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(position.X + thrustArea.Start.X, position.Y + thrustArea.Stop.Y))));
                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(position.X + thrustArea.Stop.X, position.Y + thrustArea.Stop.Y))));
                points.Add(ppCalc.ProjectPoint(aCalc.Turn(new PointF(position.X + width / 2, position.Y + thrustArea.Stop.Y - Math.Abs(thrustArea.Stop.X - thrustArea.Start.X) * thrustPercentage * (float) GetRandomNumber(3.5,6)))));


                g.FillPolygon(new SolidBrush(Color.OrangeRed), points.ToArray());
            }
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public RectangleF GetBounds() => _sprite.GetBounds(position, new AngularCalculator(angle, position));

        public PointF GetMiddle() => position;

        public int GetPriority() => 7;
    }
}
