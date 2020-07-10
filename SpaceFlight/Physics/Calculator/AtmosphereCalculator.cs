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

            bool altitude < 10000 = true;

            if (condition)
            {
                var densityAtAltitude = 1,2526 * 0,9999 ^ altitude;
            }
            bool altitude > 10000 and altitude < 300000  = true;

            if (condition)
            {
                var densityAtAltitude = 1.9971 * 0,9998 ^ altitude;
            }
            bool altitude > 30000 and altitude< 80000 = true;

            if (condition)
            {
                var densityAtAltitude = 0,9786 * 0.9999 ^ altitude;
            }

            bool altitude > 80000 = true;

            if (condition)
            {
                var densityAtAltitude = 0;
            }
        }






 





            return densityAtAltitude.First(sw => sw.Key(altitude)).Value;
        }
    }
}

