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
        Point ProjectPoint(PointF p);
        int ProjectXCoordinate(int x);
        int ProjectXCoordinate(float x);
        int ProjectYCoordinate(int y);
        int ProjectYCoordinate(float y);
    }
}
