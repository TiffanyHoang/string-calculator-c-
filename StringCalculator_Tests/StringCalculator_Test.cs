using System;
using Xunit;
using StringCalculator_App;

namespace StringCalculator_Tests
{
    public class StringCalculator_CalculatorShould
    {
        [Fact]
        public void GivenAnEmptyString_Return0()
        {
            string input = "";

            int expected = 0;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenASingleNumberString_ReturnTheSingleNumber()
        {
            string input = "3";

            int expected = 3;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenTwoNumbersString_ReturnTheSumOfTheTwoNumbers()
        {
            string input = "3,3";

            int expected = 6;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenFourNumbersString_ReturnTheSumOfTheFourNumbers()
        {
            string input = "3,3,5,4";

            int expected = 15;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenFourNumbersStringWithLineBreaksAndCommas_ReturnTheSumOfTheFourNumbers()
        {
            string input = "3\n5\n3,9";

            int expected = 20;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenTwoNumbersStringWithCustomDelimiter_ReturnTheSumOfTheTwoNumbers()
        {
            string input = "//;\n1;2";
            int expected = 3;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }
    }
}
