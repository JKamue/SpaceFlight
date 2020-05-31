using System;

namespace SpaceFlight.Objects
{
    class FrameRateCounter
    {
        public int Framerate { get; private set;  } = 0;

        private long unixStamp = 0;
        private int lastFrames = 0;

        public FrameRateCounter()
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

        public int CalculateDelay() => (int) Math.Ceiling(1000 / (float) Framerate);
    }
}
