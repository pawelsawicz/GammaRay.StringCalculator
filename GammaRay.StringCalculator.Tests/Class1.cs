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
        [TestCase("1,2,3", 6)]
        [TestCase("1,2", 3)]
        [TestCase("1", 1)]
        [TestCase("", 0)]
        public void Add_ProvidedNumbersInString_ReturnValue(string input, int expectedOutput)
        {
            int result = 0;

            result = Add(input);

            Assert.AreEqual(expectedOutput, result);
        }

        public int Add(string stringToParse)
        {
            int result = 0;
            if (string.IsNullOrWhiteSpace(stringToParse))
            {
                result = 0;
            }
            else
            {
                if (stringToParse.Contains("\n"))
                {
                    var numbersSplitedByNewLine = stringToParse.Split(new string[] {"\n"}, StringSplitOptions.None);
                    foreach (var s in numbersSplitedByNewLine)
                    {
                        var numbers = s.Split(',');
                        for (int i = 0; i < numbers.Count(); i++)
                        {
                            result += int.Parse(numbers[i]);
                        }
                    }
                }
                else
                {
                    var numbers = stringToParse.Split(',');
                    for (int i = 0; i < numbers.Count(); i++)
                    {
                        result += int.Parse(numbers[i]);
                    }
                }
            }
            return result;
        }
    }
}
