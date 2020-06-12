using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Terrain
{
    class Terrain : PhysicsObject, IScreenObject
    {
        private int height = 100;
        private Color color;
        private float radius;
        private PointF position;
        private List<PointF> allPoints;

        public Terrain(PointF position, float radius, Color color, Mass mass): base(position, mass)
        {
            this.color = color;
            this.radius = radius;
            this.position = position;

            var rnd = new Random(DateTime.Now.Millisecond);
            Noise.Seed = rnd.Next(0, 3000);

            GenerateAllPoints();
        }

        private void GenerateAllPoints()
        {
            allPoints = new List<PointF>();
            for (int i = 0; i < 2 * Math.PI * radius; i += 40)
            {
                var y = (int) Math.Round(Noise.Generate(i * 0.001f) * 128 + 128 / 2.5);
                allPoints.Add(ProjectOntoCircle(new Point(i, y)));
            }
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen, bool inf)
        {
            height = 0;

            var points = new List<PointF>();

            var lastPoint = new PointF();
            var pointOutside = false;

            var pointDistance = allPoints.Count / 720;
            var distanceCounter = 0;
            var realPoints = 0;

            foreach(var point in allPoints)
            {

                if (screen.Contains(point))
                {
                    distanceCounter = 0;
                    if (pointOutside)
                    {
                        pointOutside = false;
                        points.Add(ppCalc.ProjectPoint(lastPoint));
                        realPoints++;
                    }
                    else
                    {
                        points.Add(ppCalc.ProjectPoint(point));

                        if (point.Y > height)
                            height = (int)Math.Round(point.Y);
                    }
                }
                else
                {
                    if (!pointOutside)
                    {
                        pointOutside = true;
                        points.Add(ppCalc.ProjectPoint(point));
                    }

                    if (distanceCounter > pointDistance)
                    {
                        points.Add(ppCalc.ProjectPoint(point));
                        distanceCounter = 0;
                    }

                    distanceCounter++;
                }

                lastPoint = point;
            }

            SolidBrush b = new SolidBrush(color);

            if (points.Count == 0)
                return;

            if (realPoints == 0)
            {
                var rect = new RectangleF(position.X - radius,position.Y - radius, radius * 2, radius * 2);
                if (rect.Contains(screen))
                {
                    points = new List<PointF>();
                    var a = 100;
                    points.Add(ppCalc.ProjectPoint(new PointF(screen.X - a, screen.Y - a)));
                    points.Add(ppCalc.ProjectPoint(new PointF(screen.X - a, screen.Y + screen.Width * 2 + a)));
                    points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Height * 2 + a, screen.Y + screen.Width * 2 + a)));
                    points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Height * 2 + a, screen.Y - a)));

                }
            }

            //points.Add(ppCalc.ProjectPoint(position));
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

        public int GetPriority() => 1;
    }
}
