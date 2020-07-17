using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Objects.Rocket;
using SpaceFlight.Objects.Terrain;
using SpaceFlight.Physics.Other;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Physics.Calculator
{
    class OrbitPredictionCalculator
    {
        public static List<PointM> GetPredictedPointList(Rocket rocket, List<Terrain> planets, TimeSpan predictionLength, bool thrust)
        {
            var pointList = new List<PointM>();
            var position = rocket.Location;
            var speed = rocket.Speed;
            var mass = rocket.Mass;
            var fuelWeight = rocket._restFuelWeight;
            while (predictionLength > TimeSpan.Zero)
            {
                predictionLength -= new TimeSpan(0,0,0,10);

                var forces = new Force(Angle.Zero, 0);
                if (thrust)
                {
                    forces = new Force(speed.Angle, rocket._rocketInf.Thrust * rocket._thrustPercentage);

                    var burnedFuelPerSec = rocket._rocketInf.FuelWeight / rocket._rocketInf.BurnTime;
                    var burnedFuel = 10 * burnedFuelPerSec * rocket._thrustPercentage;

                    fuelWeight -= burnedFuel;
                    var massValue = fuelWeight + rocket._rocketInf.Weight - rocket._rocketInf.FuelWeight;
                    if (massValue <= 0 || rocket._thrustPercentage == 0 || fuelWeight < 0)
                    {
                        break;
                    }
                    mass = new Mass(massValue);
                }
                
                foreach (var planet in planets)
                {
                    var distance = PointCalculator.Distance(position, planet.Location);

                    if (distance < planet.Diameter)
                    {
                        predictionLength = TimeSpan.MinValue;
                        break;
                    }

                    var angle = PointCalculator.CalculateAngle(position, planet.Location);
                    forces += GravityCalculator.CalculateGravity(mass, planet.Mass, distance, angle);
                }

                var acceleration = forces.GetAcceleration(mass);
                speed += acceleration.GetSpeed(new TimeSpan(0, 0, 0, 10));

                if (speed.Value > 50000)
                    break;

                var flownDistance = speed.GetDistance(new TimeSpan(0, 0, 0, 10)).CalculateXAndY();
                position.X += flownDistance.X;
                position.Y += flownDistance.Y;

                pointList.Add(position);
            }

            return pointList;
        }
    }
}
