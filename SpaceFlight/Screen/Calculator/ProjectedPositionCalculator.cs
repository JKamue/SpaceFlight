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

        public ProjectedPositionCalculator(Point realMainPosition, Point projectedMainPosition)
        {
            _rMP = realMainPosition;
            _pMP = projectedMainPosition;
        }

        public Point ProjectPoint(Point p) => new Point( ProjectXCoordinate(p.X), ProjectYCoordinate(p.Y));

        public int ProjectXCoordinate(int x) => _pMP.X + (x - _rMP.X);
        public int ProjectYCoordinate(int y) => _pMP.Y + (y - _rMP.Y);
    }
}
