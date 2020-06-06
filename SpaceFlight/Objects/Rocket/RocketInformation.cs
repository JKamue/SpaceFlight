﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SpaceFlight.Objects.Rocket.Sprites;

namespace SpaceFlight.Objects.Rocket
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
        public float BurnTime { get; }
        public List<RocketSpritePiece> Sprite { get; }

        public List<ThrustArea> ThrustAreas;


        public static RocketInformation LoadFromName(string name)
        {
            var path = $@"{Directory.GetCurrentDirectory()}/Rockets/{name}.json";
            if (!File.Exists(path))
                throw new FileNotFoundException("Configuration file for " + name + " could not be found!");

            return JsonConvert.DeserializeObject<RocketInformation>(File.ReadAllText($@"{Directory.GetCurrentDirectory()}/Rockets/{name}.json"));
        }

        public RocketInformation(string model, string variant, string manufacturer, List<string> names, float height, float width,
            float thrust, float weight, float fuelWeight, float burnTime, List<RocketSpritePiece> sprite, List<ThrustArea> thrustAreas)
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
        }

        public RocketSprite GetRocketSprite() =>  new RocketSprite(Height, Width, Sprite);
    }
}