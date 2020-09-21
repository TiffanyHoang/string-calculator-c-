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
            } else
            {
                string[] inputs = input.Split(new Char[] { ',', '\n'});
               
                int[] inputsInt = Array.ConvertAll(inputs, int.Parse);

                return inputsInt.Sum();
            }

        }
             
    }
}
