using System.Drawing;
using SpaceFlight.Physics;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Objects.Rocket
{
    class RocketDto
    {
        public PointF Location;
        public Force Force;
        public Acceleration Acceleration;
        public Speed Speed;
        public Angle Angle;
        public float ThrustPercentage;
        public string Type;

        public RocketDto(PointF location, Force force, Acceleration acceleration, Speed speed, Angle angle, float thrustPercentage, string type)
        {
            Location = location;
            Force = force;
            Acceleration = acceleration;
            Speed = speed;
            Angle = angle;
            ThrustPercentage = thrustPercentage;
            Type = type;
        }
    }
}
