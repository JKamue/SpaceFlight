using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SpaceFlight.Objects;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Other;

namespace SpaceFlight.Screen.Controllers
{
    class ScreenController : BufferedScreen
    {
        private readonly ScreenObjectCollection _objects;

        private decimal zoom;

        private Point staticCenter;

        public Color Color;

        public ScreenController(Panel panel, ScreenObjectCollection objects, Color color, decimal zoom) : base(panel)
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

            var projectedCenter = new Point((int) Math.Round(_panel.Width * percent / 2),
                 (int) Math.Round(_panel.Height * percent / 2));
            var drawRectangle = CalculateDisplayRectangle(_objects.MainObject.GetMiddle(), projectedCenter, percent);
            var positionCalculator =
                new ProjectedPositionCalculator(_objects.MainObject.GetMiddle(), projectedCenter, calculatedZoom);
            
            _graphicsBuffer.Graphics.Clear(Color);
            _objects.ScreenObjects.ForEach(x => DrawObject(x, drawRectangle, positionCalculator));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private decimal CalculateZoom() => (14.95m / 225m) * (decimal) Math.Pow((double) zoom, 2) + 0.05m;

        private RectangleM CalculateDisplayRectangle(PointM realCenter, Point projectedCenter, decimal percent)
        {
            return new RectangleM(realCenter.X - projectedCenter.X, realCenter.Y - projectedCenter.Y,
                (int) Math.Round(_panel.Width * percent), (int) Math.Round(_panel.Height * percent));
        }

        private void DrawObject(IScreenObject o, RectangleM panelBounds, ProjectedPositionCalculator positionCalculator)
        {
            var objectBounds = o.GetBounds();


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