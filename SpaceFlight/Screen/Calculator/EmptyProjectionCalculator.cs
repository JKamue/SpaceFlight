using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    class EmptyProjectionCalculator : IProjectionCalculator
    {
        public Point ProjectPoint(Point p)
        {
            return p;
        }

        public int ProjectXCoordinate(int x)
        {
            return x;
        }

        public int ProjectYCoordinate(int y)
        {
            return y;
        }
    }
}
