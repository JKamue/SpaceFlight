using System.Drawing;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    public class ThrustArea
    {
        public PointF Start;
        public PointF Stop;
        public PointF Middle;

        public ThrustArea(PointF start, PointF stop, PointF middle)
        {
            Start = start;
            Stop = stop;
            Middle = middle;
        }
    }
}
