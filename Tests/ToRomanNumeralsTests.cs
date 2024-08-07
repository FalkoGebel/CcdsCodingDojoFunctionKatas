using _13_ToRomanNumerals;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class ToRomanNumeralsTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow("text")]
        [DataRow("1text")]
        [DataRow("-100")]
        [DataRow("-1")]
        [DataRow("3001")]
        [DataRow("10000")]
        public void Invalid_input_and_arguement_exception(string decimalNumber)
        {
            Action act = () => ToRomanNumeralsLogic.GetRomanNumeralFromDecimal(decimalNumber);
            act.Should().Throw<ArgumentException>();
        }

        [DataTestMethod]
        [DataRow("I", "1")]
        [DataRow("II", "2")]
        [DataRow("III", "3")]
        [DataRow("IV", "4")]
        [DataRow("V", "5")]
        [DataRow("VI", "6")]
        [DataRow("VII", "7")]
        [DataRow("VIII", "8")]
        [DataRow("IX", "9")]
        [DataRow("X", "10")]
        [DataRow("XI", "11")]
        [DataRow("XV", "15")]
        [DataRow("XIX", "19")]
        [DataRow("XLII", "42")]
        [DataRow("L", "50")]
        [DataRow("XCIX", "99")]
        [DataRow("C", "100")]
        [DataRow("M", "1000")]
        [DataRow("MM", "2000")]
        [DataRow("MMXIII", "2013")]
        [DataRow("MMM", "3000")]
        public void Valid_input_and_correct_result(string expected, string decimalNumber)
        {
            ToRomanNumeralsLogic.GetRomanNumeralFromDecimal(decimalNumber).Should().Be(expected);
        }
    }
}
