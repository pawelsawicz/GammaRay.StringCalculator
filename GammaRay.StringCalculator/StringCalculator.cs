using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaRay.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string stringToParse)
        {
            int result = 0;
            char delimeter = ',';
            if (string.IsNullOrWhiteSpace(stringToParse))
            {
                result = 0;
            }
            else
            {
                if (stringToParse.Contains("//"))
                {
                    delimeter = stringToParse[2];
                    string sequenceToRemove = "//" + delimeter;
                    stringToParse = stringToParse.Remove(0, 3);
                }
                if (stringToParse.Contains("\n"))
                {
                    var numbersSplitedByNewLine =
                        stringToParse.Split(new string[] {"\n"}, StringSplitOptions.None)
                                     .Where(x => !string.IsNullOrWhiteSpace(x))
                                     .ToArray();
                    foreach (var s in numbersSplitedByNewLine)
                    {
                        var numbers = s.Split(delimeter).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        result += AddNumbersFromStringArray(numbers);
                    }
                }
                else
                {
                    var numbers = stringToParse.Split(delimeter);
                    result = AddNumbersFromStringArray(numbers);
                }
            }
            return result;
        }

        public int AddNumbersFromStringArray(string[] numbersToCompute)
        {
            int result = 0;
            for (int i = 0; i < numbersToCompute.Count(); i++)
            {
                result += int.Parse(numbersToCompute[i]);
            }
            return result;
        }

    }
}
