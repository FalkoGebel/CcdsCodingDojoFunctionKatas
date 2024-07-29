namespace _11_WordWrap
{
    public static class WordWrapLogic
    {
        public static string Wrap(string text, int length, bool justified = false)
        {
            if (length <= 0)
                throw new ArgumentException("Invalid length - has to be positive integer");

            List<string> output = [];
            char[] delimiterChars = [' ', '\n'];

            foreach (string word in text.Split(delimiterChars))
            {
                if (output.Count == 0 || output[^1].Length + word.Length + 1 > length)
                {
                    string work = word;

                    while (work.Length > length)
                    {
                        output.Add(work[..length]);
                        work = work[length..];
                    }
                    output.Add(work);
                }
                else
                    output[^1] += $" {word}";
            }

            if (justified)
            {
                for (int i = 0; i < output.Count; i++)
                {
                    string[] words = output[i].Split(' ');

                    if (words.Length > 1 && output[i].Length < length)
                    {
                        string line = string.Empty;
                        int needed = length - output[i].Length,
                            toAdd = (int)Math.Ceiling(((double)needed) / (words.Length - 1));

                        foreach (string word in words)
                        {
                            int current = Math.Min(toAdd, needed);
                            line += word + new string(' ', (current > 0 ? current : 0) + 1);
                            needed -= toAdd;
                        }

                        output[i] = line.TrimEnd();
                    }
                }
            }

            return string.Join('\n', output);
        }
    }
}