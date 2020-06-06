using SpaceFlight.Screen.Calculator;
using SpaceFlight.Screen.ScreenObjects.Rocket.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight.Screen.ScreenObjects.Rocket
{
    class Rocket : IScreenObject
    {
        private PointF position;
        private float speedX;
        private float speedY;
        private float angle;
        private RocketInformation rocketInf;
        private RocketSprite sprite;

        public Rocket(PointF position, float speedX, float speedY, float angle, RocketInformation rocketInf)
        {
            this.position = position;
            this.speedX = speedX;
            this.speedY = speedY;
            this.angle = angle;
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

        public void Draw(Graphics g, IProjectionCalculator ppCalc, RectangleF screen)
        {
            var spritePieces =
                sprite.CalculatePolygons(position, ppCalc, new AngularCalculator(angle, position));

            foreach (RocketSpritePiece piece in spritePieces)
            {
                g.FillPolygon(piece.Brush, piece.Points.ToArray());
            }
        }

        public RectangleF GetBounds() => sprite.GetBounds(position, new AngularCalculator(angle, position));

        public PointF GetMiddle() => position;
    }
}
