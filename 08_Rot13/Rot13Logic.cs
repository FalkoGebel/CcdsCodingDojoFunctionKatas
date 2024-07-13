namespace _08_Rot13
{
    public static class Rot13Logic
    {
        public static object Encode(string input, int shift = 13, bool includeDigits = false)
        {
            string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (includeDigits)
                pool = "0123456789" + pool;

            string output = "";

            foreach (char c in input)
            {
                char cur = char.ToUpper(c);

                if (!pool.Contains(cur))
                {
                    output += c;
                    continue;
                }

                int newIdx = pool.IndexOf(cur) + shift;

                if (newIdx > pool.Length - 1)
                    newIdx = (newIdx + 1) % pool.Length - 1;

                output += pool[newIdx];
            }

            return output;
        }
    }
}