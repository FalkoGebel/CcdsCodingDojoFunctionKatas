internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Mail Followup");

        while (true)
        {
            Console.Write("Enter a mail followup email addresses to get the new date and time for it calculated from now - 'q' to quit: ");
            string? input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "q")
                break;

            try
            {
                Console.WriteLine($"new date and time for {input}: ???");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}