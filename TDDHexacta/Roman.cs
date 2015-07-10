using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TDDHexacta
{
    class Roman
    {
        static int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 2, 1 };
        static string[] rum = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "II","I" };

        public static string ToRoman(int number)
        {
            var index  = nums.ToList().IndexOf(number);
            return rum[index];
        }
    }
}