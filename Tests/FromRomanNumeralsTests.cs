using _03_FromRomanNumerals;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class FromRomanNumeralsTests
    {
        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("II", 2)]
        [DataRow("III", 3)]
        [DataRow("IV", 4)]
        [DataRow("V", 5)]
        [DataRow("VI", 6)]
        [DataRow("VII", 7)]
        [DataRow("VIII", 8)]
        [DataRow("IX", 9)]
        [DataRow("X", 10)]
        [DataRow("XI", 11)]
        [DataRow("XV", 15)]
        [DataRow("XIX", 19)]
        [DataRow("XLII", 42)]
        [DataRow("L", 50)]
        [DataRow("XCIX", 99)]
        [DataRow("C", 100)]
        [DataRow("M", 1000)]
        [DataRow("MM", 2000)]
        [DataRow("MMXIII", 2013)]
        public void Input_Roman_and_get_Decimal(string roman, int dec)
        {
            RomanNumeralsLogic.GetDecimalFromRomanNumeral(roman).Should().Be(dec);
        }

        [DataTestMethod]
        [DataRow("O")]
        [DataRow("IVI")]
        [DataRow("IXI")]
        [DataRow("I X")]
        [DataRow("XXXXI")]
        [DataRow("IC")]
        [DataRow("XLX")]
        [DataRow("XCX")]
        [DataRow("CDC")]
        [DataRow("CMC")]
        [DataRow("MMMM")]
        [DataRow("CDCD")]
        [DataRow("MMMI")]
        public void Input_InvalidRoman_and_get_Exception(string roman)
        {
            Action act = () => RomanNumeralsLogic.GetDecimalFromRomanNumeral(roman);
            act.Should().Throw<ArgumentException>();
        }
    }
}
