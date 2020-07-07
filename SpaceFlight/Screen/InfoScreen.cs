using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Screen
{
    partial class InfoScreen : Form
    {
        private readonly List<Rocket> _rockets;
        private readonly List<Terrain> _planets;
        private readonly ScreenController _screen;
        private readonly ForceDrawer _forceDrawer;
        private Timer Ticker = new Timer();

        private int lastSelected = -1;

        public InfoScreen(List<Rocket> rockets, List<Terrain> planets, ScreenController screen)
        {
            InitializeComponent();
            _rockets = rockets;
            _planets = planets;
            _screen = screen;

            _forceDrawer = new ForceDrawer(pnlForcesScreen);

            StartPosition = FormStartPosition.Manual;
            Left = 40;
            Top = 5;

            Ticker.Interval = 50;
            Ticker.Tick += UpdateDisplay;
            Ticker.Start();

            cbxSelectRocket.DataSource = _rockets;
        }

        public void UpdateDisplay(object sender, EventArgs e)
        {
            SelectRightRocket();
            var rocket = GetMainObject();
            if (rocket is null)
                return;

            DisplayInformation(rocket);
            DisplayStats(rocket);
            DisplayLocation(rocket);
            QuerySliders(rocket);
            UpdateForceDrawer(rocket);
            lblDebugFps.Text = _screen.GetActualFramerate() + " fps";
        }

        public Rocket GetMainObject()
        {
            var screenObject = _screen.GetMainObject();

            if (screenObject.GetType() != _rockets[0].GetType())
                return null;

            return (Rocket) screenObject;
        }

        public void UpdateForceDrawer(Rocket rocket)
        {
            _forceDrawer.Drag = rocket.LastDrag;
            _forceDrawer.Gravity = rocket.LastGravity;
            var thrust = new Force(rocket._angle, rocket._engineRunning ? rocket._rocketInf.Thrust * rocket._thrustPercentage : 0);
            _forceDrawer.Thrust = thrust;
            _forceDrawer.ResultingForce = rocket.ResutlingForce;
            _forceDrawer.Speed = rocket.Speed;
            _forceDrawer.Redraw();
        }

        public void DisplayInformation(Rocket rocket)
        {
            var liftoffTime = rocket.LiftOffTime;
            var time = DateTime.Now;
            var diff = time - liftoffTime;
            lblClock.Text = "T+ " + diff.ToString(@"dd\.hh\:mm\:ss");
            lblRocketName.Text = rocket._name;
            lblInfModelVal.Text = rocket._rocketInf.Model + " " + rocket._rocketInf.Variant;
            lblInfManufacturerVal.Text = rocket._rocketInf.Manufacturer;
            lblInfHeightVal.Text = rocket._rocketInf.Height + "m";
        }

        public void SelectRightRocket()
        {
            if (cbxSelectRocket.SelectedIndex != lastSelected)
            {
                lastSelected = cbxSelectRocket.SelectedIndex;
                var rocket = (Rocket) cbxSelectRocket.SelectedItem;
                _screen.SetMainObject(rocket);
                sldCtrlThrust.Value = (int) Math.Round(rocket._thrustPercentage * 100);
                sldCtrlAngle.Value = (int) Math.Round(rocket.targetAngle.Degree - (rocket.targetAngle.Degree > 180 ? 360 : 0));
            }
        }

        public void DisplayStats(Rocket rocket)
        {
            var thrust = rocket._engineRunning ? rocket._rocketInf.Thrust * rocket._thrustPercentage : 0;
            lblStatThrustVal.Text = thrust + " kN";
            lblStatAccelerationVal.Text = Math.Round(rocket.Acceleration.Value, 8) + " m/s²";
            lblStatSpeedVal.Text = Math.Round(rocket.Speed.Value, 8) + " m/s";
            lblStatWeightVal.Text = Math.Round(rocket.Mass.Value, 2 ) + " kg";

            var fuelPercent = Math.Round(rocket._restFuelWeight / rocket._rocketInf.FuelWeight * 100);
            lblStatFuelWeightVal.Text = Math.Round(rocket._restFuelWeight, 2) + " kg (" + fuelPercent + "%)";


            lblStatGravityVal.Text = Math.Round(rocket.LastGravity.Value,4) + " kN";
            lblStatDragVal.Text = Math.Round(rocket.LastDrag.Value, 4) + " kN";
        }

        public void DisplayLocation(Rocket rocket)
        {
            var distance = 0F;
            foreach (var planet in _planets)
            {
                var newDistance = PointCalculator.Distance(rocket.Location, planet.Location);
                if (newDistance > distance)
                    distance = newDistance - (float) planet.Diameter;
            }

            lblLocClosestVal.Text = Math.Round(distance) + " m";
            lblLocAngleVal.Text = Math.Round(rocket._angle.Degree - ((rocket._angle.Degree > 180) ? 360 : 0), 1) + "°";
            lblLocCoordsVal.Text = Math.Round(rocket.Location.X) + " | " + Math.Round(rocket.Location.Y);
        }

        public void QuerySliders(Rocket rocket)
        {
            rocket.targetAngle = Angle.FromDegrees(sldCtrlAngle.Value);
            rocket.SetThrustPercentage(((float) sldCtrlThrust.Value) / 100F);
            lblSldAngleVal.Text = sldCtrlAngle.Value + "°";
            lblSldThrustVal.Text = sldCtrlThrust.Value + "%";
        }
    }
}
