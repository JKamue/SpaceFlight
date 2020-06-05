using System.Collections.Generic;
using SpaceFlight.Screen;
using SpaceFlight.Screen.ScreenObjects;
using SpaceFlight.Screen.ScreenObjects.Rocket;
using SpaceFlight.Screen.ScreenObjects.Rocket.Sprites;
using SpaceFlight.Screen.ScreenObjects.Terrain;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        public SimulationScreen()
        {
            InitializeComponent();
            var s = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            s.AddPanelObject(new Terrain(new Point(750, -4300), 5000, Color.Green));
            s.AddPanelObject(new Terrain(new Point(3000, 5000), 3000, Color.Blue));

            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");

            s.SetMainObject(new Rocket(new Point(300, 400), 0, 1, 0, inf));
            s.AddPanelObject(new Rocket(new Point(320, 400), 0, 1, 0, atl));
        }
    }
}
