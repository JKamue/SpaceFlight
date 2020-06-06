using System.Collections.Generic;
using System.Drawing;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    class RocketSpritePiece
    {
        public readonly List<PointF> Points;
        public readonly SolidBrush Brush;

        public RocketSpritePiece(List<PointF> points, SolidBrush brush)
        {
            Points = points;
            Brush = brush;
        }
    }
}
