using System.Drawing;
using System.Security;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Objects.Rocket
{
    class RocketDto
    {
        public PointF Location;
        public Speed Speed;
        public Angle Angle;
        public float ThrustPercentage;
        public string Type;

        public RocketDto(PointF location, Vector speed, Angle angle, float thrustPercentage, string type)
        {
            Location = location;
            Speed = new Speed(speed.Angle, speed.Value);
            Angle = angle;
            ThrustPercentage = thrustPercentage;
            Type = type;
        }
    }
}
