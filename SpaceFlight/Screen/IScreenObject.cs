using SpaceFlight.Screen.Calculator;
using System.Drawing;
using SpaceFlight.Physics.Units;

namespace SpaceFlight.Screen
{
    interface IScreenObject
    {
        RectangleF GetBounds();
        void Draw(Graphics g, ProjectedPositionCalculator ppCalc, RectangleF screen, bool information);
        PointF GetMiddle();
        int GetPriority();
        void ChangeAngle(float change);
    }
}
