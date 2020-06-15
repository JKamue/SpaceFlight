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
            var f9_inf = RocketInformation.LoadFromName("falcon-9-1.2");
            var aV401_inf = RocketInformation.LoadFromName("atlas-V-401");
            var v2_inf = RocketInformation.LoadFromName("vergeltungswaffe-2");

            var f9 = new Rocket(new PointF(0, 0), new Mass(f9_inf.Weight), new Force(zeroAngle, f9_inf.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), zeroAngle, 1F, f9_inf);
            var aV401 = new Rocket(new PointF(30, 0), new Mass(aV401_inf.Weight), new Force(zeroAngle, aV401_inf.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), zeroAngle, 1F, aV401_inf);
            var v2 = new Rocket(new PointF(0, 0), new Mass(v2_inf.Weight), new Force(zeroAngle, v2_inf.Thrust),
                new Acceleration(zeroAngle, 0), new Speed(zeroAngle, 0), Angle.FromDegrees(45), 1F, v2_inf);


            // Load Screen objects
            closeDistanceScreen.AddPanelObject(earth);
            //closeDistanceScreen.SetMainObject(f9);
            closeDistanceScreen.SetMainObject(v2);
            //closeDistanceScreen.SetMainObject(aV401);

            // Set Physic objects
            //physicsController.AddMovingObject(f9);
            physicsController.AddMovingObject(v2);
            //physicsController.AddMovingObject(aV401);
            physicsController.AddGravityObject(earth);
        }

        private void SimulationScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 105)
                closeDistanceScreen.ShowInfo = !closeDistanceScreen.ShowInfo;

        }
    }
}
