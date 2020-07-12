using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFlight.Objects;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Calculator;
using SpaceFlight.Physics.Other;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Screen
{
    partial class InfoScreen : Form
    {
        private readonly ScreenObjectCollection _objects;
        private readonly ScreenController _screen;
        private readonly ForceDrawer _forceDrawer;
        private Timer Ticker = new Timer();

        private int playBackSpeed = 1;
        private int lastSelected = -1;

        public InfoScreen(ScreenObjectCollection objects, ScreenController screen)
        {
            InitializeComponent();
            _objects = objects;
            _screen = screen;

            _forceDrawer = new ForceDrawer(pnlForcesScreen);

            StartPosition = FormStartPosition.Manual;
            Left = 40;
            Top = 5;

            Ticker.Interval = 50;
            Ticker.Tick += UpdateDisplay;
            Ticker.Start();

            cbxSelectRocket.DataSource = _objects.Rockets;
        }

        public void UpdateDisplay(object sender, EventArgs e)
        {
            cbxSelectRocket.DataSource = _objects.Rockets;
            SelectRightRocket();
            var rocket = _objects.MainObject;
            if (rocket is null)
                return;

            DisplayInformation(rocket);
            DisplayStats(rocket);
            DisplayLocation(rocket);
            QuerySliders(rocket);
            UpdateForceDrawer(rocket);
            lblDebugFps.Text = _screen.GetActualFramerate() + " fps";
        }

        public void UpdateForceDrawer(Rocket rocket)
        {
            _forceDrawer.Drag = rocket.DragForces;
            _forceDrawer.Gravity = rocket.GravityForces;
            var thrust = new Force(rocket._angle, rocket._engineRunning ? rocket._rocketInf.Thrust * rocket._thrustPercentage : 0);
            _forceDrawer.Thrust = thrust;
            _forceDrawer.ResultingForce = rocket.ResutlingForce;
            _forceDrawer.Speed = rocket.Speed;
            _forceDrawer.Redraw();
        }

        public void DisplayInformation(Rocket rocket)
        {
            var liftoffTime = rocket.LiftOffTime;
            var time = TimeKeeper.Now();
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
                _objects.MainObject = rocket;
                sldCtrlThrust.Value = (int) Math.Round(rocket._thrustPercentage * 100);
                sldCtrlAngle.Value = (int) Math.Round(rocket.targetAngle.Degree - (rocket.targetAngle.Degree > 180 ? 360 : 0));
            }
        }

        public void DisplayStats(Rocket rocket)
        {
            var thrust = rocket._engineRunning ? rocket._rocketInf.Thrust * rocket._thrustPercentage : 0;

            var resultingDrag = new Force(Angle.Zero, 0);
            foreach (var drag in rocket.DragForces)
                resultingDrag = drag + resultingDrag;


            var resultingGravity = new Force(Angle.Zero, 0);
            foreach (var garvity in rocket.GravityForces)
                resultingGravity = garvity + resultingGravity;

            var forcesWithoutGravity = resultingDrag + new Force(rocket._angle, thrust);
            var g = Math.Round(forcesWithoutGravity.GetAcceleration(rocket.Mass).Value / 9.80665, 1);

            lblStatThrustVal.Text = Math.Round(thrust / 1000,4) + " kN";
            lblStatAccelerationVal.Text = Math.Round(rocket.Acceleration.Value, 4) + " m/s²  (" + g + "g)";
            lblStatSpeedVal.Text = Math.Round(rocket.Speed.Value, 8) + " m/s";
            lblStatWeightVal.Text = Math.Round(rocket.Mass.Value, 2 ) + " kg";

            var fuelPercent = Math.Round(rocket._restFuelWeight / rocket._rocketInf.FuelWeight * 100);
            lblStatFuelWeightVal.Text = Math.Round(rocket._restFuelWeight, 2) + " kg (" + fuelPercent + "%)";

            lblStatGravityVal.Text = Math.Round(resultingGravity.Value / 1000,4) + " kN";
            lblStatDragVal.Text = Math.Round(resultingDrag.Value / 1000, 4) + " kN";
        }

        public void DisplayLocation(Rocket rocket)
        {
            var distance = 0F;
            foreach (var planet in _objects.Terrains)
            {
                var newDistance = PointCalculator.Distance(rocket.Location, planet.Location);
                if (newDistance > distance)
                    distance = newDistance - (float) planet.Diameter;
            }

            lblLocClosestVal.Text = Math.Round(distance) + " m";
            lblLocAngleVal.Text = Math.Round(rocket._angle.Degree - ((rocket._angle.Degree > 180) ? 360 : 0), 1) + "°";
            lblLocCoordsVal.Text = Math.Round(rocket.Location.X) + " | " + Math.Round(rocket.Location.Y);

            _screen.Color = CalcColor(distance);
        }

        public Color CalcColor(float altitude)
        {
            var factor = 0f;
            if (altitude < 80000 && altitude > 0)
            {
                factor = (altitude - 0) / (80000 - 0) * (0 - 1) + 1;
            }
            else if (altitude <= 0)
            {
                factor = 1f;
            }

            // https://stackoverflow.com/a/2011839
            var max = Color.NavajoWhite;
            var min = Color.FromArgb(50, 50, 50);

            var r = min.R + (int)((max.R - min.R) * factor);
            var g = min.G + (int)((max.G - min.G) * factor);
            var b = min.B + (int)((max.B - min.B) * factor);
            return Color.FromArgb(r, g, b);
        }

        public void QuerySliders(Rocket rocket)
        {
            rocket.targetAngle = Angle.FromDegrees(sldCtrlAngle.Value);
            rocket.SetThrustPercentage(((float) sldCtrlThrust.Value) / 100F);
            lblSldAngleVal.Text = sldCtrlAngle.Value + "°";
            lblSldThrustVal.Text = sldCtrlThrust.Value + "%";
        }

        private void InfoScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "You really want to quit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnSetPlaybackSpeed_Click(object sender, EventArgs e)
        {
            switch (playBackSpeed)
            {
                case 1:
                    TimeKeeper.TimeConstant = 2;
                    break;
                case 2:
                    TimeKeeper.TimeConstant = 5;
                    break;
                case 3:
                    TimeKeeper.TimeConstant = 10;
                    break;
                case 4:
                    TimeKeeper.TimeConstant = 25;
                    break;
                case 5:
                    TimeKeeper.TimeConstant = 50;
                    break;
                case 6:
                    TimeKeeper.TimeConstant = 100;
                    break;
                case 7:
                    playBackSpeed = -1;
                    TimeKeeper.TimeConstant = 0;
                    break;
            }

            playBackSpeed++;

            btnSetPlaybackSpeed.Text = TimeKeeper.TimeConstant + "X";
        }
    }
}
