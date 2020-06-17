using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Physics.Other
{
    public class DragProperties
    {
        private readonly double _cdUp;
        private readonly double _cdSide;
        private readonly double _areaUp;
        private readonly double _areaSide;

        public DragProperties(double cdUp, double cdSide, double areaUp, double areaSide)
        {
            _cdUp = cdUp;
            _cdSide = cdSide;
            _areaUp = areaUp;
            _areaSide = areaSide;
        }

        private static double MapAngle(Angle a) => Math.Cos(2 * a.Radian);

        private static double Map(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public double GetArea(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, _areaUp, _areaSide);
        }

        public double GetDragCoefficient(Angle a)
        {
            var value = MapAngle(a);
            return Map(value, 1, -1, _cdUp, _cdSide);
        }
    }
}
