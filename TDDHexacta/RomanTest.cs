using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TDDHexacta
{
    [TestFixture]
    public class RomanTest
    {
        /*
Como regla general, los símbolos se escriben y leen de izquierda a derecha, de mayor a menor valor.
El valor de un número se obtiene sumando los valores de los símbolos que lo componen, salvo en la siguiente excepción.
Si un símbolo de tipo 1 está a la izquierda inmediata de otro de mayor valor, se resta al valor del segundo el valor del primero. Ej. IV=4, IX=9.
Los símbolos de tipo 5 siempre suman y no pueden estar a la izquierda de uno de mayor valor.
Se permiten a lo sumo tres repeticiones consecutivas del mismo símbolo de tipo 1.
No se permite la repetición de una misma letra de tipo 5, su duplicado es una letra de tipo 10.
Si un símbolo de tipo 1 aparece restando, sólo puede aparecer a su derecha un sólo símbolo de mayor valor.
Si un símbolo de tipo 1 que aparece restando se repite, sólo se permite que su repetición esté colocada a su derecha y que no sea adyacente al símbolo que resta.
Sólo se admite la resta de un símbolo de tipo 1 sobre el inmediato mayor de tipo 1 o de tipo 5. Ejemplos:
el símbolo I sólo puede restar a V y a X.
el símbolo X sólo resta a L y a C.
el símbolo C sólo resta a D y a M.
Se permite que dos símbolos distintos aparezcan restando si no son adyacentes.
         */

        private Roman Roman;

        [SetUp]
        public void CreateRoman()
        {
            this.Roman = new Roman();
        }


        [Test]
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

        [Test]
        public void TestRestaAIzquierda()
        {
            Assert.AreEqual("IV", Roman.ToRoman(4));
            Assert.AreEqual("XL", Roman.ToRoman(40));
            Assert.AreEqual("CD", Roman.ToRoman(400));

            Assert.AreEqual("IX", Roman.ToRoman(9));
            Assert.AreEqual("XC", Roman.ToRoman(90));
            Assert.AreEqual("CM", Roman.ToRoman(900));
        }

        [Test]
        public void TestMenos3Repeticiones()
        {
            Assert.AreEqual("III", Roman.ToRoman(3));
            Assert.AreEqual("XXX", Roman.ToRoman(30));
            Assert.AreEqual("CCC", Roman.ToRoman(300));
            Assert.AreEqual("MMM", Roman.ToRoman(3000));
        }


        [Test]
        public void TestMenos2Repeticiones()
        {
            Assert.AreEqual("II", Roman.ToRoman(2));
            Assert.AreEqual("XX", Roman.ToRoman(20));
            Assert.AreEqual("CC", Roman.ToRoman(200));
            Assert.AreEqual("MM", Roman.ToRoman(2000));
        }

        [TestCaseSource(typeof(RomanTestData), "EspecialCases")]
        public string EspecialCasesTest(int value)
        {
            return Roman.ToRoman(value);
        }

    }

    public class RomanTestData
    {
        public static IEnumerable EspecialCases
        {
            get
            {
                yield return new TestCaseData(1).Returns("I");
                yield return new TestCaseData(1492).Returns("MCDXCII");
                yield return new TestCaseData(3889).Throws(typeof(ArgumentOutOfRangeException));
            }
        }
    }


}
