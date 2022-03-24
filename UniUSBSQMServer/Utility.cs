
namespace UniUSBSQMServer
{
    public class Utility
    {
        public static double ConvertDataToDouble(string data)
        {
            var str = data;
            string numericString = string.Empty;
            foreach (var c in str)
            {
                // Check for numeric characters (hex in this case) or leading or trailing spaces.
                if ((c >= '0' && c <= '9') || c == '.')
                {
                    numericString = string.Concat(numericString, c.ToString());
                }
            }
            Double number = Convert.ToDouble(numericString);
            return number;
        }

        public static double CalcNELM(double mpas)
        {
            double mag = Convert.ToDouble(mpas);
            double power = (4.316 - (mag / 5));
            double interim = System.Math.Pow(10.0, power);
            double nelm = 7.93 - 5 * System.Math.Log10(interim + 1.0);

            return nelm;
        }

        public static int GetBortleNumber(double nelm)
        {
            if (nelm < 4.1)
            {
                return 9;
            }
            else if (nelm >= 4.1 && nelm < 4.6)
            {
                return 8;
            }
            else if (nelm >= 4.6 && nelm < 5.1)
            {
                return 7;
            }
            else if (nelm >= 5.1 && nelm < 5.6)
            {
                return 6;
            }
            else if (nelm >= 5.6 && nelm < 6.1)
            {
                return 5;
            }
            else if (nelm >= 6.1 && nelm < 6.6)
            {
                return 4;
            }
            else if (nelm >= 6.6 && nelm < 7.1)
            {
                return 3;
            }
            else if (nelm >= 7.1 && nelm < 7.6)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public static Color GetColorByNELM(double nelm)
        {

            if (nelm < 4.1)
            {
                return Color.White;
            }
            else if (nelm >= 4.1 && nelm < 4.6)
            {
                return Color.White;
            }
            else if (nelm >= 4.6 && nelm < 5.1)
            {
                return Color.Red;
            }
            else if (nelm >= 5.1 && nelm < 5.6)
            {
                return Color.Red;
            }
            else if (nelm >= 5.6 && nelm < 6.1)
            {
                return Color.Orange;
            }
            else if (nelm >= 6.1 && nelm < 6.3)
            {
                return Color.Yellow;
            }
            else if (nelm >= 6.3 && nelm < 6.6)
            {
                return Color.Green;
            }
            else if (nelm >= 6.6 && nelm < 7.1)
            {
                return Color.Blue;
            }
            else if (nelm >= 7.1 && nelm < 7.6)
            {
                return Color.DarkGray;
            }
            else
            {
                return Color.Black;
            }
        }

        public static double ConvertTempCtoF(double centigrade)
        {
            return (centigrade * 9) / 5 + 32;
        }
    }
}
