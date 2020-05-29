using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    interface IProjectionCalculator
    {
        Point ProjectPoint(Point p);
        int ProjectXCoordinate(int x);
        int ProjectYCoordinate(int y);
    }
}
