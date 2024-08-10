using _14_CountCharacters;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class CountCharactersTests
    {
        [TestMethod]
        public void Input_empty_string_and_get_empty_dictionary()
        {
            string input = "";
            Dictionary<char, int> expected = [];
            CountCharactersLogic.CountCharacters(input).Should().Equal(expected);
        }

        [TestMethod]
        public void Input_HelLo_wOrld_and_get_correct_result()
        {
            string input = "HelLo wOrld";
            Dictionary<char, int> expected = new()
            {
                { 'H', 1 }, { 'e', 1 }, { 'l', 2 }, { 'L', 1 }, { 'o', 1 },
                { 'w', 1 }, { 'O', 1 }, { 'r', 1 }, { 'd', 1 }, { ' ', 1 }
            };

            CountCharactersLogic.CountCharacters(input).Should().Equal(expected);
        }

        [TestMethod]
        public void Input_Das_darf_nicht_sein_and_get_correct_result()
        {
            string input = "Das darf nicht sein";
            Dictionary<char, int> expected = new()
            {
                { 'D', 1 }, { 'a', 2 }, { 's', 2 }, { ' ', 3 }, { 'd', 1 },
                { 'r', 1 }, { 'f', 1 }, { 'n', 2 }, { 'i', 2 }, { 'c', 1 },
                { 'h', 1 }, { 'e', 1 }, { 't', 1 }
            };

            CountCharactersLogic.CountCharacters(input).Should().Equal(expected);
        }

        [TestMethod]
        public void Input_HelLo_wOrld_and_lower_and_upper_equally_and_get_correct_result()
        {
            string input = "HelLo wOrld";
            Dictionary<char, int> expected = new()
            {
                { 'h', 1 }, { 'e', 1 }, { 'l', 3 }, { 'o', 2 },
                { 'w', 1 }, { 'r', 1 }, { 'd', 1 }, { ' ', 1 }
            };

            CountCharactersLogic.CountCharacters(input, true).Should().Equal(expected);
        }
    }
}