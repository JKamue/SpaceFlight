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
        private int height;
        private IRocketSprite sprite;

        public Rocket(PointF position, float speedX, float speedY, float angle, int height, IRocketSprite sprite)
        {
            this.position = position;
            this.speedX = speedX;
            this.speedY = speedY;
            this.angle = angle;
            this.height = height;
            this.sprite = sprite;

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
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 1;

            var upperPoint = new PointF(position.X, position.Y + height / 2);
            var lowerPoint = new PointF(position.X, position.Y - height / 2);

            g.DrawPolygon(pen, ProjectPointList(sprite.GetPointList(position, height), ppCalc).ToArray());
        }

        private List<Point> ProjectPointList(List<PointF> points, IProjectionCalculator ppCalc)
        {
            var projected = new List<Point>();
            foreach (PointF p in points)
            {
                projected.Add(ppCalc.ProjectPoint(p));
            }
            return projected;
        }

        public RectangleF GetBounds() => sprite.GetBounds(position, height);

        public PointF GetMiddle() => position;
    }
}
