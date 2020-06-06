using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.ScreenObjects.Rocket.Sprites
{
    public class ThrustArea
    {
        public PointF Start;
        public PointF Stop;

        public ThrustArea(PointF start, PointF stop)
        {
            Start = start;
            Stop = stop;
        }
    }
}
