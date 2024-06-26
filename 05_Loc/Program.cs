using _05_Loc;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("LOC - Lines of Code");

        while (true)
        {
            Console.Write("Enter a file to check for its number of LOC - 'q' to quit: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                Console.WriteLine($"Number of LOC of your file: {LocLogic.GetNumberOfLoc(File.ReadAllText(input))}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Your file was not found");
            }
            catch (IOException)
            {
                Console.WriteLine($"The given path was not valid. Make sure that you do not insert quotation marks at the beginning and/or end.");
            }
        }
    }
}