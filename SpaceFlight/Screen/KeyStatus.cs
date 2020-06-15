using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceFlight.Screen
{
    public static class KeyStatus
    {
        private static readonly Dictionary<byte, bool> _keyStatus;

        static KeyStatus()
        {
            _keyStatus = new Dictionary<byte, bool>();

            for (byte i = 0; i < byte.MaxValue; i++)
                _keyStatus[i] = false;
        }

        public static bool IsPressed(byte key) => _keyStatus[key];

        public static void KeyDownHandler(object sender, KeyEventArgs e) => SetKeyStatus(e.KeyValue, true);
        public static void KeyUpHander(object sender, KeyEventArgs e) => SetKeyStatus(e.KeyValue, false);

        private static void SetKeyStatus(int key, bool status)
        {
            if (key < 256)
                _keyStatus[Convert.ToByte(key)] = status;
        }
    }
}
