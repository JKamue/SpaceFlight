using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.ScreenObjects.Rocket.Sprites
{
    class BasicRocketSprite : IRocketSprite
    {
        public RectangleF GetBounds(PointF pos, int h)
        {
            var w = getWidth(h);
            return new RectangleF(pos.X - w / 2, pos.Y - h / 2, w, h);
        }

        public List<PointF> GetPointList(PointF pos, int h)
        {
            var w = getWidth(h);
            var points = new List<PointF>();
            points.Add(new PointF(pos.X, pos.Y + h / 2));
            points.Add(new PointF(pos.X + w / 2, pos.Y + h / 4));
            points.Add(new PointF(pos.X + w / 2, pos.Y - h / 2));
            points.Add(new PointF(pos.X - w / 2, pos.Y - h / 2));
            points.Add(new PointF(pos.X - w / 2, pos.Y + h / 4));

            return points;
        }

        private int getWidth(float height) => (int)Math.Round(1F / 3F * height);
    }
}
