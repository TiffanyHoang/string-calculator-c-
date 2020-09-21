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
                char delimeter = input[2];
                string newInputs = input.Remove(0,3);
                string[] inputs = newInputs.Split(delimeter);

                int[] numbers = Array.ConvertAll(inputs, int.Parse);
                return numbers.Sum();
            }
            else
            {
                string[] inputs = input.Split(new Char[] { ',', '\n' });
                int[] numbers = Array.ConvertAll(inputs, int.Parse);
                return numbers.Sum();
            }

        }       
    }
}
