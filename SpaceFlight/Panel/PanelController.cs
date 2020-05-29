using SpaceFlight.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight
{
    class PanelController
    {
        private readonly Panel _panel;

        private FrameRateCounter actualFramerate;

        private readonly List<IPanelObject> _panelObjects;
        private readonly Timer _drawTimer;

        public PanelController(Panel panel)
        {
            _panel = panel;
            _panelObjects = new List<IPanelObject>();

            actualFramerate = new FrameRateCounter();

            _drawTimer = new Timer();
            _drawTimer.Interval = 10;
            _drawTimer.Tick += Redraw;
            _drawTimer.Start();
        }

        public void Redraw(object sender, EventArgs e)
        {
            actualFramerate.FrameDrawn();
        }

        public void AddPanelObject(IPanelObject o) => _panelObjects.Add(o);

        public void RemovePanelObject(IPanelObject o) => _panelObjects.RemoveAll(x => x == o);

        public int GetActualFramerate() => actualFramerate.Framerate;

    }
}
