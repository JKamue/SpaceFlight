using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Other
{
    public struct SizeM
    {
        public decimal Height;
        public decimal Width;

        public SizeM(decimal height, decimal width)
        {
            Height = height;
            Width = width;
        }
    }
}
