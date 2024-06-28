namespace _06_FilePathHelper
{
    public static class FilePathHelperLogic
    {
        public static object GetAbsolutePath(string input)
        {
            try
            {
                string? check = Path.GetDirectoryName(input);
                if (string.IsNullOrEmpty(check))
                    ThrowArgumentException();
            }
            catch (ArgumentException)
            {
                ThrowArgumentException();
            }

            string basePath = string.Empty;
            bool startWithDelimiter = false;

            if (input.StartsWith('~'))
            {
                if (!input.StartsWith($"~{Path.DirectorySeparatorChar}"))
                    ThrowArgumentException();

                basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
            else if (input.StartsWith('.'))
            {
                if (!input.StartsWith($".{Path.DirectorySeparatorChar}"))
                    ThrowArgumentException();

                basePath = Directory.GetCurrentDirectory();
            }
            else if (input.StartsWith(Path.DirectorySeparatorChar))
                startWithDelimiter = true;

            List<string> outputParts = basePath != string.Empty ? [.. basePath.Split(Path.DirectorySeparatorChar)] : [];
            List<string> inputParts = [.. input.Split(Path.DirectorySeparatorChar)];

            for (int i = basePath == string.Empty ? 0 : 1; i < inputParts.Count; i++)
            {
                string current = inputParts[i];

                if ((current == "..") || (i < inputParts.Count - 1 && inputParts[i + 1] == ".."))
                    continue;

                outputParts.Add(current);
            }

            if (outputParts.Any(p => p != string.Empty && p.All(c => c == '.')))
                ThrowArgumentException();

            string output = $"{(startWithDelimiter ? Path.DirectorySeparatorChar : "")}" + Path.Join([.. outputParts]);

            return output;
        }

        private static void ThrowArgumentException()
        {
            throw new ArgumentException("Invalid path");
        }
    }
}