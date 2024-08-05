using _12_ToDictionary;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class ToDictionaryTests
    {
        [DataTestMethod]
        [DataRow("=1")]
        public void Invalid_input_and_Argument_Exception(string input)
        {
            Action act = () => ToDictionaryLogic.ToDictionary(input);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Empty_input_string_and_empty_dictionary_as_result()
        {
            Dictionary<string, string> expected = [];
            ToDictionaryLogic.ToDictionary("").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_nothing_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "" } };
            ToDictionaryLogic.ToDictionary("a=").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_one_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "1" } };
            ToDictionaryLogic.ToDictionary("a=1").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_equals_one_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "=1" } };
            ToDictionaryLogic.ToDictionary("a==1").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_one_and_b_equals_2_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "1" }, { "b", "2" } };
            ToDictionaryLogic.ToDictionary("a=1;b=2").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_one_and_empty_and_b_equals_2_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "1" }, { "b", "2" } };
            ToDictionaryLogic.ToDictionary("a=1;;b=2").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_one_and_a_equals_2_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "2" } };
            ToDictionaryLogic.ToDictionary("a=1;a=2").Should().Equal(expected);
        }

        [TestMethod]
        public void Input_a_equals_one_and_b_equals_2_and_c_equals_3_and_correct_dictionary_as_result()
        {
            Dictionary<string, string> expected = new() { { "a", "1" }, { "b", "2" }, { "c", "3" } };
            ToDictionaryLogic.ToDictionary("a=1;b=2;c=3").Should().Equal(expected);
        }
    }
}