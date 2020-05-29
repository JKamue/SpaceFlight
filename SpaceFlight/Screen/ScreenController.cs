using SpaceFlight.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public void Redraw(object sender, EventArgs e)
        {
            _graphicsBuffer.Graphics.Clear(color);
            _panelObjects.ForEach(x => DrawObject(x, _panel.Bounds));
            actualFramerate.FrameDrawn();
            _graphicsBuffer.Render(_panelGraphics);
        }

        private void DrawObject(IScreenObject o, Rectangle panelBounds)
        {
            if (!panelBounds.IntersectsWith(o.GetBounds()))
                return;

            o.Draw(_graphicsBuffer.Graphics);
        }

        public void AddPanelObject(IScreenObject o) => _panelObjects.Add(o);

        public void RemovePanelObject(IScreenObject o) => _panelObjects.RemoveAll(x => x == o);

        public int GetActualFramerate() => actualFramerate.Framerate;

    }
}
