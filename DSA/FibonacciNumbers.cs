using System;

namespace DSA
{
    /// <summary>
    ///  This class implements the count Fibonacci numbers.
    /// </summary>
    static class FibonacciNumbers
    {
        /// <summary>
        ///     <para>
        ///         Linear method of counting the number Fibonacci.
        ///         T(n) = O(n)
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="n">Number of sequence element</param>
        public static int Get(int n)
        {
            int previousNumber = 1; //F(0)
            int currentNumber = 1; //F(1)

            if (n <= 1)
            {
                return 1;
            }
            else { }

            for (int i = 2; i <= n; ++i)
            {
                int temp = currentNumber;
                currentNumber += previousNumber; //F(i)
                previousNumber = temp; //F(i - 1)
            }

            return currentNumber;
        }

        /// <summary>
        ///     <para>
        ///         Recursive method of counting the number Fibonacci.
        ///         T(n) = Ω(1.6^n)
        ///         M(n) = O(n)
        ///     </para>
        /// </summary>
        /// <param name="n">Number of sequence element</param>
        public static int GetRecursively(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else { }

            return GetRecursively(n - 1) + GetRecursively(n - 2);
        }
    }
}
