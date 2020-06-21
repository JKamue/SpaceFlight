using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpaceFlight.Screen
{
    public static class KeyStatus
    {
        private static readonly Dictionary<byte, bool> KeyStats;

        static KeyStatus()
        {
            KeyStats = new Dictionary<byte, bool>();

            for (byte i = 0; i < byte.MaxValue; i++)
                KeyStats[i] = false;
        }

        public static bool IsPressed(byte key) => KeyStats[key];

        public static void KeyDownHandler(object sender, KeyEventArgs e) => SetKeyStatus(e.KeyValue, true);
        public static void KeyUpHander(object sender, KeyEventArgs e) => SetKeyStatus(e.KeyValue, false);

        private static void SetKeyStatus(int key, bool status)
        {
            if (key < 256)
                KeyStats[Convert.ToByte(key)] = status;
        }
    }
}
