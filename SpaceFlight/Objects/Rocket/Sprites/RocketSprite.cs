using System.Collections.Generic;
using System.Drawing;
using SpaceFlight.Screen;
using SpaceFlight.Screen.Calculator;
using SpaceFlight.Screen.Other;

namespace SpaceFlight.Objects.Rocket.Sprites
{
    class RocketSprite
    {
        private readonly decimal _height;
        private readonly decimal _width;
        private readonly List<RocketSpritePiece> _spritePieces;

        public RocketSprite(decimal height, decimal width, List<RocketSpritePiece> spritePieces)
        {
            this._height = height;
            this._width = width;
            this._spritePieces = spritePieces;
        }

        public List<RocketSpritePiece> CalculatePolygons(PointM pos, ProjectedPositionCalculator ppCalc, AngularCalculator aCalc)
        {
            var spritePieces = new List<RocketSpritePiece>();
            foreach (var spritePiece in _spritePieces)
            {
                var calculatedSpritePieces = new List<Point>();
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

        public RectangleM GetBounds(PointM pos, AngularCalculator aCalc)
        {
            var points = GetBoundPointsList(pos, aCalc);
            return BoundsCalculator.CalculateBounds(points);
        }

        public List<PointM> GetBoundPointsList(PointM pos, AngularCalculator aCalc)
        {
            var hWidth = _width / 2;
            var hHeight = _height / 2;

            var points = new List<PointM>
            {
                aCalc.Turn(new PointM(pos.X - hWidth, pos.Y - hHeight)),
                aCalc.Turn(new PointM(pos.X + hWidth, pos.Y - hHeight)),
                aCalc.Turn(new PointM(pos.X + hWidth, pos.Y + hHeight)),
                aCalc.Turn(new PointM(pos.X - hWidth, pos.Y + hHeight))
            };

            return points;
        }

        private static Point TurnAndProject(decimal x, decimal y, ProjectedPositionCalculator p, AngularCalculator aCalc)
        {
            return aCalc.Turn(p.ProjectPoint(new PointM(x, y))).Round();
        }
    }
}
