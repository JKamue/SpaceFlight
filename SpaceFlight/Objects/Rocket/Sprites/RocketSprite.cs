using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    class RocketSprite
    {
        private readonly float _height;
        private readonly float _width;
        private readonly List<RocketSpritePiece> _spritePieces;

        public RocketSprite(float height, float width, List<RocketSpritePiece> spritePieces)
        {
            this._height = height;
            this._width = width;
            this._spritePieces = spritePieces;
        }

        public List<RocketSpritePiece> CalculatePolygons(PointF pos, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            var spritePieces = new List<RocketSpritePiece>();
            foreach (var spritePiece in _spritePieces)
            {
                var calculatedSpritePieces = new List<PointF>();
                foreach (var spritePiecePoint in spritePiece.Points)
                {
                    var x = pos.X + spritePiecePoint.X;
                    var y = pos.Y + spritePiecePoint.Y;
                    calculatedSpritePieces.Add(TurnAndProject(x, y, ppCalc, aCalc));
                }
                spritePieces.Add(new RocketSpritePiece(calculatedSpritePieces, spritePiece.Brush));
            }

            return spritePieces;
        }

        public RectangleF GetBounds(PointF pos, AngularCalculator aCalc)
        {
            var hWidth = _width / 2;
            var hHeight = _height / 2;

            var points = new List<PointF>();
            points.Add(aCalc.Turn(new PointF(pos.X - hWidth, pos.Y - hHeight)));
            points.Add(aCalc.Turn(new PointF(pos.X + hWidth, pos.Y - hHeight)));
            points.Add(aCalc.Turn(new PointF(pos.X + hWidth, pos.Y + hHeight)));
            points.Add(aCalc.Turn(new PointF(pos.X - hWidth, pos.Y + hHeight)));

            return BoundsCalculator.CalculateBounds(points);
        }

        private PointF TurnAndProject(float x, float y, ProjectedPositionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(new PointF(x, y)));
        }
    }
}
