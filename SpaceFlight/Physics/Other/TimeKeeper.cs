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
        private static double _microSecondsSinceStart = 0;
        private static DateTime _lastCheck = DateTime.Now;
        public static float TimeConstant = 1;

        public static TimeSpan Now()
        {
            UpdateMilisecondsSinceStart();
            return new TimeSpan((long) _microSecondsSinceStart * 100);
        }

        private static void UpdateMilisecondsSinceStart()
        {
            var diff = (DateTime.Now - _lastCheck).TotalMilliseconds * 100 * TimeConstant;
            _microSecondsSinceStart += (_microSecondsSinceStart + diff < 0) ? 0 : diff;
            
            _lastCheck = DateTime.Now;
        }
    }
}
