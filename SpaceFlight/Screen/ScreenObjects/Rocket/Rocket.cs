using SpaceFlight.Screen.Calculator;
using System;
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

        public Rocket(PointF position, float speedX, float speedY, float angle, int height)
        {
            this.position = position;
            this.speedX = speedX;
            this.speedY = speedY;
            this.angle = angle;
            this.height = height;

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

            g.DrawLine(pen, ppCalc.ProjectPoint(upperPoint), ppCalc.ProjectPoint(lowerPoint));
        }

        public RectangleF GetBounds() => new RectangleF(position.X - 50, position.Y - height / 2, 100, height);

        public PointF GetMiddle() => position;
    }
}
