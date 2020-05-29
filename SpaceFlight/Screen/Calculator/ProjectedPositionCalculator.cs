using SpaceFlight.Screen.Calculator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    class ProjectedPositionCalculator : IProjectionCalculator
    {
        private readonly Point _rMP;
        private readonly Point _pMP;
        private readonly float _factor;

        public ProjectedPositionCalculator(Point realMainPosition, Point projectedMainPosition, float scalingFactor)
        {
            _rMP = realMainPosition;
            _pMP = projectedMainPosition;
            _factor = scalingFactor;
        }

        public Point ProjectPoint(Point p) => new Point( ProjectXCoordinate(p.X), ProjectYCoordinate(p.Y));

        private int RoundToInt(float f) => (int)Math.Round(f);

        public int ProjectXCoordinate(int x) => RoundToInt((_pMP.X + (x - _rMP.X)) * _factor);
        public int ProjectYCoordinate(int y) => RoundToInt((_pMP.Y + (y - _rMP.Y)) * _factor);
    }
}
