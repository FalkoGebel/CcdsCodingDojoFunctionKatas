using _14_CountCharacters;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Count Characters");

        while (true)
        {
            Console.WriteLine("\nWould you like to count characters? (Y)es or not?");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input.ToLower() != "y")
                break;

            Console.WriteLine("Treat upper and lower case letters equally? (Y)es or not?");
            input = Console.ReadLine();
            bool upperAndLowerCaseLettersEqually = input != null && input.ToLower() == "y";

            Console.WriteLine($"Input your text: ");
            input = Console.ReadLine();

            if (input == null)
                input = string.Empty;

            Console.WriteLine($"Result: {string.Join(", ",
                CountCharactersLogic.CountCharacters(input, upperAndLowerCaseLettersEqually)
                                    .Select(kpv => $"'{kpv.Key}': {kpv.Value}"))}");
        }
    }
}