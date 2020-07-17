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

        public Point ProjectPoint(Point p) => ProjectPoint(new PointM(p));
        public Point ProjectPoint(PointM p) => new Point(ProjectXCoordinate(p.X), ProjectYCoordinate(p.Y));

        public int ProjectXCoordinate(decimal x) => RoundToInt((_pMP.X + (x - _rMP.X)) * _factor);
        public int ProjectXCoordinate(int x) => ProjectXCoordinate((decimal) x);

        public int ProjectYCoordinate(int y) => ProjectYCoordinate((decimal) y);
        public int ProjectYCoordinate(decimal y) => RoundToInt((_pMP.Y + (y - _rMP.Y) * -1) * _factor);

        public PointM ReversPoint(Point p) => new PointM(ReverseProjectXCoordinate(p.X), ReverseProjectYCoordinate(p.Y));

        public decimal ReverseProjectXCoordinate(int reverseX) => reverseX / _factor - _pMP.X + _rMP.X;
        public decimal ReverseProjectYCoordinate(int reverseY) => -1 * (reverseY / _factor - _pMP.Y - _rMP.Y);

        public int RoundToInt(decimal m) => (int)Math.Round(m);
    }
}