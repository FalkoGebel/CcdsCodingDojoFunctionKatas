using _09_RussianPeasantMultiplication;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Russian Peasant Multiplication");

        while (true)
        {
            Console.Write("Want to multiply two numbers using the russian peasant multiplication? - 'y' to start: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input != "y")
                break;

            try
            {
                Console.Write("First factor: ");
                input = Console.ReadLine();
                int firstFactor = int.Parse(input);
                Console.Write("Second factor: ");
                input = Console.ReadLine();
                int secondFactor = int.Parse(input);
                if (firstFactor <= 0 || secondFactor <= 0)
                {
                    Console.WriteLine("Invalid input: Both factors have to be positive integers");
                }
                else
                    Console.WriteLine($"{firstFactor} * {secondFactor} = {RussianPeasantMultiplicationLogic.Mul(firstFactor, secondFactor)}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message + " - you have to input a positive integer");
            }
        }
    }
}