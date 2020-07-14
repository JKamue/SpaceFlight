using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    class Decimalpoints
    {
        public static string Add(float x)
        {
            string theoneandonly = Convert.ToString(x);
            return AddDecimalpoints(theoneandonly);
        }
        public static string Add(float x, int round)
        {
            string theoneandonly = Convert.ToString(Math.Round(x, round));
            return AddDecimalpoints(theoneandonly);
        }
        public static string Add(double x)
        {
            string theoneandonly = Convert.ToString(x);
            return AddDecimalpoints(theoneandonly);
        }

        public static string Add(double x, int round)
        {
            string theoneandonly = Convert.ToString(Math.Round(x, round));
            return AddDecimalpoints(theoneandonly);
        }
        public static string Add(int x)
        {
            string theoneandonly = Convert.ToString(x);
            return AddDecimalpoints(theoneandonly);
        }
        private static string AddDecimalpoints(string theoneandonly)
        {
            string[] strings = theoneandonly.Split(',');
            string stringbackwards = "";
            for (int i = strings[0].Count(); i > 0; i--)
            {
                stringbackwards += strings[0][i - 1];
                if (((strings[0].Count() - (i - 1))) % 3 == 0 && ((i - 1) != 0))
                {
                    stringbackwards += '.';
                }
            }
            theoneandonly = "";
            for (int i = stringbackwards.Count(); i > 0; i--)
            {
                theoneandonly += stringbackwards[i - 1];
            }
            if (strings.Count() >= 2)
            {
                theoneandonly += ',';
                theoneandonly += strings[1];
            }

            return theoneandonly;
        }
    }
}
