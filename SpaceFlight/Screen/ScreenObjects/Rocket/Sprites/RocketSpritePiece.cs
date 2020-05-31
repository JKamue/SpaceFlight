using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.ScreenObjects.Rocket.Sprites
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
