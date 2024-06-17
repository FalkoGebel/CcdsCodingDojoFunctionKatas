using _01_CsvTable_izer;

Console.WriteLine("CSV Table-izer");

List<List<string>> examples =
    [
        ["Name;Street;City;Age",
         "Peter Pan;Am Hang 5;12345 Einsam;42",
         "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
         "Paul Meier;Münchener Weg 1;87654 München;65"],

        ["Name;Street;City;Age;Size",
         "Peter Pan;Am Hang 5;12345 Einsam;42;162",
         "Maria Schmitz;Kölner Straße 45;50123 Köln;43;171",
         "Paul Meier;Münchener Weg 1;87654 München;65;184"],

        ["Name;Street;City;Age",
         "Peter Pan;Am Hang 5;12345 Einsam;42",
         "Maria Schmitz;Kölner Straße 45;50123 Köln;43",
         "Hans Thomas Rothbert;Mainauer Straße 22;78465 Mainau;68",
         "Torb Max;Leipziger Straße 45;01234 Leipzig;21",
         "Paul Meier;Münchener Weg 1;87654 München;65"]
    ];

for (int i = 0; i < examples.Count; i++)
{
    Console.WriteLine($"\n\nExample {i + 1}\n######################################\n");

    foreach (string line in CsvTableizerLogic.ToTable(examples[i]))
        Console.WriteLine(line);
}