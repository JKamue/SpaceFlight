using SpaceFlight.Screen.Calculator;
using System.Drawing;

namespace SpaceFlight.Screen
{
    interface IScreenObject
    {
        RectangleF GetBounds();
        void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen);
        PointF GetMiddle();
        int GetPriority();
        void ChangeAngle(float change);
    }
}
