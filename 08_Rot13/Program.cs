using _08_Rot13;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("ROT-13");

        while (true)
        {
            Console.Write("Want to encode a text? - 'y' to start: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input != "y")
                break;

            try
            {
                Console.Write("What shift do you want to use?: ");
                input = Console.ReadLine();
                int shift = int.Parse(input);
                Console.Write("Do you want to include digits? - 'y' to include: ");
                input = Console.ReadLine();
                bool includeDigits = input == "y";
                Console.Write("Text to encode: ");
                input = Console.ReadLine();
                Console.WriteLine($"Your encode text for your input \"{input}\": {Rot13Logic.Encode(input, shift, includeDigits)}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}