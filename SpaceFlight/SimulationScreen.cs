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
            var s = new ScreenController(SimulationPanel, Color.White, 3, lblDebug);
            s.AddPanelObject(new Terrain(new Point(750, -4300), 5000, Color.Green));
            s.AddPanelObject(new Terrain(new Point(3000, 5000), 3000, Color.Blue));
            s.SetMainObject(new Rocket(new Point(300, 400), 0, 2, 0, 50, new BasicRocketSprite()));
        }
    }
}
