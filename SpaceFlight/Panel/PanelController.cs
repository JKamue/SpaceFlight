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

        private FrameRate targetFramerate;
        private FrameRate actualFramerate;

        private readonly List<IPanelObject> _panelObjects;

        public PanelController(Panel panel, FrameRate frameRate)
        {
            _panel = panel;
            _panelObjects = new List<IPanelObject>();
            targetFramerate = frameRate;

            actualFramerate = new FrameRate();
        }

        public void AddPanelObject(IPanelObject o) => _panelObjects.Add(o);

        public void RemovePanelObject(IPanelObject o) => _panelObjects.RemoveAll(x => x == o);

        public void SetTargetFramerate(FrameRate f) => targetFramerate = f;

        public int GetActualFramerate() => actualFramerate.Framerate;

    }
}
