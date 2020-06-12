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
            closeDistanceScreen.AddPanelObject(new Terrain(new Point(0, -6371000), 6371000, Color.Green));


            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");
            var zeroAngle = Angle.FromDegrees(0);

            var rocket1 = new Rocket(new PointF(0, 0), new Mass(inf.Weight), new Force(zeroAngle, inf.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), 0, 1F, inf);

            closeDistanceScreen.SetMainObject(rocket1);
            //closeDistanceScreen.SetMainObject(new Rocket(new PointF(50, 0), new Mass(atl.Weight), new Force(zeroAngle, atl.Thrust), new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), 0, 1F, atl));


            var physicsController = new PhysicsController(10);
            physicsController.AddMovingObject(rocket1);
        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
