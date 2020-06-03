using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Screen.Calculator;

namespace SpaceFlight.Screen.ScreenObjects.Rocket.Sprites
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

        public List<RocketSpritePiece> CalculatePolygons(PointF pos, IProjectionCalculator ppCalc, AngularCalculator aCalc)
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

        public RectangleF GetBounds(PointF pos)
        {
            return new RectangleF(pos.X - _width / 2, pos.Y - _height / 2, _width, _height);
        }

        private PointF TurnAndProject(float x, float y, IProjectionCalculator p, AngularCalculator aCalc)
        {
            return p.ProjectPoint(aCalc.Turn(new PointF(x, y)));
        }
    }
}
