using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Screen
{
    class ScreenController
    {
        private readonly Panel _panel;

        private readonly BufferedGraphicsContext _context;
        private readonly BufferedGraphics _graphicsBuffer;
        private readonly Graphics _panelGraphics;

        private FrameRateCounter actualFramerate;
        private int objectCounter = 0;

        private Color color;
        private float zoom;

        private List<IScreenObject> _panelObjects;
        private IScreenObject mainObject = null;
        private readonly Timer _drawTimer;

        private Point staticCenter;

        public bool ShowInfo;

        public ScreenController(Panel panel, Color color, float zoom)
        {
            _panel = panel;
            this.color = color;
            this.zoom = zoom;

            // Setup graphics
            _context = BufferedGraphicsManager.Current;
            _panelGraphics = _panel.CreateGraphics();
            _graphicsBuffer = _context.Allocate(_panelGraphics, panel.DisplayRectangle);


            _panelObjects = new List<IScreenObject>();
            
            actualFramerate = new FrameRateCounter();

            _drawTimer = new Timer();
            _drawTimer.Interval = 10;
            _drawTimer.Tick += Redraw;
            _drawTimer.Start();

            _panel.MouseWheel += Scroll_Event;
            staticCenter = new Point(0,0);
        }

        private void Redraw(object sender, EventArgs e)
        {
            objectCounter = 0;
            var calculatedZoom = CalculateZoom();
            var percent = 1 / calculatedZoom;

            ProjectedPositionCalculator positionCalculator;
            RectangleF drawRectangle;

            if (mainObject != null)
            {
                var realCenter = mainObject.GetMiddle();
                var projectedCenter = new Point((int)Math.Round((double)_panel.Width * percent / 2), (int)Math.Round((double)_panel.Height * percent / 2));
                drawRectangle = CalculateDisplayRectangle(realCenter, projectedCenter, percent);
                positionCalculator = new ProjectedPositionCalculator(mainObject.GetMiddle(), projectedCenter, calculatedZoom);
            }
            else
            {
                var projectedCenter = new Point((int)Math.Round((double)_panel.Width * percent / 2), (int)Math.Round((double)_panel.Height * percent / 2));
                drawRectangle = CalculateDisplayRectangle(staticCenter, projectedCenter, percent);
                positionCalculator = new ProjectedPositionCalculator(staticCenter, projectedCenter, calculatedZoom);
            }


            _graphicsBuffer.Graphics.Clear(color);
            _panelObjects.ForEach(x => DrawObject(x, drawRectangle, positionCalculator));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private float CalculateZoom() => (14.95F / 225F) * (float) Math.Pow(zoom, 2) + 0.05F;

        private RectangleF CalculateDisplayRectangle(PointF realCenter, Point projectedCenter, float percent)
        {
            return new RectangleF(realCenter.X - projectedCenter.X, realCenter.Y - projectedCenter.Y, (int) Math.Round(_panel.Width * percent), (int)Math.Round(_panel.Height * percent));
        }

        private void DrawObject(IScreenObject o, RectangleF panelBounds, ProjectedPositionCalculator positionCalculator)
        {
            var objectBounds = o.GetBounds();

            if (!panelBounds.IntersectsWith(objectBounds) && !panelBounds.Contains(objectBounds) && !objectBounds.Contains(panelBounds))
                return;

            o.Draw(_graphicsBuffer.Graphics, positionCalculator, panelBounds);
            objectCounter++;
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

        public void AddPanelObject(IScreenObject o)
        {
            _panelObjects.Add(o);
            SortObjectList();
        }

        private void SortObjectList()
        {
            _panelObjects = _panelObjects.OrderBy(o => o.GetPriority()).ToList();
        }

        public void RemovePanelObject(IScreenObject o) => _panelObjects.RemoveAll(x => x == o);

        public int GetActualFramerate() => actualFramerate.Framerate;

        public void SetMainObject(IScreenObject o)
        {
            mainObject = o;
            RemovePanelObject(o);
            AddPanelObject(o);
        }

        public IScreenObject GetMainObject() => mainObject;

        public void ChangeMainObjectAngle(float change) => mainObject.ChangeAngle(change);

    }
}
