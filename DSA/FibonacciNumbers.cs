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
        /// <param name="numbersAmounght">Number of sequence element</param>
        public static int Get(int numbersAmounght)
        {
            var previousNumber = 1; //F(0)
            var currentNumber = 1; //F(1)

            if (numbersAmounght <= 1)
            {
                return 1;
            }

            for (int i = 2; i <= numbersAmounght; ++i)
            {
                var temp = currentNumber;
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
        /// <param name="numbersAmounght">Number of sequence element</param>
        public static int GetRecursively(int numbersAmounght)
        {
            if (numbersAmounght <= 1)
            {
                return 1;
            }

            return GetRecursively(numbersAmounght - 1) + GetRecursively(numbersAmounght - 2);
        }
    }
}
