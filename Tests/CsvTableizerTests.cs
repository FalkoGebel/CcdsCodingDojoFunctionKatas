using _01_CsvTable_izer;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class CsvTableizerTests
    {
        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult()
        {
            List<string> CsvLines = ["Name;Street;City;Age",
                                     "Peter Pan;Am Hang 5;12345 Einsam;42",
                                     "Maria Schmitz;K�lner Stra�e 45;50123 K�ln;43",
                                     "Paul Meier;M�nchener Weg 1;87654 M�nchen;65"];
            List<string> expected = ["Name         |Street          |City         |Age|",
                                     "-------------+----------------+-------------+---+",
                                     "Peter Pan    |Am Hang 5       |12345 Einsam |42 |",
                                     "Maria Schmitz|K�lner Stra�e 45|50123 K�ln   |43 |",
                                     "Paul Meier   |M�nchener Weg 1 |87654 M�nchen|65 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }
    }
}