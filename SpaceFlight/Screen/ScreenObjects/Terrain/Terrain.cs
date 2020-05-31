using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Screen.ScreenObjects.Terrain
{
    class Terrain : IScreenObject
    {
        private int height = 100;
        private Color color;
        private double radius;
        private PointF position;

        public Terrain(PointF position, double radius, Color color)
        {
            this.color = color;
            this.radius = radius;
            this.position = position;

            var rnd = new Random(DateTime.Now.Millisecond);
            Noise.Seed = rnd.Next(0, 3000);
        }

        public void Draw(Graphics g, IProjectionCalculator ppCalc, RectangleF screen)
        {
            height = 0;

            var points = new List<PointF>();


            for (int i = 0; i < 2 * Math.PI * radius; i+=5)
            {
                var y = (int)Math.Round(Noise.Generate(i * 0.0025f) * 128 + 128 / 2.5);
                points.Add(ppCalc.ProjectPoint(ProjectOntoCircle(new Point(i, y))));

                if (y > height)
                    height = y;
            }


            SolidBrush b = new SolidBrush(color);
            g.FillPolygon(b, points.ToArray());
        }

        private PointF ProjectOntoCircle(Point p)
        {
            var U = 2 * Math.PI * radius;
            var w = 360 * ((double) p.X / U);
            var addX = (radius + p.Y) * Math.Sin(w * Math.PI / 180);
            var addY = (radius + p.Y) * Math.Cos(w * Math.PI / 180);

            return new PointF( (float) (position.X + addX), (float) (position.Y + addY));
        }

        public RectangleF GetBounds()
        {
            var x = position.X - radius - 80;
            var y = position.Y - radius - 80;
            var size = radius * 2 + 160;

            return new RectangleF((float) x, (float) y, (float) size, (float) size);
        }

        public PointF GetMiddle() => position;
    }
}
