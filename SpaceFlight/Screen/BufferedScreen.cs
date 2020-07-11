using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight.Screen
{
    class BufferedScreen
    {
        protected readonly Panel _panel;

        protected readonly BufferedGraphicsContext _context;
        protected readonly BufferedGraphics _graphicsBuffer;
        protected readonly Graphics _panelGraphics;
        protected readonly Timer _drawTimer;

        protected FrameRateCounter actualFramerate;

        public BufferedScreen(Panel panel)
        {
            _panel = panel;
            _context = BufferedGraphicsManager.Current;
            _panelGraphics = _panel.CreateGraphics();
            _graphicsBuffer = _context.Allocate(_panelGraphics, _panel.DisplayRectangle);

            actualFramerate = new FrameRateCounter();

            _drawTimer = new Timer();
            _drawTimer.Interval = 10;
            _drawTimer.Tick += Redraw;
            _drawTimer.Start();
        }

        public virtual void Redraw(object sender, EventArgs e)
        {

        }

        public int GetActualFramerate() => actualFramerate.Framerate;
    }
}
