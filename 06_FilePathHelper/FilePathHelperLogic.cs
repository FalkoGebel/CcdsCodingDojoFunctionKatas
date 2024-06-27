namespace _06_FilePathHelper
{
    public static class FilePathHelperLogic
    {
        public static object GetAbsolutePath(string input)
        {
            string basePath = string.Empty;

            if (input.StartsWith('~'))
                basePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            else if (input.StartsWith('.'))
                basePath = Directory.GetCurrentDirectory();

            List<string> outputParts = [.. basePath.Split(Path.DirectorySeparatorChar)];
            List<string> inputParts = [.. input.Split(Path.DirectorySeparatorChar)];

            for (int i = 1; i < inputParts.Count; i++)
                outputParts.Add(inputParts[i]);

            if (outputParts.Any(p => p.All(c => c == '.')))
                throw new ArgumentException("Invalid relative path");

            string output = Path.Join([.. outputParts]);

            return output;
        }
    }
}