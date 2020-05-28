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

        public PanelController(Panel panel)
        {
            _panel = panel;
            TestDraw();
        }

        private void TestDraw()
        {
            var graphics = _panel.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            graphics.DrawLine(pen, 0, 0, _panel.Width - 10, _panel.Height - 10);
        }

        
    }
}
