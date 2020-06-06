using SpaceFlight.Screen.Calculator;
using System.Drawing;

namespace SpaceFlight.Screen.ScreenObjects
{
    interface IScreenObject
    {
        RectangleF GetBounds();
        void Draw(Graphics g, IProjectionCalculator ppCalc, RectangleF screen);
        PointF GetMiddle();
        int GetPriority();
    }
}
