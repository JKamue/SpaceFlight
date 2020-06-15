using System;
using SpaceFlight.Screen;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Calculator;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        private readonly ScreenController _closeDistanceScreen;
        private readonly Timer _keyStatusTimer;

        public SimulationScreen()
        {
            InitializeComponent();
            this.KeyDown += KeyStatus.KeyDownHandler;
            this.KeyUp += KeyStatus.KeyUpHander;

            // Load controllers
            _closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            var physicsController = new PhysicsController(10, lblDebugDistance);
            var zeroAngle = Angle.FromDegrees(0);

            // Setup Key Status Timer
            _keyStatusTimer = new Timer();
            _keyStatusTimer.Interval = 100;
            _keyStatusTimer.Tick += CheckKeyStatus;
            _keyStatusTimer.Start();

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
            _closeDistanceScreen.AddPanelObject(earth);
            //closeDistanceScreen.SetMainObject(f9);
            _closeDistanceScreen.SetMainObject(v2);
            //closeDistanceScreen.SetMainObject(aV401);

            // Set Physic objects
            //physicsController.AddMovingObject(f9);
            physicsController.AddMovingObject(v2);
            //physicsController.AddMovingObject(aV401);
            physicsController.AddGravityObject(earth);
        }

        private void CheckKeyStatus(object sender, EventArgs e)
        {
            _closeDistanceScreen.ShowInfo = KeyStatus.IsPressed(73);

            if (KeyStatus.IsPressed(37))
                _closeDistanceScreen.ChangeMainObjectAngle(-1F);

            if (KeyStatus.IsPressed(39))
                _closeDistanceScreen.ChangeMainObjectAngle(1F);

        }
    }
}
