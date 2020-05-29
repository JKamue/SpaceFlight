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
            s.AddPanelObject(new TestObject(new Point(-250, -250), 3, 1));
            s.AddPanelObject(new TestObject(new Point(1500, 1500), -1, -1));
            s.SetMainObject(new TestObject(new Point(1000, 1000), -2, -2));
            s.AddPanelObject(new TestObject(new Point(800, 1000), -2, -2));
            s.AddPanelObject(new TestObject(new Point(300, 300), 1, 0));
        }
    }
}
