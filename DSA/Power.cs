using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// <para>Fast number counting in some degree.<para>
    /// </summary>
    public static class Power
    {
        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         M(n) = O(1)
        ///     <para>
        /// </summary>
        /// <param name="number">Number, wich power</param>
        /// <param name="power">Degree of power</param>
        public static double GetPowerFirstVersion(double number, int power)
        {
            if (power <= 0) return 1.0;
            double result = 1.0;
            
            while(power > 0)
            {
                result *= number;
                power--;
            }

            return result;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(log n)
        ///         M(n) = O(1)
        ///     <para>
        /// </summary>
        /// <param name="number">Number, wich power</param>
        /// <param name="power">Degree of power</param>
        public static double GetPowerSecondVersion(double number, int power)
        {
            /*The main idea is that you need то expanded to the 
             * degree a power of two. 
             * n^6 = (n^n) * (n^n) * (n^n);
             * n^7 = (n^n) * (n^n) * (n^n) * n;
             */
            if (power <= 0) return 1;

            double result = 1;
            double numberInDegreeOf2 = number;

            while(power > 0)
            {
                if ((power & 1) == 1) //also we can write (power % 2)
                    result *= numberInDegreeOf2;

                numberInDegreeOf2 *= numberInDegreeOf2;
                power >>= 1; //also we can write (power /= 2)
            }

            return result;
        }
    }
}
