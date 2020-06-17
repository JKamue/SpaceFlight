using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Calculator
{
    public class AtmosphereCalculator
    {
        public static readonly double SeaLevelPressure = 101325;
        public static readonly double TemperatureLapseRate = 0.00976;
        public static readonly double SeaLevelStandardTemperature = 288.16;
        public static readonly double EarthSurfaceGravitationalAcceleration	 = 9.80665;
        public static readonly double DryAirMolarMass = 0.02896968;
        public static readonly double UniversalGasConstant = 8.314462618;

        

        public static double CalculatePressureAtAltitude(double altitude)
        {
            if (altitude > 80000)
                return 0;

            if (altitude > 28950)
                return 0.1;

            if (altitude < 0)
                return 0;

            return SeaLevelPressure *
                   Math.Pow(
                       1 - (TemperatureLapseRate * altitude) / SeaLevelStandardTemperature,
                       (EarthSurfaceGravitationalAcceleration * DryAirMolarMass) /
                       (UniversalGasConstant * TemperatureLapseRate));
        }
    }
}
