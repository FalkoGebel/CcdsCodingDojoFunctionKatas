internal class Program
{
    private static void Main()
    {
        Console.WriteLine("File Path Helper");

        while (true)
        {
            Console.Write("Enter a relative path to get the absolute path for it - 'q' to quit: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            // TODO - work with the input
        }
    }
}