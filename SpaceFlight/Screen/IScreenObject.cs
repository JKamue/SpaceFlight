using SpaceFlight.Screen.Calculator;
using System.Drawing;

namespace SpaceFlight.Screen
{
    interface IScreenObject
    {
        Rectangle GetBounds();
        void Draw(Graphics g, IProjectionCalculator ppCalc, Rectangle screen);
        Point GetMiddle();
    }
}
