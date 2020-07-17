using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Screen;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    class RocketSpritePiece
    {
        public readonly List<Point> Points;
        public readonly SolidBrush Brush;

        public RocketSpritePiece(List<Point> points, SolidBrush brush)
        {
            Points = points;
            Brush = brush;
        }
    }
}
