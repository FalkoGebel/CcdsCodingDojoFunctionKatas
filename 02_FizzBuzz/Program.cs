using _02_FizzBuzz;

Console.WriteLine("FizzBuzz\n");

for (int i = 1; i <= 100; i++)
    Console.WriteLine($"{i,-5} -> {FizzBuzzLogic.FizzBuzz(i)}");

Console.WriteLine("\n\nFizzBuzz Variant\n");

for (int i = 1; i <= 100; i++)
    Console.WriteLine($"{i,-5} -> {FizzBuzzLogic.FizzBuzz(i, true)}");