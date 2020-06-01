using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        public List<RocketSpritePiece> GetPointList(PointF pos, int h, IProjectionCalculator ppCalc, AngularCalculator aCalc)
        {
            var list = new List<RocketSpritePiece>();

            var w = getWidth(h);
            var points = new List<PointF>();
            points.Add(ProjectedPoint(pos.X, pos.Y + h / 2, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + w / 2, pos.Y + h / 4, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + w / 2, pos.Y - h / 2, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - w / 2, pos.Y - h / 2, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - w / 2, pos.Y + h / 4, ppCalc, aCalc));

            var piece1 = new RocketSpritePiece(points, new SolidBrush(Color.Black));
            list.Add(piece1);

            points = new List<PointF>();
            points.Add(ProjectedPoint(pos.X - w / 2, pos.Y + h / 6, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + w / 2, pos.Y + h / 6, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X + w / 2, pos.Y - h / 6, ppCalc, aCalc));
            points.Add(ProjectedPoint(pos.X - w / 2, pos.Y - h / 6, ppCalc, aCalc));


            var piece2 = new RocketSpritePiece(points, new SolidBrush(Color.Gray));
            list.Add(piece2);

            return list;
        }

        private PointF ProjectedPoint(float x, float y, IProjectionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(new PointF(x, y)));
        }

        private int getWidth(float height) => (int)Math.Round(1F / 3F * height);
    }
}
