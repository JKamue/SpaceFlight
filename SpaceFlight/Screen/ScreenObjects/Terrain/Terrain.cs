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
        private Point position;

        public Terrain(Point position, double radius, Color color)
        {
            this.color = color;
            this.radius = radius;
            this.position = position;

            var rnd = new Random(DateTime.Now.Millisecond);
            Noise.Seed = rnd.Next(0, 3000);
        }

        public void Draw(Graphics g, IProjectionCalculator ppCalc, Rectangle screen)
        {
            height = 0;

            var points = new List<Point>();


            for (int i = 0; i < 2 * Math.PI * radius; i++)
            {
                var y = (int)Math.Round(Noise.Generate(i * 0.0025f) * 128 + 128 / 2.5);
                points.Add(ppCalc.ProjectPoint(ProjectOntoCircle(new Point(i, y))));

                if (y > height)
                    height = y;
            }


            SolidBrush b = new SolidBrush(color);
            g.FillPolygon(b, points.ToArray());
        }

        private Point ProjectOntoCircle(Point p)
        {
            var U = 2 * Math.PI * radius;
            var w = 360 * ((double) p.X / U);
            var addX = (int) Math.Round((radius + p.Y) * Math.Sin(w * Math.PI / 180));
            var addY = (int)Math.Round((radius + p.Y) * Math.Cos(w * Math.PI / 180));

            return new Point(position.X + addX, position.Y + addY);
        }

        public Rectangle GetBounds()
        {
            var x = (int)Math.Round(position.X - radius - 80);
            var y = (int)Math.Round(position.Y - radius - 80);
            var size = (int)Math.Round(radius * 2 + 160);

            return new Rectangle(x, y, size, size);
        }

        public Point GetMiddle() => position;
    }
}
