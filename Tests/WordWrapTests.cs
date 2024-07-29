using _11_WordWrap;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class WordWrapTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(-100)]
        public void Invalid_Input_and_Argument_Exception(int length)
        {
            Action act = () => WordWrapLogic.Wrap("", length);
            act.Should().Throw<ArgumentException>();
        }

        [DataTestMethod]
        [DataRow(9, "Es blaut die Nacht,\ndie Sternlein blinken,\nSchneeflöcklein leis hernieder sinken.", "Es blaut\ndie\nNacht,\ndie\nSternlein\nblinken,\nSchneeflö\ncklein\nleis\nhernieder\nsinken.")]
        public void Valid_Input_and_correct_result(int length, string text, string expected)
        {
            WordWrapLogic.Wrap(text, length).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(22, "Es blaut die Nacht,\ndie Sternlein blinken,\nSchneeflöcklein leis hernieder sinken.", "Es  blaut  die  Nacht,\ndie Sternlein blinken,\nSchneeflöcklein   leis\nhernieder      sinken.")]
        [DataRow(25, "Es blaut die Nacht, die", "Es  blaut  die Nacht, die")]
        public void Valid_Input_with_justified_flag_and_correct_result(int length, string text, string expected)
        {
            WordWrapLogic.Wrap(text, length, true).Should().Be(expected);
        }
    }
}