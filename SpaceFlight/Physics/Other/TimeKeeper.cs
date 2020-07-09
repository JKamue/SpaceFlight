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
        private static float timeConstant = 1;

        public static TimeSpan Now()
        {
            UpdateMilisecondsSinceStart();
            return new TimeSpan((long) microSecondsSinceStart * 100);
        }

        public static void SetConstant(float i) => timeConstant = i;

        private static void UpdateMilisecondsSinceStart()
        {
            var diff = (DateTime.Now - lastCheck).TotalMilliseconds * 100 * timeConstant;
            microSecondsSinceStart += (microSecondsSinceStart + diff < 0) ? 0 : diff;
            
            lastCheck = DateTime.Now;
        }
    }
}
