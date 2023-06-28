using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3G.CLasses
{
    public static class Function
    {
        public static double a = -3;
        public static double b = 5;
        public static int n = 20;
        public static double Evaluate(double x)
        {
            double y = Math.Abs(x - 3) - 2 * Math.Abs(x - 2) + 2 * Math.Abs(x - 1) + 1;
            return y;
        }
        public static double NewtonEquidistant(double x)
        {
            double[] x_arr = new double[n];
            double[] y_arr = new double[n];
            double plus = (b - a) / ((n - 1) * 1.0);
            for (int i = 0; i < n; i++)
            {
                x_arr[i] = a + i * plus;
                y_arr[i] = Evaluate(x_arr[i]);
                //Debug.WriteLine(Math.Round(x_arr[i], 3) + " " + Math.Round(y_arr[i], 3));
            }
            return Newton(x, x_arr, y_arr);
        }
        public static double NewtonChebysh(double x)
        {
            double[] x_arr = new double[n];
            double[] y_arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                x_arr[i] = (a + b) / 2 + ((b - a) / 2) * Math.Cos((2 * i + 1) * Math.PI / (2 * n));
                y_arr[i] = Evaluate(x_arr[i]);
                //Debug.WriteLine(Math.Round(x_arr[i], 3) + " " + Math.Round(y_arr[i], 3));
            }
            return Newton(x, x_arr, y_arr);
        }
        public static double Newton(double x, double[] x_arr, double[] y_arr)
        {
            double sum = y_arr[0];
            for (int i = 1; i < n; ++i)
            {
                double F = 0;
                for (int j = 0; j <= i; ++j)
                {
                    double den = 1;
                    for (int k = 0; k <= i; ++k)
                        if (k != j)
                            den *= (x_arr[j] - x_arr[k]);
                    F += y_arr[j] / den;
                }

                for (int k = 0; k < i; ++k)
                    F *= (x - x_arr[k]);
                sum += F;
            }
            return sum;
        }
        public static double Spline(double x)
        {
            double y = 1000;
            if (0 <= x && x <= 0.5)
            {
                y = -1.0692 * Math.Pow(x, 3) - 0.7327 * x + 2;
            }
            if (0.5 < x && x <= 1)
            {
                y = 5.3462 * Math.Pow(x, 3) - 9.6231 * Math.Pow(x, 2) + 4.0789 * x + 1.1981;
            }
            if (1 < x && x <= 1.5)
            {
                y = -4.3154 * Math.Pow(x, 3) + 19.3617 * Math.Pow(x, 2) - 24.9059 * x + 10.8597;
            }
            if (1.5 < x && x <= 2)
            {
                y = -4.0845 * Math.Pow(x, 3) + 18.3224 * Math.Pow(x, 2) - 23.3469 * x + 10.0801;
            }
            if (2 < x && x <= 2.5)
            {
                y = 4.6534 * Math.Pow(x, 3) - 34.1046 * Math.Pow(x, 2) + 81.5071 * x - 59.8225;
            }
            if (2.5 < x && x <= 3)
            {
                y = 1.471 * Math.Pow(x, 3) - 10.2372 * Math.Pow(x, 2) + 21.8383 * x - 10.0985;
            }
            if (3 < x && x <= 3.5)
            {
                y = -2.5375 * Math.Pow(x, 3) + 25.84 * Math.Pow(x, 2) - 86.393 * x + 98.1328;
            }
            if (3.5 < x && x <= 4)
            {
                y = 0.6791 * Math.Pow(x, 3) - 7.9344 * Math.Pow(x, 2) + 31.8171 * x - 39.7789;
            }
            if (4 < x && x <= 4.5)
            {
                y = -0.1787 * Math.Pow(x, 3) + 2.3588 * Math.Pow(x, 2) - 9.3557 * x + 15.1182;
            }
            if (4.5 < x && x <= 5)
            {
                y = 0.0357 * Math.Pow(x, 3) - 0.536 * Math.Pow(x, 2) + 3.6711 * x - 4.422;
            }
            return y;
        }
        public static double Spline2(double x)
        {
            double y = 0;
            if (0 <= x && x <= 1.25)
            {
                y = 0.3383 * Math.Pow(x, 3) - 0.7286 * x + 2;
            }
            if (1.25 <= x && x <= 2.5)
            {
                y = -0.6674 * Math.Pow(x, 3) + 3.7714 * Math.Pow(x, 2) - 5.4428 * x + 3.9642;
            }
            if (2.5 <= x && x <= 3.75)
            {
                y = 0.5394 * Math.Pow(x, 3) - 5.28 * Math.Pow(x, 2) + 17.1858 * x - 14.893;
            }
            if (3.75 <= x && x <= 5)
            {
                y = -0.2103 * Math.Pow(x, 3) + 3.1542 * Math.Pow(x, 2) - 14.4424 * x + 24.6422;
            }
            return y;
        }
    }
}
