namespace _14_CountCharacters
{
    public static class CountCharactersLogic
    {
        public static IDictionary<char, int> CountCharacters(string input, bool upperAndLowerLettersEqually = false)
        {
            Dictionary<char, int> output = [];

            foreach (char c in input)
            {
                char current = upperAndLowerLettersEqually ? char.ToLower(c) : c;

                if (output.ContainsKey(current))
                    output[current]++;
                else
                    output.Add(current, 1);
            }

            return output;
        }
    }
}