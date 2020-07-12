using System;
using System.Collections.Generic;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects
{
    class ScreenObjectCollection
    {
        public List<Rocket.Rocket> Rockets { get; private set; }
        public List<Terrain.Terrain> Terrains { get; private set; }
        public List<IScreenObject> ScreenObjects { get; private set; }
        public Rocket.Rocket MainObject = null;

        public ScreenObjectCollection()
        {
            Rockets = new List<Rocket.Rocket>();
            Terrains = new List<Terrain.Terrain>();
            ScreenObjects = new List<IScreenObject>();
        }

        public void Add(Rocket.Rocket rocket)
        {
            ScreenObjects.Add(rocket);
            Rockets.Add(rocket);
            MainObject = rocket;
        }

        public void Add(Terrain.Terrain terrain)
        {
            ScreenObjects.Add(terrain);
            Terrains.Add(terrain);
        }

        public void Remove(Rocket.Rocket rocket)
        {
            ScreenObjects.Remove(rocket);
            Rockets.Remove(rocket);
        }

        public void Remove(Terrain.Terrain terrain)
        {
            ScreenObjects.Remove(terrain);
            Terrains.Remove(terrain);
        }
    }
}
