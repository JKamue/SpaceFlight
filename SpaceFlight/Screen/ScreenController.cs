using SpaceFlight.Objects;
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

        private readonly List<IScreenObject> _panelObjects;
        private IScreenObject mainObject;
        private readonly Timer _drawTimer;

        public ScreenController(Panel panel, Color color)
        {
            _panel = panel;
            this.color = color;

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
        }

        private void Redraw(object sender, EventArgs e)
        {
            var realCenter = mainObject.GetMiddle();
            var projectedCenter = new Point((int)Math.Round((double)_panel.Width / 2), (int)Math.Round((double)_panel.Height / 2));

            var drawRectangle = CalculateDisplayRectangle(realCenter, projectedCenter);
            var positionCalculator = new ProjectedPositionCalculator(mainObject.GetMiddle(), projectedCenter);

            _graphicsBuffer.Graphics.Clear(color);
            _panelObjects.ForEach(x => DrawObject(x, drawRectangle, positionCalculator));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private Rectangle CalculateDisplayRectangle(Point realCenter, Point projectedCenter)
        {
            return new Rectangle(realCenter.X - projectedCenter.X, realCenter.Y - projectedCenter.Y, _panel.Width, _panel.Height);
        }

        private void DrawObject(IScreenObject o, Rectangle panelBounds, ProjectedPositionCalculator positionCalculator)
        {
            if (!panelBounds.IntersectsWith(o.GetBounds()))
                return;

            o.Draw(_graphicsBuffer.Graphics, positionCalculator);
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
