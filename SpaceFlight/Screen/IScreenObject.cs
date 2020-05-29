using System.Drawing;

namespace SpaceFlight.Screen
{
    interface IScreenObject
    {
        Rectangle GetBounds();
        void Draw(Graphics g);

    }
}
