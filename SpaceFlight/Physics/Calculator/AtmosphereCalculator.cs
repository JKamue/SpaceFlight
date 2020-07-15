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
            double densityAtAltitude = 0;

            if (altitude < 0)
            {
                densityAtAltitude = 0;
            }
            else if (altitude >= 0 && altitude < 10000)  
            {
                densityAtAltitude = 1.24958083 * Math.Pow(0.99989155, altitude);
            }
            else if (altitude < 30000)
            {
                densityAtAltitude = 1.99710635 * Math.Pow(0.99984392, altitude);
            }
            else if (altitude < 80000) 
            {
                densityAtAltitude = 0.97855729 * Math.Pow(0.99986472, altitude);
            }

            return densityAtAltitude;
        }
    }
}
