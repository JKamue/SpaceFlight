using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFlight.Screen.Calculator
{
    public class DecimalPoints
    {
        public static string Add(decimal x)
        {
            string decimalAsString = Convert.ToString(x);
            return AddDecimalpoints(decimalAsString);
        }
        public static string Add(decimal x, int round) => Add(Math.Round(x, round));

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
