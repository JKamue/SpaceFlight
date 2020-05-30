using SpaceFlight.Objects;
using SpaceFlight.Screen;
using SpaceFlight.Screen.ScreenObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        public SimulationScreen()
        {
            InitializeComponent();
            var s = new ScreenController(SimulationPanel, Color.White, 1, lblDebug);
            s.AddPanelObject(new TestObject(new Point(10, 10), new Point(1000,10), 0, 0));
            s.SetMainObject(new TestObject(new Point(300, 10), new Point(300, 50), 0, 2));
            s.AddPanelObject(new TestObject(new Point(500, 10), new Point(500, 60), 0, 1));
            s.AddPanelObject(new TestObject(new Point(100, 10), new Point(100, 30), 0, 3));
        }
    }
}
