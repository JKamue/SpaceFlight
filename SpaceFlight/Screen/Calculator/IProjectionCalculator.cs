using System.Drawing;

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

        int RoundToInt(float n);
    }
}
