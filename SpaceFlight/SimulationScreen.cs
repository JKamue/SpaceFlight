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
            var s = new ScreenController(SimulationPanel, Color.White, 3, lblDebug);
            s.AddPanelObject(new Terrain(new Point(750, -5000), 5000, Color.Green));
            s.AddPanelObject(new Terrain(new Point(6000, 3000), 3000, Color.Blue));
            s.AddPanelObject(new Terrain(new Point(25000, -8000), 13000, Color.Yellow));
            s.SetMainObject(new TestObject(new Point(300, 400), new Point(340, 400), 20, 0));
        }
    }
}
