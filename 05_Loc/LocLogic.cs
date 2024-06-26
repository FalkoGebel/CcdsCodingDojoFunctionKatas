using System.Text.RegularExpressions;

namespace _05_Loc
{
    public partial class LocLogic
    {
        [GeneratedRegex(@"\s")]
        private static partial Regex WhiteSpaces();

        [GeneratedRegex("\"([^\"]*)\"")]
        private static partial Regex Strings();

        private readonly static string _comment = "//";
        private readonly static string _open = "/*";
        private readonly static string _close = "*/";

        public static int GetNumberOfLoc(string sourceCode)
        {
            if (sourceCode == string.Empty)
                return 0;

            int output = 0;

            bool open = false;
            foreach (string line in sourceCode.Split("\n"))
            {
                string current = WhiteSpaces().Replace(line, "");
                current = Strings().Replace(current, "");

                if (current.Length == 0)
                    continue;

                if (open && !current.Contains(_close))
                    continue;

                bool isFirst = true;

                while ((open && current.Contains(_close)) || (!open && current.Contains(_open)))
                {
                    if (open)
                    {
                        int closeIdx = current.IndexOf(_close);
                        if (current.Length > closeIdx + 2)
                            current = current[(closeIdx + 2)..];
                        else
                            current = string.Empty;
                    }
                    else
                    {
                        int openIdx = current.IndexOf(_open);

                        if (isFirst)
                        {
                            if (openIdx > 0)
                                output++;
                            isFirst = false;
                        }

                        if (current.Length > openIdx + 2)
                            current = current[(openIdx + 2)..];
                        else
                            current = string.Empty;
                    }

                    open = !open;
                }

                if (open)
                    continue;

                int idx = current.IndexOf(_comment);
                output += current != string.Empty && idx != 0 ? 1 : 0;
            }

            return output;
        }
    }
}