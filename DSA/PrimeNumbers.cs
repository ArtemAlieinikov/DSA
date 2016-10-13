using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// This class checks, whether a number is prime.
    /// </summary>
    public static class PrimeNumbers
    {
        /// <summary>
        ///     <para>
        ///         T(n) = O(sqrt(n))
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="n">The test number</param>
        public static bool IsPrime(int n)
        {
            if (n == 1)
                return false;

            /*Суть в том, что для проверки на простоту достаточно 
             * проверить на целочисленное деление проверяемое число 
             * в диапазоне от 2 до sqrt(n).
             */
            for(int i = 2; (i * i) <= n; ++i)
            {
                if ((n % i) == 0)
                    return false;
            }

            return true;
        }
    }
}
