using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private RocketInformation rocketInf;
        private RocketSprite sprite;

        public Rocket(PointF position, float speedX, float speedY, float angle, float thrustPercentage, RocketInformation rocketInf)
        {
            this.position = position;
            this.speedX = speedX;
            this.speedY = speedY;
            this.angle = angle;
            this.rocketInf = rocketInf;
            this.thrustPercentage = thrustPercentage;
            sprite = rocketInf.GetRocketSprite();

            var t = new Timer();
            t.Interval = 10;
            t.Tick += CalculateVelocity;
            t.Enabled = true;
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
                sprite.CalculatePolygons(position, ppCalc, aCalc);

            foreach (RocketSpritePiece piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }

            DrawFlames(g, ppCalc, aCalc);
        }

        private void DrawFlames(Graphics g, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            foreach (var thrustArea in rocketInf.ThrustAreas)
            {
                var width = (thrustArea.Stop.X - Math.Abs(thrustArea.Start.X));

                var points = new List<PointF>();

                var startPoint = new PointF(position.X + thrustArea.Start.X, position.Y + thrustArea.Stop.Y);
                var endPoint = new PointF(position.X + thrustArea.Stop.X, position.Y + thrustArea.Stop.Y);
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

        public RectangleF GetBounds() => sprite.GetBounds(position, new AngularCalculator(angle, position));

        public PointF GetMiddle() => position;

        public int GetPriority() => 7;
    }
}
