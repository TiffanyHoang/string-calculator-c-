using System;
using Xunit;
using StringCalculator_App;

namespace StringCalculator_Tests
{
    public class StringCalculator_CalculatorShould
    {
        [Fact]
        public void Add_EmptyString_Return0()
        {
            string input = "";

            int expected = 0;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_SingleNumberString_ReturnTheSingleNumber()
        {
            string input = "3";

            int expected = 3;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoNumbersString_ReturnTheSumOfTheTwoNumbers()
        {
            string input = "3,3";

            int expected = 6;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_FourNumbersString_ReturnTheSumOfTheFourNumbers()
        {
            string input = "3,3,5,4";

            int expected = 15;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_FourNumbersStringWithLineBreaksAndCommas_ReturnTheSumOfTheFourNumbers()
        {
            string input = "3\n5\n3,9";

            int expected = 20;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_TwoNumbersStringWithCustomDelimiter_ReturnTheSumOfTheTwoNumbers()
        {
            string input = "//;\n1;2";
            int expected = 3;
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-1,2,-3", "Negatives not allowed:-1,-3")]
        [InlineData("//;\n1;-3", "Negatives not allowed:-3")]
        public void Add_NegativeNumbers_ReturnException(string input, string expected)
        {
            var actual = Assert.Throws<ArgumentException>(() => StringCalculator.Add(input)).Message;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1000,1001,2", 2)]
        [InlineData("//;\n1;2000", 1)]
        public void Add_NumberswithNumbersAreOver1000_ReturnTheSumOfNumberLessThan1000(string input, int expected)
        {
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//[***]\n1***2***3",6)]
        [InlineData("//[***]\n5***3***10", 18)]
        public void Add_3LengthDelimiterBetweenThreeNumbers_ReturnTheSumOfTheThreeNumber(string input, int expected)
        {
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        public void Add_NumbersWithMultiDelimiter_ReturnTheSumOfNumbers(string input, int expected)
        {
            int actual = StringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }
    }
}
