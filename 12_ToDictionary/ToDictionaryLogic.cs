namespace _12_ToDictionary
{
    public static class ToDictionaryLogic
    {
        public static IDictionary<string, string> ToDictionary(string input)
        {
            Dictionary<string, string> output = [];

            foreach (string element in input.Split(';'))
            {
                string current = element;

                if (current == string.Empty)
                    continue;

                int idx = current.IndexOf('=');

                if (idx < 1)
                    throw new ArgumentException("Invalid input string");
                else
                    output[current[..idx]] = current[(idx + 1)..];
            }

            return output;
        }
    }
}