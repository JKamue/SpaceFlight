using System;
using SpaceFlight.Screen;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Other;
using SpaceFlight.Game;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen.Calculator;
using Timer = System.Windows.Forms.Timer;

namespace SpaceFlight
{
    public partial class SimulationScreen : Form
    {
        public SimulationScreen()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Left = 550;
            Top = 5;
            new Game.Game(SimulationPanel, "all-rockets-earth");

            // Make the other screens owned by the SimulationScreen
            FormCollection openForms = Application.OpenForms;
            foreach (Form f in openForms)
            {
                this.AddOwnedForm(f);
            }
        }
    }
}
