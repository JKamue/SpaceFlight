using SpaceFlight.Screen;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        private ScreenController closeDistanceScreen;

        public SimulationScreen()
        {
            InitializeComponent();
            closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(6371000, 0), 6371000, Color.Green));


            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");
            closeDistanceScreen.SetMainObject(new Rocket(new PointF(0, 0), 0, 100F, 0, 100F, inf));

            var angle = Angle.FromDegrees(0);
            var test = new PhysicsObject(new PointF(0, 0), new Mass(1), new Force(angle, 5), new Acceleration(angle, 0), new Speed(angle, 0));

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                var ok = test.Location;
                test.Recalculate();
            }

            var ok2 = test.Location;

        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
