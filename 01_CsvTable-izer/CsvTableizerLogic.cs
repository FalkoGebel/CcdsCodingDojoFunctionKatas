namespace _01_CsvTable_izer
{
    public class CsvTableizerLogic
    {
        private static List<int> GetMaxColumnLengths(List<string> csvLines)
        {
            List<int> output = [];

            for (int i = 0; i < csvLines.Count; i++)
            {
                string[] line = csvLines[i].Split(";");

                if (i == 0)
                    while (output.Count < line.Length)
                        output.Add(0);

                for (int j = 0; j < line.Length; j++)
                    if (line[j].Length > output[j])
                        output[j] = line[j].Length;
            }

            return output;
        }

        public static List<string> ToTable(List<string> csvLines)
        {
            List<int> maxColLengths = GetMaxColumnLengths(csvLines);
            List<string> output =
                csvLines.Select(l
                    => string.Join("|", l.Split(";")
                                                  .Select((f, i) => f.PadRight(maxColLengths[i]))) + "|")
                        .ToList();

            output.Insert(1,
                          string.Join("+",
                                      Enumerable.Range(0, maxColLengths.Count)
                                                .Select(i => new string('-', maxColLengths[i]))) + "+");

            return output;
        }
    }
}
