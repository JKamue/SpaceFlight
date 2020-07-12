using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Objects;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight.Screen.Orbit
{
    class OrbitScreenController : BufferedScreen
    {
        private ScreenObjectCollection _objects;

        public OrbitScreenController(Panel panel, ScreenObjectCollection objects) : base(panel)
        {
            _objects = objects;
            _drawTimer.Interval = 100;
        }

        public override void Redraw(object sender, EventArgs e)
        {
            _graphicsBuffer.Graphics.Clear(Color.FromArgb(0,0,160));

            var ppCalc = getProjectedPositionCalculator();
            DrawMainObjectPath(ppCalc);
            DrawAllObjects(ppCalc);

            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private ProjectedPositionCalculator getProjectedPositionCalculator()
        {
            var calculatedZoom = 0.00002f;
            var percent = 1 / calculatedZoom;
            var realCenter = _objects.MainObject.GetMiddle();
            var projectedCenter = new Point((int)Math.Round((double)_panel.Width * percent / 2),
                (int)Math.Round((double)_panel.Height * percent / 2));

            return new ProjectedPositionCalculator(realCenter, projectedCenter, calculatedZoom);
        }

        private void DrawAllObjects(ProjectedPositionCalculator ppCalc)
        {
            foreach (var planet in _objects.Terrains)
                planet.DrawSimple(_graphicsBuffer.Graphics, ppCalc);

            var mainObject = _objects.MainObject;
            var loc = mainObject.Location;
            var point1 = ppCalc.ProjectPoint(loc);
            var aCalc = new AngularCalculator((float)mainObject._angle.Degree, point1);
            var point2 = aCalc.Turn(new PointF(point1.X,point1.Y - 10));
            var point3 = aCalc.Turn(new PointF(point1.X + 5, point1.Y + 5));
            var point4 = aCalc.Turn(new PointF(point1.X - 5, point1.Y + 5));
            var polygon = new List<PointF>{point2, point3, point4};
            _graphicsBuffer.Graphics.FillPolygon(new SolidBrush(Color.LightGray), polygon.ToArray());
        }

        private void DrawMainObjectPath(ProjectedPositionCalculator ppCalc)
        {
            var position = _objects.MainObject.Location;
            var speed = _objects.MainObject.Speed;
            var mass = _objects.MainObject.Mass;
            for (var i = 0; i < 300; i++)
            {
                var forces = new Force(Angle.Zero, 0);
                foreach (var planet in _objects.Terrains)
                {
                    var distance = PointCalculator.Distance(position, planet.Location);
                    var angle = PointCalculator.CalculateAngle(position, planet.Location);
                    forces += GravityCalculator.CalculateGravity(mass, planet.Mass, distance, angle);
                }

                var acceleration = forces.GetAcceleration(mass);
                speed += acceleration.GetSpeed(new TimeSpan(0, 0, 0, 10));

                if (speed.Value > 50000)
                    break;

                var flownDistance = speed.GetDistance(new TimeSpan(0, 0, 0, 10)).CalculateXAndY();
                position.X += (float) flownDistance.X;
                position.Y += (float)flownDistance.Y;
                var projectedPosition = ppCalc.ProjectPoint(position);
                _graphicsBuffer.Graphics.FillRectangle(new SolidBrush(Color.White), projectedPosition.X, projectedPosition.Y, 1, 1);
            }
        }
    }
}
