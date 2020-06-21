using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace SpaceFlight.Game
{
    class Game
    {
        private readonly ScreenController _closeDistanceScreen;
        private readonly PhysicsController _physicsController;
        private readonly Timer _keyStatusTimer;

        public Game(Panel SimulationPanel, Label lblDebug, Label lblDebugDistance, string levelName)
        {
            // Load controllers
            _closeDistanceScreen = new ScreenController(SimulationPanel, Color.NavajoWhite, 3, lblDebug);
            _physicsController = new PhysicsController(10, lblDebugDistance);

            // Setup Key Status Timer
            _keyStatusTimer = new Timer();
            _keyStatusTimer.Interval = 100;
            _keyStatusTimer.Tick += CheckKeyStatus;
            _keyStatusTimer.Start();

            // Load Level
            var level = LoadFromName(levelName);
            LoadPlanets(level.Planets);
            LoadRockets(level.Rockets);
        }

        private void LoadRockets(List<RocketDto> rockets)
        {
            foreach (var rDto in rockets)
            {
                var inf = RocketInformation.LoadFromName(rDto.Type);
                var rocket = new Rocket(rDto.Location, rDto.Force, rDto.Acceleration, rDto.Speed, rDto.Angle, rDto.ThrustPercentage, inf);
                _closeDistanceScreen.SetMainObject(rocket);
                _physicsController.AddMovingObject(rocket);
            }
        }

        private void LoadPlanets(List<TerrainDto> planets)
        {
            foreach (var pDto in planets)
            {
                var planet = new Terrain(pDto.Position, pDto.Radius, pDto.Color, new Mass(pDto.Mass));
                _closeDistanceScreen.AddPanelObject(planet);
                _physicsController.AddGravityObject(planet);
            }
        }

        private void CheckKeyStatus(object sender, EventArgs e)
        {
            _closeDistanceScreen.ShowInfo = KeyStatus.IsPressed(73);

            if (KeyStatus.IsPressed(37))
                _closeDistanceScreen.ChangeMainObjectAngle(-1F);

            if (KeyStatus.IsPressed(39))
                _closeDistanceScreen.ChangeMainObjectAngle(1F);

        }

        private static GameDto LoadFromName(string name)
        {
            var path = $"{Directory.GetCurrentDirectory()}/Data/Levels/{name}.json";
            if (!File.Exists(path))
                throw new FileNotFoundException("Configuration file for " + name + " could not be found!");

            return JsonConvert.DeserializeObject<GameDto>(File.ReadAllText(path));
        }
    }
}
