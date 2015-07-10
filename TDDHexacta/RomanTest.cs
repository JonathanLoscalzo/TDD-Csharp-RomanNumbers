using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDHexacta
{
    [TestClass]
    public class RomanTest
    {
        [TestMethod]
        public void TestDigitos()
        {
            Assert.AreEqual(Roman.ToRoman(1), "I");
            Assert.AreEqual(Roman.ToRoman(5), "V");
            Assert.AreEqual(Roman.ToRoman(10), "X");
            Assert.AreEqual(Roman.ToRoman(50), "L");
            Assert.AreEqual(Roman.ToRoman(100), "C");
            Assert.AreEqual(Roman.ToRoman(500), "D");
            Assert.AreEqual(Roman.ToRoman(1000), "M");

        }

        [TestMethod, Ignore]
        public void TestSumaADerecha()
        {

        }

        [TestMethod, Ignore]
        public void TestRestaAIzquierda()
        {
            Assert.AreEqual("IV", Roman.ToRoman(4));
            Assert.AreEqual("XL", Roman.ToRoman(40));
            Assert.AreEqual("CM", Roman.ToRoman(400));

            Assert.AreEqual("IX", Roman.ToRoman(9));
            Assert.AreEqual("XC", Roman.ToRoman(90));
            Assert.AreEqual("CM", Roman.ToRoman(900));
        }

        [TestMethod, Ignore]
        public void TestMenos3Repeticiones()
        {
            Assert.AreEqual("III", Roman.ToRoman(3));
            Assert.AreEqual("XXX", Roman.ToRoman(30));
            Assert.AreEqual("CCC", Roman.ToRoman(300));
            Assert.AreEqual("MMM", Roman.ToRoman(3000));
        }


        [TestMethod, Ignore]
        public void TestMenos2Repeticiones()
        {
            Assert.AreEqual("III", Roman.ToRoman(3));
            Assert.AreEqual("XXX", Roman.ToRoman(30));
            Assert.AreEqual("CCC", Roman.ToRoman(300));
            Assert.AreEqual("MMM", Roman.ToRoman(3000));
        }


    }
}
