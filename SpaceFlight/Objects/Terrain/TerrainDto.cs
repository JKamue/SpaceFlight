using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Objects.Terrain
{
    class TerrainDto
    {
        public PointF Position;
        public float Radius;
        public Color Color;
        public float Mass;

        public TerrainDto(PointF position, float radius, Color color, float mass)
        {
            Position = position;
            Radius = radius;
            Color = color;
            Mass = mass;
        }
    }
}
