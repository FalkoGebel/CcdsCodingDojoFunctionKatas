using _10_ChristmasTree;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Christmas Tree");

        while (true)
        {
            Console.Write("Want to draw a christmas tree? - 'y' to start: ");
            string? input = Console.ReadLine();

            if (input == null || input == string.Empty)
                continue;

            if (input != "y")
                break;

            try
            {
                Console.Write("Height: ");
                input = Console.ReadLine();
                int height = int.Parse(input);
                Console.Write("With star? (y)es or else: ");
                input = Console.ReadLine();
                bool addStar = input == "y";
                if (height <= 0)
                    Console.WriteLine("Invalid input: Height has to be a positive integer");
                else
                    Console.WriteLine($"Your with height \"{height}\" and with{(addStar ? "" : "out")}:\n\n{ChristmasTreeLogic.Draw(height, addStar)}\n");
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message + " - you have to input a positive integer");
            }
        }
    }
}