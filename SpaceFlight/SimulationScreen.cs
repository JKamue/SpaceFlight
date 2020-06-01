using SpaceFlight.Screen;
using SpaceFlight.Screen.ScreenObjects;
using SpaceFlight.Screen.ScreenObjects.Rocket;
using SpaceFlight.Screen.ScreenObjects.Rocket.Sprites;
using SpaceFlight.Screen.ScreenObjects.Terrain;
using System.Drawing;
using System.Windows.Forms;

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
            s.SetMainObject(new Rocket(new Point(300, 400), 0, 1, 0, 70, new FalconNine()));
            s.AddPanelObject(new Rocket(new Point(270, 400), 0, 1, 120, 70, new FalconNine()));
            s.AddPanelObject(new Rocket(new Point(330, 400), 0, 1, -50, 70, new FalconNine()));
        }
    }
}
