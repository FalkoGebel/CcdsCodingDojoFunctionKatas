using _04_HappyNumbers;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Happy Numbers");

        while (true)
        {
            Console.Write("Enter a number to check for its happiness - 'q' to quit: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                int number = int.Parse(input);
                Console.WriteLine($"{number} is a {(number > 0 && HappyNumbersLogic.IsHappy(number) ? "" : "un")}happy number.");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Your input was not a valid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Your number was way to small or way to large for this little program");
            }
        }
    }
}