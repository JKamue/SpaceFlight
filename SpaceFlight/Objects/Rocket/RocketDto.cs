using System.Drawing;
using System.Security;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Rocket
{
    class RocketDto
    {
        public PointM Location;
        public Speed Speed;
        public Angle Angle;
        public decimal ThrustPercentage;
        public string Type;

        public RocketDto(PointM location, Vector speed, Angle angle, decimal thrustPercentage, string type)
        {
            Location = location;
            Speed = new Speed(speed.Angle, speed.Value);
            Angle = angle;
            ThrustPercentage = thrustPercentage;
            Type = type;
        }
    }
}
