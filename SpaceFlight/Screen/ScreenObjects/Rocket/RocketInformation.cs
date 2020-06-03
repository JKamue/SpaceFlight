using SpaceFlight.Screen.ScreenObjects.Rocket.Sprites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpaceFlight.Screen.ScreenObjects.Rocket
{
    class RocketInformation
    {
        public string Model { get; }
        public string Variant { get;  }
        public string Manufacturer { get; }
        public List<string> Names { get; }
        public float Height { get; }
        public float Width { get; }
        public float Thrust { get; }
        public float Weight { get; }
        public float FuelWeight { get; }
        public List<RocketSpritePiece> Sprite { get;  }


        public static RocketInformation LoadFromName(string name)
        {
            return JsonConvert.DeserializeObject<RocketInformation>(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/Rockets/falcon-9-1.2.json"));
        }

        public RocketInformation(string model, string variant, string manufacturer, List<string> names, float height, float width,
            float thrust, float weight, float fuelWeight, List<RocketSpritePiece> sprite)
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
        }

        public RocketSprite GetRocketSprite() =>  new RocketSprite(Height, Width, Sprite);
    }
}
