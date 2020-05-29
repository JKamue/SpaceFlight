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
            var s = new ScreenController(SimulationPanel, Color.White);
            s.AddPanelObject(new TestObject());
        }
    }
}
