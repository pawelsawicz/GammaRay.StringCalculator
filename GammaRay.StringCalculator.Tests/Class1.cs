using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GammaRay.StringCalculator.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        [TestCase("1\n2,3\n10", 16)]
        [TestCase("1\n2,3", 6)]
        [TestCase("\n1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2", 3)]
        [TestCase("1", 1)]
        [TestCase("", 0)]
        public void Add_ProvidedNumbersInString_ReturnValue(string input, int expectedOutput)
        {
           
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(input);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        [TestCase("//;1;3;8;\n7;3", 22)]
        [TestCase("//*1*3*4", 8)]
        [TestCase("//;\n1;2", 3)]
        public void Add_ProvidedNumbersInStringWithCustomDelimiters_ReturnValue(string input, int expectedOutput)
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(input);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}
