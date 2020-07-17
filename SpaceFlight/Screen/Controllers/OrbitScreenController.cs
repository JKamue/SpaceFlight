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

namespace SpaceFlight.Screen.Controllers
{
    class OrbitScreenController : BufferedScreen
    {
        private ScreenObjectCollection _objects;

        private int zoom = 4;
        private bool fixOnMouse = false;
        private Point mouse = Point.Empty;
        private PointM mouseCenter = PointM.Empty;
        private ProjectedPositionCalculator lastPpCalc;
        public OrbitScreenController(Panel panel, ScreenObjectCollection objects) : base(panel)
        {
            _objects = objects;
            _drawTimer.Interval = 100;

            _panel.MouseWheel += Scroll_Event;
            _panel.Click += Click_Event;
            _panel.MouseMove += Mouse_Move;
        }

        public void Mouse_Move(object sender, MouseEventArgs e)
        {
            mouse = new Point(e.X, e.Y);
        }

        public override void Redraw(object sender, EventArgs e)
        {
            _graphicsBuffer.Graphics.Clear(Color.FromArgb(0, 0, 160));

            var ppCalc = GetProjectedPositionCalculator();
            DrawMainObjectPath(ppCalc);
            DrawAllObjects(ppCalc);

            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private ProjectedPositionCalculator GetProjectedPositionCalculator()
        {
            var calculatedZoom = CalculateZoom(zoom);
            var percent = 1 / calculatedZoom;
            
            var projectedCenter = new Point((int)Math.Round(_panel.Width * percent / 2),
                (int)Math.Round(_panel.Height * percent / 2));

            var center = fixOnMouse ? mouseCenter : _objects.MainObject.GetMiddle();

            return lastPpCalc = new ProjectedPositionCalculator(center, projectedCenter, calculatedZoom);
        }

        private void DrawAllObjects(ProjectedPositionCalculator ppCalc)
        {
            foreach (var planet in _objects.Terrains)
                planet.DrawSimple(_graphicsBuffer.Graphics, ppCalc);

            var mainObject = _objects.MainObject;
            var loc = mainObject.Location;
            var point1 = ppCalc.ProjectPoint(loc);
            var aCalc = new AngularCalculator(mainObject._angle.Degree, point1);
            var point2 = aCalc.Turn(new PointM(point1.X, point1.Y - 10)).Round();
            var point3 = aCalc.Turn(new PointM(point1.X + 5, point1.Y + 5)).Round();
            var point4 = aCalc.Turn(new PointM(point1.X - 5, point1.Y + 5)).Round();
            var polygon = new List<Point> { point2, point3, point4 };
            _graphicsBuffer.Graphics.FillPolygon(new SolidBrush(Color.LightGray), polygon.ToArray());
        }

        private void DrawMainObjectPath(ProjectedPositionCalculator ppCalc)
        {
            var points = OrbitPredictionCalculator.GetPredictedPointList(_objects.MainObject, _objects.Terrains,
                new TimeSpan(0, 60,0), false);
            var point2s = OrbitPredictionCalculator.GetPredictedPointList(_objects.MainObject, _objects.Terrains,
                new TimeSpan(0, 60, 0), true);

            foreach (var point in points)
            {
                var projectedPosition = ppCalc.ProjectPoint(point).Round();
                _graphicsBuffer.Graphics.FillRectangle(new SolidBrush(Color.White), projectedPosition.X,
                    projectedPosition.Y, 1, 1);
            }

            foreach (var point in point2s)
            {
                var projectedPosition = ppCalc.ProjectPoint(point).Round();
                _graphicsBuffer.Graphics.FillRectangle(new SolidBrush(Color.Orange), projectedPosition.X,
                    projectedPosition.Y, 1, 1);
            }
        }

        private decimal CalculateZoom(int zoom) => (decimal)(31 * Math.Pow(zoom, 2) / 5000000 + 1 / 200000);

        private void Scroll_Event(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoom + 1 <= 7)
            {
                mouseCenter = lastPpCalc.ReversPoint(mouse);
                zoom++;
            }
            else if (e.Delta < 0 && zoom - 1 > 0)
            {
                mouseCenter = lastPpCalc.ReversPoint(mouse);
                zoom--;
            }
        }

        private void Click_Event(object sender, EventArgs e) => fixOnMouse = !fixOnMouse;
    }
}