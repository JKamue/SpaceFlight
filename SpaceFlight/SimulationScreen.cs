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
            s.SetMainObject(new TestObject(new Point(300, 400), new Point(340, 400), 6, 0));
        }
    }
}
