using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SpaceFlight.Objects.Rocket.Sprites;
using SpaceFlight.Physics.Other;

namespace SpaceFlight.Objects.Rocket
{
    class RocketInformation
    {
        public string Model { get; }
        public string Variant { get;  }
        public string Manufacturer { get; }
        public List<string> Names { get; }
        public decimal Height { get; }
        public decimal Width { get; }
        public decimal Thrust { get; }
        public decimal Weight { get; }
        public decimal FuelWeight { get; }
        public decimal BurnTime { get; }
        public DragProperties DragProperties { get; }
        public List<RocketSpritePiece> Sprite { get; }

        public List<ThrustArea> ThrustAreas;


        public static RocketInformation LoadFromName(string name)
        {
            var path = $"{Directory.GetCurrentDirectory()}/Data/Rockets/{name}.json";
            if (!File.Exists(path))
                throw new FileNotFoundException("Configuration file for " + name + " could not be found!");

            return JsonConvert.DeserializeObject<RocketInformation>(File.ReadAllText(path));
        }

        public RocketInformation(string model, string variant, string manufacturer, List<string> names, decimal height, decimal width,
            decimal thrust, decimal weight, decimal fuelWeight, decimal burnTime, DragProperties dragProperties, List<RocketSpritePiece> sprite, List<ThrustArea> thrustAreas)
        {
            Model = model;
            Variant = variant;
            Manufacturer = manufacturer;
            Names = names;
            Height = height;
            Width = width;
            Thrust = thrust;
            Weight = weight;
            FuelWeight = fuelWeight;
            Sprite = sprite;
            ThrustAreas = thrustAreas;
            BurnTime = burnTime;
            DragProperties = dragProperties;
        }

        public RocketSprite GetRocketSprite() =>  new RocketSprite(Height, Width, Sprite);
    }
}
