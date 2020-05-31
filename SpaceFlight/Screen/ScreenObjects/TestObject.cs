using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight.Screen.ScreenObjects
{
    class TestObject : IScreenObject
    {
        private PointF start;
        private PointF end;
        private float SpeedX;
        private float SpeedY;

        public TestObject(PointF start, PointF end, float speedX, float speedY)
        {
            this.start = start;
            this.end = end;
            SpeedX = speedX;
            SpeedY = speedY;

            var t = new Timer();
            t.Interval = 10;
            t.Tick += MoveRight;
            t.Enabled = true;
        }

        private void MoveRight(object sender, EventArgs e)
        {
            start.X += SpeedX;
            start.Y += SpeedY;
            end.X += SpeedX;
            end.Y += SpeedY;
        }

        public void Draw(Graphics g, IProjectionCalculator ppCalc, RectangleF screen)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 1;
            g.DrawLine(pen, ppCalc.ProjectXCoordinate(start.X), ppCalc.ProjectYCoordinate(start.Y), ppCalc.ProjectXCoordinate(end.X), ppCalc.ProjectYCoordinate(end.Y));
        }

        public RectangleF GetBounds() => new RectangleF(start.X, start.Y, end.X - start.X + 1, end.Y - start.Y + 1);

        public PointF GetMiddle()
        {
            return new PointF(
                start.X + ((end.X-start.X) / 2),
                start.Y + ((end.Y - start.Y) / 2)
            );
        }
    }
}
