using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Terrain
{
    class Terrain : IScreenObject
    {
        private int height = 100;
        private Color color;
        private double radius;
        private PointF position;
        private List<PointF> allPoints;

        public Terrain(PointF position, double radius, Color color)
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

            var firstOutsidePoint = new PointF();
            var preInsidePoint = new PointF();
            var pointOutside = false;

            foreach(var point in allPoints)
            {
                var finalIn = false;

                if (screen.Contains(point))
                {
                    if (pointOutside)
                    {
                        finalIn = true;
                        pointOutside = false;
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
                        firstOutsidePoint = point;
                        points.Add(ppCalc.ProjectPoint(point));
                    }

                    preInsidePoint = point;
                }

                if (finalIn)
                {
                    if (firstOutsidePoint.X == point.X || firstOutsidePoint.Y == point.Y)
                        continue;

                    if (firstOutsidePoint.X < screen.X)
                    {
                        if (position.Y < firstOutsidePoint.Y)
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X, screen.Y - screen.Height)));
                        }
                        else
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X, screen.Y + screen.Height)));
                        }
                    }
                    else if (firstOutsidePoint.X > screen.X + screen.Width)
                    {
                        if (position.Y < firstOutsidePoint.Y)
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Width, screen.Y - screen.Height)));
                        }
                        else
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Width, screen.Y + screen.Height)));
                        }
                    }

                    if (preInsidePoint.X < screen.X)
                    {
                        if (position.Y < preInsidePoint.Y)
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X, screen.Y - screen.Height)));
                        }
                        else
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X, screen.Y + screen.Height)));
                        }
                    }
                    else if (preInsidePoint.X > screen.X + screen.Width)
                    {
                        if (position.Y < preInsidePoint.Y)
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Width, screen.Y - screen.Height)));

                        }
                        else
                        {
                            points.Add(ppCalc.ProjectPoint(new PointF(screen.X + screen.Width, screen.Y + screen.Height)));
                        }
                    }
                    points.Add(ppCalc.ProjectPoint(preInsidePoint));
                }
            }

            SolidBrush b = new SolidBrush(color);

            if (points.Count == 0)
                return;

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
