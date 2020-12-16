using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public readonly string Name;

        public Terrain(PointF position, float radius, Color color, Mass mass, string name): base(position, mass, radius)
        {
            this.color = color;
            this.radius = radius;
            this.position = position;
            Name = name;

            var rnd = new Random(DateTime.Now.Millisecond);
            Noise.Seed = rnd.Next(0, 3000);

            GenerateAllPoints();
        }

        private void GenerateAllPoints()
        {
            allPoints = new List<PointF>();
            for (var i = 0; i < 2 * Math.PI * radius; i += 40)
            {
                var angle = 360 * (i / (2 * Math.PI * radius));
                var noiseX = radius * (float) Math.Sin(angle * Math.PI / 180) * 0.0015f;
                var noiseY = radius * (float) Math.Cos(angle * Math.PI / 180) * 0.0015f;

                var noiseHeight = (int) Math.Round(Noise.Generate(noiseX, noiseY) * 128 + 128 / 2.5);

                if (noiseHeight > height)
                    height = noiseHeight;

                allPoints.Add(ProjectOntoCircle(new Point(i, noiseHeight)));
            }
        }

        public void DrawSimple(Graphics g, ProjectedPositionCalculator ppCalc)
        {
            var start = ppCalc.ProjectPoint(new PointF(Location.X - radius, Location.Y - radius));
            var end = ppCalc.ProjectPoint(new PointF(Location.X + radius, Location.Y + radius));
            var rect = new RectangleF(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            g.FillEllipse(new SolidBrush(color), rect);
        }

        public void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen)
        {
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

            var b = new SolidBrush(color);

            if (points.Count == 0)
                return;

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
            var x = position.X - radius - height;
            var y = position.Y - radius - height;
            var size = radius * 2 + height * 2;

            return new RectangleF((float) x, (float) y, (float) size, (float) size);
        }

        public PointF GetMiddle() => position;

        public void ChangeAngle(float change) { }

        public int GetPriority() => 1;
    }
}
