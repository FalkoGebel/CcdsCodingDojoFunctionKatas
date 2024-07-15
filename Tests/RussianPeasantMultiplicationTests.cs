using _09_RussianPeasantMultiplication;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class RussianPeasantMultiplicationTests
    {
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(-1, 10)]
        [DataRow(10, -65)]
        public void Invalid_Input_and_Argument_Exception(int first, int second)
        {
            Action act = () => RussianPeasantMultiplicationLogic.Mul(first, second);
            act.Should().Throw<ArgumentException>();
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(47, 42)]
        [DataRow(333, 1)]
        [DataRow(1, 333)]
        [DataRow(333, 333)]
        public void Valid_Input_and_get_corret_result(int first, int second)
        {
            RussianPeasantMultiplicationLogic.Mul(first, second).Should().Be(first * second);
        }
    }
}