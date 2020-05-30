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
        private int height = 10;
        private Color color;
        private Rectangle lastScreen = new Rectangle(-5000, 0, 10000, 10);

        public Terrain(int height, Color color)
        {
            this.color = color;

            var rnd = new Random(DateTime.Now.Millisecond);
            Noise.Seed = rnd.Next(0, 3000);
        }

        public void Draw(Graphics g, IProjectionCalculator ppCalc, Rectangle screen)
        {
            height = 0;

            var points = new List<Point>();


            points.Add(ppCalc.ProjectPoint(new Point(screen.X, screen.Y - screen.Height)));

            for (int i = 0; i < screen.Width; i++)
            {
                var x = screen.X + i;
                var y = (int)Math.Round(Noise.Generate(x * 0.005f) * 128 + 128 / 2.5);
                points.Add(ppCalc.ProjectPoint(new Point(x, y)));

                if (y > height)
                    height = y;
            }

            points.Add(ppCalc.ProjectPoint(new Point(screen.X + screen.Width, screen.Y - screen.Height)));

            SolidBrush b = new SolidBrush(Color.SaddleBrown);
            g.FillPolygon(b, points.ToArray());

            lastScreen = screen;
        }

        public Rectangle GetBounds() => new Rectangle(lastScreen.X, 0, lastScreen.Width, height);

        public Point GetMiddle()
        {
            return new Point(400, (int)Math.Round((double) height / 2));
        }
    }
}
