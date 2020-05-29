using SpaceFlight.Objects;
using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight.Screen
{
    class ScreenController
    {
        private readonly Panel _panel;
        private readonly BufferedGraphicsContext _context;
        private readonly BufferedGraphics _graphicsBuffer;
        private readonly Graphics _panelGraphics;

        private FrameRateCounter actualFramerate;
        private Color color;
        private float zoom;

        private readonly List<IScreenObject> _panelObjects;
        private IScreenObject mainObject = null;
        private readonly Timer _drawTimer;

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
        }

        private void Redraw(object sender, EventArgs e)
        {
            IProjectionCalculator positionCalculator;
            Rectangle drawRectangle;

            if (mainObject != null)
            {
                var percent = 1/zoom;
                
                var realCenter = mainObject.GetMiddle();
                var projectedCenter = new Point((int)Math.Round((double)_panel.Width * percent / 2), (int)Math.Round((double)_panel.Height * percent / 2));

                drawRectangle = CalculateDisplayRectangle(realCenter, projectedCenter, percent);
                positionCalculator = new ProjectedPositionCalculator(mainObject.GetMiddle(), projectedCenter, zoom);
            } else
            {
                drawRectangle = _panel.Bounds;
                positionCalculator = new EmptyProjectionCalculator();
            }


            _graphicsBuffer.Graphics.Clear(color);
            _panelObjects.ForEach(x => DrawObject(x, drawRectangle, positionCalculator));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private Rectangle CalculateDisplayRectangle(Point realCenter, Point projectedCenter, float percent)
        {
            return new Rectangle(realCenter.X - projectedCenter.X, realCenter.Y - projectedCenter.Y, (int) Math.Round(_panel.Width * percent), (int)Math.Round(_panel.Height * percent));
        }

        private void DrawObject(IScreenObject o, Rectangle panelBounds, IProjectionCalculator positionCalculator)
        {
            if (!panelBounds.IntersectsWith(o.GetBounds()))
                return;

            o.Draw(_graphicsBuffer.Graphics, positionCalculator);
        }

        private void Scroll_Event(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0 && zoom + 0.1 <= 3)
            {
                zoom += (float) 0.1;
            } 
            else if (e.Delta < 0 && zoom - 0.1 >= 0.2)
            {
                zoom -= (float) 0.1;
            }

        }

        public void AddPanelObject(IScreenObject o) => _panelObjects.Add(o);

        public void RemovePanelObject(IScreenObject o) => _panelObjects.RemoveAll(x => x == o);

        public int GetActualFramerate() => actualFramerate.Framerate;

        public void SetMainObject(IScreenObject o)
        {
            mainObject = o;
            RemovePanelObject(o);
            AddPanelObject(o);
        }

    }
}
