using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(12345600));
        }

        static int Reverse(int i)
        {
            int grade = 1;
            int result = 0;

            if(i < 10)
            {
                return i;
            }
            else { }

            while (i > 0)
            {
                result *= grade;
                result += i % 10;
                i = i / 10;
                grade = 10;
            }

            return result;
        }
    }  
}
