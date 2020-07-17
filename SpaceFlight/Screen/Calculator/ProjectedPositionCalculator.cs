using System;
using System.Drawing;

namespace SpaceFlight.Screen.Calculator
{
    class ProjectedPositionCalculator
    {
        private readonly PointM _rMP;
        private readonly Point _pMP;
        private readonly decimal _factor;

        public ProjectedPositionCalculator(PointM realMainPosition, Point projectedMainPosition, decimal scalingFactor)
        {
            _rMP = realMainPosition;
            _pMP = projectedMainPosition;
            _factor = scalingFactor;
        }

        public PointM ProjectPoint(PointM p) => new PointM(ProjectXCoordinate(p.X), ProjectYCoordinate(p.Y));

        public decimal ProjectXCoordinate(decimal x) => (_pMP.X + (x - _rMP.X)) * _factor;

        public decimal ProjectYCoordinate(decimal y) => (_pMP.Y + (y - _rMP.Y) * -1) * _factor;

        public PointM ReversPoint(Point p) => new PointM(ReverseProjectXCoordinate(p.X), ReverseProjectYCoordinate(p.Y));

        public decimal ReverseProjectXCoordinate(int reverseX) => reverseX / _factor - _pMP.X + _rMP.X;
        public decimal ReverseProjectYCoordinate(int reverseY) => -1 * (reverseY / _factor - _pMP.Y - _rMP.Y);
    }
}