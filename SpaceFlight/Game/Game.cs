using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using SpaceFlight.Objects;
using SpaceFlight.Objects.Calculator;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;
using SpaceFlight.Screen.Controllers;
using SpaceFlight.Screen.Forms;

namespace SpaceFlight.Game
{
    class Game
    {
        private readonly ScreenController _closeDistanceScreen;
        private readonly OrbitScreenController _orbitScreenController;
        private readonly PhysicsController _physicsController;
        private readonly CollisionDetector _collisionDetector;

        private readonly InfoScreen _infoScreen;
        private readonly OrbitScreen _orbitScreen;

        private ScreenObjectCollection _objects = new ScreenObjectCollection();

        public Game(Panel simulationPanel, string levelName)
        {
            // Load Level
            var level = LoadFromName(levelName);
            LoadPlanets(level.Planets);
            LoadRockets(level.Rockets);

            // Load controllers
            _closeDistanceScreen = new ScreenController(simulationPanel, _objects, Color.NavajoWhite, 3);
            _physicsController = new PhysicsController(_objects, 10);
            _collisionDetector = new CollisionDetector(_objects);

            // Show info Screen
            _infoScreen = new InfoScreen(_objects, _closeDistanceScreen);
            _infoScreen.Show();

            // Show orbit Screen
            _orbitScreen = new OrbitScreen();
            _orbitScreen.Show();

            // Create orbit controller
            _orbitScreenController = new OrbitScreenController(_orbitScreen.GetPanel(), _objects);
        }

        private void LoadRockets(List<RocketDto> rockets)
        {
            foreach (var rDto in rockets)
            {
                var inf = RocketInformation.LoadFromName(rDto.Type);
                var rocket = new Rocket(rDto.Location, new Force(Angle.Zero, 0), new Acceleration(Angle.Zero, 0), rDto.Speed, rDto.Angle, rDto.ThrustPercentage, inf);
                _objects.Add(rocket);
            }
        }

        private void LoadPlanets(List<TerrainDto> planets)
        {
            foreach (var pDto in planets)
            {
                var planet = new Terrain(pDto.Position, pDto.Radius, pDto.Color, new Mass(pDto.Mass));
                _objects.Add(planet);
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
