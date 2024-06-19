using _03_FromRomanNumerals;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("From Roman Numerals");

        while (true)
        {
            Console.WriteLine("Enter roman numeral (max. \"MMM\") - 'q' to quit:");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                Console.WriteLine($"Result: {RomanNumeralsLogic.GetDecimalFromRomanNumeral(input)}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Error: {ae.Message}");
            }
        }
    }
}