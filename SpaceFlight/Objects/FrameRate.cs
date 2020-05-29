using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Objects
{
    class FrameRate
    {
        public int Framerate { get; private set} = 0;

        private long unixStamp = 0;
        private int lastFrames = 0;

        public FrameRate(int fps)
        {
            Framerate = fps;
        }

        public FrameRate()
        {
            unixStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public void FrameDrawn()
        {
            if (unixStamp == DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            {
                lastFrames++;
            } else
            {
                unixStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                Framerate = lastFrames;
                lastFrames = 1;
            }

        }

        public int CalculateDelay() => (int) Math.Floor(1000 / (float) Framerate);
    }
}
