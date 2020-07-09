using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceFlight.Physics.Other
{
    static class TimeKeeper
    {
        private static double microSecondsSinceStart = 0;
        private static DateTime lastCheck = DateTime.Now;

        public static TimeSpan Now()
        {
            UpdateMilisecondsSinceStart();
            return new TimeSpan((long) microSecondsSinceStart * 100);
        }

        private static void UpdateMilisecondsSinceStart()
        {
            microSecondsSinceStart += (DateTime.Now - lastCheck).TotalMilliseconds * 100;
            lastCheck = DateTime.Now;
        }
    }
}
