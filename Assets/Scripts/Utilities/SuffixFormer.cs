using System;
using System.Globalization;

namespace Utilities
{
    public static class SuffixFormer
    {
        public static string GetSuffixValue(int value)
        {
            var zero = 0;

            float round = value;
            while (value >= 1000)
            {
                ++zero;

                value /= 1000;
            }
            string suffix;
            
            if (zero != 0)
            {
                round /= 1000 * zero;
                round = (float) Math.Round(round, 2);
                suffix = round.ToString(CultureInfo.InvariantCulture).Split('.')[0];
            }
            else
            {
                suffix = value.ToString();
            }

            switch (zero)
            {
                case 1: suffix += "K"; break;
                case 2: suffix += "M"; break;
                case 3: suffix += "B"; break;
                case 4: suffix += "T"; break;
                case 5: suffix += "Qd"; break;
                case 6: suffix += "Qn"; break;
                case 7: suffix += "Sx"; break;
                case 8: suffix += "Sp"; break;
                case 9: suffix += "Oc"; break;
            }
 
            return $"{suffix}";
        }
    }
}