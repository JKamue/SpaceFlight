using System.Drawing;

namespace SpaceFlight.Objects.Rocket.Sprites
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
