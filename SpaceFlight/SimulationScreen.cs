using SpaceFlight.Objects;
using SpaceFlight.Screen;
using SpaceFlight.Screen.ScreenObjects;
using SpaceFlight.Screen.ScreenObjects.Terrain;
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
            s.AddPanelObject(new Terrain(20, Color.Green));
            s.AddPanelObject(new TestObject(new Point(300, 400), new Point(340, 400), 2, 0));
            s.AddPanelObject(new TestObject(new Point(500, 410), new Point(540, 410), 3, 0));
            s.AddPanelObject(new TestObject(new Point(100, 420), new Point(140, 420), 1, 0));
        }
    }
}
