using _01_CsvTable_izer;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class CsvTableizerTests
    {
        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult_1()
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

        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult_2()
        {
            List<string> CsvLines = ["Name;Street;City;Age;Size",
                                     "Peter Pan;Am Hang 5;12345 Einsam;42;162",
                                     "Maria Schmitz;Kölner Straße 45;50123 Köln;43;171",
                                     "Paul Meier;Münchener Weg 1;87654 München;65;184"];
            List<string> expected = ["Name         |Street          |City         |Age|Size|",
                                     "-------------+----------------+-------------+---+----+",
                                     "Peter Pan    |Am Hang 5       |12345 Einsam |42 |162 |",
                                     "Maria Schmitz|Kölner Straße 45|50123 Köln   |43 |171 |",
                                     "Paul Meier   |Münchener Weg 1 |87654 München|65 |184 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult_3()
        {
            List<string> CsvLines = ["Name;Street;City;Age",
                                     "Peter Pan;Am Hang 5;12345 Einsam;42",
                                     "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
                                     "Hans Thomas Rothbert;Mainauer Straße 22;78465 Mainau;68",
                                     "Torb Max;Leipziger Straße 45;01234 Leipzig;21",
                                     "Paul Meier;Münchener Weg 1;87654 München;65"];
            List<string> expected = ["Name                |Street             |City         |Age|",
                                     "--------------------+-------------------+-------------+---+",
                                     "Peter Pan           |Am Hang 5          |12345 Einsam |42 |",
                                     "Maria Schmitz       |Kölner Straße 45   |50123 Köln   |43 |",
                                     "Hans Thomas Rothbert|Mainauer Straße 22 |78465 Mainau |68 |",
                                     "Torb Max            |Leipziger Straße 45|01234 Leipzig|21 |",
                                     "Paul Meier          |Münchener Weg 1    |87654 München|65 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }
    }
}