using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight.Screen.ScreenObjects
{
    class TestObject : IScreenObject
    {
        private Point p;
        private int SpeedX;
        private int SpeedY;

        public TestObject(Point start, int speedX, int speedY)
        {
            p = start;
            SpeedX = speedX;
            SpeedY = speedY;

            var t = new Timer();
            t.Interval = 10;
            t.Tick += MoveRight;
            t.Enabled = true;
        }

        private void MoveRight(object sender, EventArgs e)
        {
            p.X += SpeedX;
            p.Y += SpeedY;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 1;
            g.DrawLine(pen, p.X, p.Y, p.X+200, p.Y+200);
        }

        public Rectangle GetBounds() => new Rectangle(p.X, p.Y, 200, 200);
    }
}
