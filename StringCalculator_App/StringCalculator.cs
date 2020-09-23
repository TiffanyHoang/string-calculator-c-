using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringCalculator_App
{
    public class StringCalculator
    {
        public static int Add(string input)
        {
            bool isSingleCustomDelimiter = input.StartsWith("//");

            bool isMultiCustomDelimiter = Regex.IsMatch(input, @"\/\/\[.*?\]");

            if (string.IsNullOrEmpty(input))
            { 
                return 0;
            }

            if (isMultiCustomDelimiter)
            {
                string[] stringArray = input.Split('[', ']');

                string[] stringArrayWithoutStartLashes = stringArray.Skip(1).ToArray();

                string[] delimiters = stringArrayWithoutStartLashes.Reverse().Skip(1).Reverse().ToArray();

                string inputsString = stringArray[stringArray.Length - 1];

                string[] inputs = inputsString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                return Calculate(inputs);

            } else if(isSingleCustomDelimiter)
            {
                char delimiter = input[2];

                string inputsString = input.Substring(input.IndexOf("\n"));

                string[] inputs = inputsString.Split(delimiter);

                return Calculate(inputs);
            }
            else
            {
                string[] inputs = input.Split(new Char[] { ',', '\n' });

                return Calculate(inputs);
            }
        }

        private static int Calculate(string[] inputs)
        {
            int[] numbers = Array.ConvertAll(inputs, int.Parse);

            List<int> validNumbers = GetValidNumbers(numbers);

            return validNumbers.Sum();

        }

        private static List<int> GetValidNumbers(int[] numbers)
        {
            CheckForNegativeNumber(numbers);
            List<int> validNumbers = numbers.Where(number => number < 1000).ToList();
            return validNumbers;
        }

        private static void CheckForNegativeNumber(int[] numbers)
        {
            List<int> negativeNumbers = numbers.Where(number => number < 0).ToList();

            string negativeNumbersString = string.Join(",", negativeNumbers);

            if (numbers.Any(number => number < 0))
            {
                throw new ArgumentException("Negatives not allowed:" + negativeNumbersString);
            }
        }
    }
}
