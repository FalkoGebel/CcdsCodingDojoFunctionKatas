using _11_WordWrap;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Word Wrap");

        while (true)
        {
            Console.Write("Do you want to show the Loriot example? - 'y' to start: ");
            string? input = Console.ReadLine();
            string loriot = "Es blaut die Nacht,\ndie Sternlein blinken,\nSchneeflöcklein leis hernieder sinken.";

            if (input == null || input == string.Empty)
                continue;

            if (input != "y")
                break;

            try
            {
                Console.Write("Length of lines: ");
                input = Console.ReadLine();
                int length = int.Parse(input);
                Console.Write("Use justified text? (y)es or else: ");
                input = Console.ReadLine();
                bool justified = input == "y";
                if (length <= 0)
                    Console.WriteLine("Invalid input: Length has to be a positive integer");
                else
                    Console.WriteLine($"The Loriot exampel for your lenght of \"{length}\":\n\n{WordWrapLogic.Wrap(loriot, length, justified)}\n");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message + " - you have to input a positive integer");
            }
        }
    }
}