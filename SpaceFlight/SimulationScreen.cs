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
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(250, 500), 250, Color.Blue));
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(750, -500), 250, Color.Blue));
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(0, -6371000), 6371000, Color.Green));


            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");
            closeDistanceScreen.SetMainObject(new Rocket(new PointF(0, 0), 4F, 0, -1.5F, 10F, inf));

        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
