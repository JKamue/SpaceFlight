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
        private int x = -230;
        public TestObject()
        {
            var t = new Timer();
            t.Interval = 10;
            t.Tick += MoveRight;
            t.Enabled = true;
        }

        private void MoveRight(object sender, EventArgs e)
        {
            x+=1;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 1;
            g.DrawLine(pen, x, 0, x+200, 200);
        }

        public Rectangle GetBounds() => new Rectangle(x, 0, 200, 200);
    }
}
