using _13_ToRomanNumerals;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("To Roman Numerals");

        while (true)
        {
            Console.WriteLine("Enter a positive integer between 100 and 3000 - 'q' to quit:");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                Console.WriteLine($"Result: {ToRomanNumeralsLogic.GetRomanNumeralFromDecimal(input)}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Error: {ae.Message}");
            }
        }
    }
}