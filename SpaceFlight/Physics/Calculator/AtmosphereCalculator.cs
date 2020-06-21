using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceFlight.Physics.Calculator
{
    public class AtmosphereCalculator
    {
        // Using U.S. Standard Atmosphere Air Properties https://www.engineeringtoolbox.com/standard-atmosphere-d_604.html
        public static double CalculateAirDensityAtAltitude(double altitude)
        {

            // Sorry for this
            var densityAtAltitude = new Dictionary<Func<double, bool>, double>
            {
                { x => x < 0, 0},
                { x => x < 1000, 1.225},
                { x => x < 2000, 1.112},
                { x => x < 3000, 1.007},
                { x => x < 4000, 0.9093},
                { x => x < 5000, 0.8194},
                { x => x < 6000, 0.7364},
                { x => x < 7000, 0.6601},
                { x => x < 8000, 0.5900},
                { x => x < 9000, 0.5258},
                { x => x < 10000, 0.4671},
                { x => x < 15000, 0.4135},
                { x => x < 20000, 0.1948},
                { x => x < 25000, 0.08891},
                { x => x < 30000, 0.04008},
                { x => x < 40000, 0.01841},
                { x => x < 50000, 0.003996},
                { x => x < 60000, 0.001027},
                { x => x < 70000, 0.0003097},
                { x => x < 80000, 0.00008283},
                { x => x < 90000, 0.00001846},
                { x => x >= 90000, 0},
            };

            return densityAtAltitude.First(sw => sw.Key(altitude)).Value;
        }
    }
}
