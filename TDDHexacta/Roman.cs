using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace TDDHexacta
{
    internal class Roman
    {
        private static readonly Dictionary<int, string> numIntToRoman = new Dictionary<int, string>()
        {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1,"I"}

        };

        public Roman()
        {

        }



        public string ToRoman(int number)
        {
            if (number >= 3888)
            {
                throw new ArgumentOutOfRangeException("number", message: "Numeros mayores que 3888 no se pueden fabricar");
            }
            
            foreach (var t in numIntToRoman)
            {
                if (number >= t.Key)
                {
                    var val = number - t.Key;
                    return string.Concat(t.Value, new Roman().ToRoman(val));
                }
            }
            return null;
        }
    }
}