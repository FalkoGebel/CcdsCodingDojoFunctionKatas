using _06_FilePathHelper;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("File Path Helper");

        while (true)
        {
            Console.Write("Enter a path to get the absolute path for it - 'q' to quit: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                Console.WriteLine($"Absolute path: {FilePathHelperLogic.GetAbsolutePath(input)}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}