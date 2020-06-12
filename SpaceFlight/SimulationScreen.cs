using SpaceFlight.Screen;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        private ScreenController closeDistanceScreen;

        public SimulationScreen()
        {
            InitializeComponent();
            closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            var physicsController = new PhysicsController(10, lblDebugDistance);
            var zeroAngle = Angle.FromDegrees(0);

            // Load Planets
            var earth = new Terrain(new Point(0, -6371000), 6371000, Color.Green, new Mass(5.972E+024));


            // Load Rockets
            var inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var atl = RocketInformation.LoadFromName("atlas-V-401");

            var f9 = new Rocket(new PointF(0, 0), new Mass(inf.Weight), new Force(zeroAngle, inf.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), 0, 1F, inf);
            var aV401 = new Rocket(new PointF(30, 0), new Mass(inf.Weight), new Force(zeroAngle, atl.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), 0, 1F, atl);


            // Load Screen objects
            closeDistanceScreen.AddPanelObject(earth);
            closeDistanceScreen.SetMainObject(f9);
            // closeDistanceScreen.SetMainObject(aV401);

            // Set Physic objects
            physicsController.AddMovingObject(f9);
            // physicsController.AddMovingObject(aV401);
            physicsController.AddGravityObject(earth);
        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
