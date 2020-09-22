using System;
using System.Linq;
using System.Collections.Generic;
namespace StringCalculator_App
{
    public class StringCalculator
    {
        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            { 
                return 0;
            }
            if (input.StartsWith("//"))
            {
                char delimiter = input[2];
                string inputsString = input.Remove(0, 3);

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

            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negatives not allowed:" + negativeNumbersString);
            }
        }
    }
}
