using System.Drawing;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Terrain
{
    class TerrainDto
    {
        public PointM Position;
        public decimal Radius;
        public Color Color;
        public decimal Mass;

        public TerrainDto(PointM position, decimal radius, Color color, decimal mass)
        {
            Position = position;
            Radius = radius;
            Color = color;
            Mass = mass;
        }
    }
}
