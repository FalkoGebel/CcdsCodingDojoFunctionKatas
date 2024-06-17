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
                                     "Maria Schmitz;K�lner Stra�e 45;50123 K�ln;43",
                                     "Paul Meier;M�nchener Weg 1;87654 M�nchen;65"];
            List<string> expected = ["Name         |Street          |City         |Age|",
                                     "-------------+----------------+-------------+---+",
                                     "Peter Pan    |Am Hang 5       |12345 Einsam |42 |",
                                     "Maria Schmitz|K�lner Stra�e 45|50123 K�ln   |43 |",
                                     "Paul Meier   |M�nchener Weg 1 |87654 M�nchen|65 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult_2()
        {
            List<string> CsvLines = ["Name;Street;City;Age;Size",
                                     "Peter Pan;Am Hang 5;12345 Einsam;42;162",
                                     "Maria Schmitz;K�lner Stra�e 45;50123 K�ln;43;171",
                                     "Paul Meier;M�nchener Weg 1;87654 M�nchen;65;184"];
            List<string> expected = ["Name         |Street          |City         |Age|Size|",
                                     "-------------+----------------+-------------+---+----+",
                                     "Peter Pan    |Am Hang 5       |12345 Einsam |42 |162 |",
                                     "Maria Schmitz|K�lner Stra�e 45|50123 K�ln   |43 |171 |",
                                     "Paul Meier   |M�nchener Weg 1 |87654 M�nchen|65 |184 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void CallToTableFunctionAndGetCorrectResult_3()
        {
            List<string> CsvLines = ["Name;Street;City;Age",
                                     "Peter Pan;Am Hang 5;12345 Einsam;42",
                                     "Maria Schmitz;K�lner Stra�e 45;50123 K�ln;43",
                                     "Hans Thomas Rothbert;Mainauer Stra�e 22;78465 Mainau;68",
                                     "Torb Max;Leipziger Stra�e 45;01234 Leipzig;21",
                                     "Paul Meier;M�nchener Weg 1;87654 M�nchen;65"];
            List<string> expected = ["Name                |Street             |City         |Age|",
                                     "--------------------+-------------------+-------------+---+",
                                     "Peter Pan           |Am Hang 5          |12345 Einsam |42 |",
                                     "Maria Schmitz       |K�lner Stra�e 45   |50123 K�ln   |43 |",
                                     "Hans Thomas Rothbert|Mainauer Stra�e 22 |78465 Mainau |68 |",
                                     "Torb Max            |Leipziger Stra�e 45|01234 Leipzig|21 |",
                                     "Paul Meier          |M�nchener Weg 1    |87654 M�nchen|65 |"];

            CsvTableizerLogic.ToTable(CsvLines).Should().BeEquivalentTo(expected);
        }
    }
}