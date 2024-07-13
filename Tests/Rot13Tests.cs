using _08_Rot13;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class Rot13Tests
    {
        [DataTestMethod]
        [DataRow("", "")]
        [DataRow(", ", ", ")]
        [DataRow("H", "U")]
        [DataRow("e", "R")]
        [DataRow("o", "B")]
        [DataRow("Hello, World", "URYYB, JBEYQ")]
        [DataRow("Er will in See stechen!", "RE JVYY VA FRR FGRPURA!")]
        public void Encode_Input_with_13_and_get_correct_result(string input, string expected)
        {
            Rot13Logic.Encode(input).Should().Be(expected);
            Rot13Logic.Encode(input, 13).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("", "")]
        [DataRow(", ", ", ")]
        [DataRow("H", "V")]
        [DataRow("e", "S")]
        [DataRow("o", "C")]
        [DataRow("Hello, World", "VSZZC, KCFZR")]
        [DataRow("Er will in See stechen!", "SF KWZZ WB GSS GHSQVSB!")]
        public void Encode_Input_with_14_and_get_correct_result(string input, string expected)
        {
            Rot13Logic.Encode(input, 14).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("", "")]
        [DataRow(", ", ", ")]
        [DataRow("0", "D")]
        [DataRow("Z", "C")]
        public void Encode_Input_with_digits_and_13_and_get_correct_result(string input, string expected)
        {
            Rot13Logic.Encode(input, includeDigits: true).Should().Be(expected);
        }
    }
}