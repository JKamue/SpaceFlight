using System.Collections.Generic;
using System.Drawing;
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
                    var x = (decimal)pos.X + (decimal)spritePiecePoint.X;
                    var y = (decimal)pos.Y + (decimal)spritePiecePoint.Y;
                    calculatedSpritePieces.Add(TurnAndProject(x, y, ppCalc, aCalc));
                }
                spritePieces.Add(new RocketSpritePiece(calculatedSpritePieces, spritePiece.Brush));
            }

            return spritePieces;
        }

        public RectangleF GetBounds(PointF pos, AngularCalculator aCalc)
        {
            var points = GetBoundPointsList(pos, aCalc);
            return BoundsCalculator.CalculateBounds(points);
        }

        public List<PointF> GetBoundPointsList(PointF pos, AngularCalculator aCalc)
        {
            var hWidth = _width / 2;
            var hHeight = _height / 2;

            var points = new List<PointF>
            {
                aCalc.Turn(new PointF(pos.X - hWidth, pos.Y - hHeight)),
                aCalc.Turn(new PointF(pos.X + hWidth, pos.Y - hHeight)),
                aCalc.Turn(new PointF(pos.X + hWidth, pos.Y + hHeight)),
                aCalc.Turn(new PointF(pos.X - hWidth, pos.Y + hHeight))
            };

            return points;
        }

        private static PointF TurnAndProject(float x, float y, ProjectedPositionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(new PointF(x, y)));
        }

        private static PointF TurnAndProject(decimal x, decimal y, ProjectedPositionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(x, y));
        }
    }
}
