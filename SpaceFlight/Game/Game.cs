using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Game
{
    class Game
    {
        private readonly ScreenController _closeDistanceScreen;
        private readonly PhysicsController _physicsController;
        private readonly InfoScreen _infoScreen;

        private List<Rocket> _rockets = new List<Rocket>();
        private List<Terrain> _planets = new List<Terrain>();

        public Game(Panel simulationPanel, string levelName)
        {
            // Load controllers
            _closeDistanceScreen = new ScreenController(simulationPanel, Color.NavajoWhite, 3);
            _physicsController = new PhysicsController(10);

            // Load Level
            var level = LoadFromName(levelName);
            LoadPlanets(level.Planets);
            LoadRockets(level.Rockets);

            // Show info Screen
            _infoScreen = new InfoScreen(_rockets, _planets, _closeDistanceScreen);
            _infoScreen.Show();
        }

        private void LoadRockets(List<RocketDto> rockets)
        {
            foreach (var rDto in rockets)
            {
                var inf = RocketInformation.LoadFromName(rDto.Type);
                var rocket = new Rocket(rDto.Location, rDto.Force, rDto.Acceleration, rDto.Speed, rDto.Angle, rDto.ThrustPercentage, inf);
                _closeDistanceScreen.SetMainObject(rocket);
                _physicsController.AddMovingObject(rocket);
                _rockets.Add(rocket);
            }
        }

        private void LoadPlanets(List<TerrainDto> planets)
        {
            foreach (var pDto in planets)
            {
                var planet = new Terrain(pDto.Position, pDto.Radius, pDto.Color, new Mass(pDto.Mass));
                _closeDistanceScreen.AddPanelObject(planet);
                _physicsController.AddGravityObject(planet);
                _planets.Add(planet);
            }
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
