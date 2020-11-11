using System;

namespace StringCalculator_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String Calculator. Please add numbers:");
            var input = Console.ReadLine();
            var result = StringCalculator.Add(input);
            
            Console.WriteLine($"The total is: {result}");

        }
    }
}
