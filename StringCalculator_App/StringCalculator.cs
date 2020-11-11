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

                string[] delimiters = stringArray.Skip(1).Take(stringArray.Count() - 2).ToArray();
            
                CheckForValidDelimiter(delimiters);

                string inputsString = stringArray[stringArray.Length - 1];

                string finalInputsString = inputsString.Substring(inputsString.IndexOf("\\n") + 2);
                
                string[] inputs = finalInputsString.Split(delimiters, StringSplitOptions.None);
        
                return Calculate(inputs);

            } else if(isSingleCustomDelimiter)
            {
                char delimeter = input[2];
                string inputsString = input.Substring(input.IndexOf("\\n") + 2);
                
                string[] inputs = inputsString.Split(delimeter);

                return Calculate(inputs);
            }
            else
            {
                string[] delimeters = new string[] {",", "\\n"};
                string[] inputs = input.Split(delimeters, StringSplitOptions.None);
            
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

        private static void CheckForValidDelimiter(string[] delimiters)
        {
            string rxNumberAtEdge = @"(^\d)|(\d$)";

            if (delimiters.Any(delimiter => Regex.IsMatch(delimiter, rxNumberAtEdge)))
            {
                throw new ArgumentException("Invalid Delimiter");
            }
        }
    }
}
