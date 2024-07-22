namespace _10_ChristmasTree
{
    public static class ChristmasTreeLogic
    {
        public static string Draw(int height, bool addStar = false)
        {
            if (height <= 0)
                throw new ArgumentException("Invalid height - has to be positive integer");

            List<string> output = [];

            if (addStar)
                output.Add(new string(' ', 2 + height) + new string('*', 1));

            for (int i = 0; i < height; i++)
                output.Add(new string(' ', 2 + height - i) + new string('X', 1 + 2 * i));

            output.Add(new string(' ', 2 + height) + new string('X', 1));

            return string.Join("\n", output);
        }
    }
}