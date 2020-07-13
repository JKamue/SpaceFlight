using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SpaceFlight.Objects;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Screen.Controllers
{
    class ScreenController : BufferedScreen
    {
        private readonly ScreenObjectCollection _objects;

        private float zoom;

        private Point staticCenter;

        public Color Color;

        public ScreenController(Panel panel, ScreenObjectCollection objects, Color color, float zoom) : base(panel)
        {
            _objects = objects;
            this.Color = color;
            this.zoom = zoom;

            // Setup graphics

            _panel.MouseWheel += Scroll_Event;
            staticCenter = new Point(0, 0);
        }

        public override void Redraw(object sender, EventArgs e)
        {
            var calculatedZoom = CalculateZoom();
            var percent = 1 / calculatedZoom;

            ProjectedPositionCalculator positionCalculator;
            RectangleF drawRectangle;

            if (_objects.MainObject != null)
            {
                var realCenter = _objects.MainObject.GetMiddle();
                var projectedCenter = new Point((int) Math.Round((double) _panel.Width * percent / 2),
                    (int) Math.Round((double) _panel.Height * percent / 2));
                drawRectangle = CalculateDisplayRectangle(realCenter, projectedCenter, percent);
                positionCalculator =
                    new ProjectedPositionCalculator(_objects.MainObject.GetMiddle(), projectedCenter, calculatedZoom);
            }
            else
            {
                var projectedCenter = new Point((int) Math.Round((double) _panel.Width * percent / 2),
                    (int) Math.Round((double) _panel.Height * percent / 2));
                drawRectangle = CalculateDisplayRectangle(staticCenter, projectedCenter, percent);
                positionCalculator = new ProjectedPositionCalculator(staticCenter, projectedCenter, calculatedZoom);
            }


            _graphicsBuffer.Graphics.Clear(Color);
            _objects.ScreenObjects.ForEach(x => DrawObject(x, drawRectangle, positionCalculator));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private float CalculateZoom() => (14.95F / 225F) * (float) Math.Pow(zoom, 2) + 0.05F;

        private RectangleF CalculateDisplayRectangle(PointF realCenter, Point projectedCenter, float percent)
        {
            return new RectangleF(realCenter.X - projectedCenter.X, realCenter.Y - projectedCenter.Y,
                (int) Math.Round(_panel.Width * percent), (int) Math.Round(_panel.Height * percent));
        }

        private void DrawObject(IScreenObject o, RectangleF panelBounds, ProjectedPositionCalculator positionCalculator)
        {
            var objectBounds = o.GetBounds();

            if (!panelBounds.IntersectsWith(objectBounds) && !panelBounds.Contains(objectBounds) &&
                !objectBounds.Contains(panelBounds))
                return;

            o.Draw(_graphicsBuffer.Graphics, positionCalculator, panelBounds);
        }

        private void Scroll_Event(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && zoom + 1 <= 15)
            {
                zoom++;
            }
            else if (e.Delta < 0 && zoom - 1 >= 0)
            {
                zoom--;
            }
        }
    }

}