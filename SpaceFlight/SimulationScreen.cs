using SpaceFlight.Screen;
using System.Drawing;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        private ScreenController closeDistanceScreen;

        public SimulationScreen()
        {
            InitializeComponent();
            closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(3000, 5000), 3000, Color.Blue));
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(750, -4300), 5000, Color.Green));

            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");

            closeDistanceScreen.AddPanelObject(new Rocket(new Point(300, 400), 0, 1, 0, 1F, atl));
            closeDistanceScreen.SetMainObject(new Rocket(new Point(270, 400), 0, 1, 0,1F, inf));
        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
