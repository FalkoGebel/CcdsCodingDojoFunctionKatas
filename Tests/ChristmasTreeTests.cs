using _10_ChristmasTree;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class ChristmasTreeTests
    {
        [DataTestMethod]
        [DataRow(-1)]
        public void Invalid_Input_and_Argument_Exception(int height)
        {
            Action act = () => ChristmasTreeLogic.Draw(height);
            act.Should().Throw<ArgumentException>();
        }

        [DataTestMethod]
        [DataRow(5, "       X\n      XXX\n     XXXXX\n    XXXXXXX\n   XXXXXXXXX\n       X")]
        public void Valid_Input_and_correct_result(int height, string expected)
        {
            ChristmasTreeLogic.Draw(height).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(5, "       *\n       X\n      XXX\n     XXXXX\n    XXXXXXX\n   XXXXXXXXX\n       X")]
        public void Valid_Input_with_star_and_correct_result(int height, string expected)
        {
            ChristmasTreeLogic.Draw(height, true).Should().Be(expected);
        }
    }
}