using System.Drawing;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    public class ThrustArea
    {
        public PointM Start;
        public PointM Stop;

        public ThrustArea(PointM start, PointM stop)
        {
            Start = start;
            Stop = stop;
        }
    }
}
