using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Other;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight
{
    class Game
    {
        private readonly ScreenController _closeDistanceScreen;
        private readonly Timer _keyStatusTimer;

        public Game(Panel SimulationPanel, Label lblDebug, Label lblDebugDistance)
        {

            // Load controllers
            _closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            var physicsController = new PhysicsController(10, lblDebugDistance);

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

            var f9 = new Rocket(new PointF(0, 0), new Mass(f9_inf.Weight), new Force(Angle.Zero, f9_inf.Thrust),
                new Acceleration(), new Speed(), Angle.Zero, 1F, f9_inf);
            var aV401 = new Rocket(new PointF(30, 0), new Mass(aV401_inf.Weight), new Force(Angle.Zero, aV401_inf.Thrust),
                new Acceleration(), new Speed(), Angle.Zero, 1F, aV401_inf);
            var v2 = new Rocket(new PointF(0, 0), new Mass(v2_inf.Weight), new Force(Angle.Zero, v2_inf.Thrust),
                new Acceleration(), new Speed(), Angle.Zero, 1F, v2_inf);


            // Load Screen objects
            _closeDistanceScreen.AddPanelObject(earth);
            //_closeDistanceScreen.SetMainObject(f9);
            _closeDistanceScreen.SetMainObject(v2);
            //_closeDistanceScreen.SetMainObject(aV401);

            // Set Physic objects
            //physicsController.AddMovingObject(f9);
            physicsController.AddMovingObject(v2);
            //physicsController.AddMovingObject(aV401);
            physicsController.AddGravityObject(earth);

            var test = new DragProperties(0.25, 0.41, 10, 100);
            string output = JsonConvert.SerializeObject(test, Formatting.Indented);
            DragProperties deserializedProduct = JsonConvert.DeserializeObject<DragProperties>(output);
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
