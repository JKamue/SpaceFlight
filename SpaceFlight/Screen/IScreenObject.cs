using SpaceFlight.Screen.Calculator;
using System.Drawing;
using SpaceFlight.Screen.Other;

namespace SpaceFlight.Screen
{
    interface IScreenObject
    {
        RectangleM GetBounds();
        void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleM screen);
        PointM GetMiddle();
        int GetPriority();
        void ChangeAngle(float change);
    }
}
