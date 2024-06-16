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
                                     "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
                                     "Paul Meier;Münchener Weg 1;87654 München;65"];
            List<string> expected = ["Name         |Street          |City         |Age|",
                                     "-------------+----------------+-------------+---+",
                                     "Peter Pan    |Am Hang 5       |12345 Einsam |42 |",
                                     "Maria Schmitz|Kölner Straße 45|50123 Köln   |43 |",
                                     "Paul Meier   |Münchener Weg 1 |87654 München|65 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }
    }
}