
namespace _02_FizzBuzz
{
    public class FizzBuzzLogic
    {
        /*
        public static string FizzBuzz(int v)
        {
            string output = string.Empty;

            if (v % 3 == 0)
                output += "Fizz";

            if (v % 5 == 0)
                output += "Buzz";

            return output != string.Empty ? output : v.ToString();
        }
        */

        public static string FizzBuzz(int v, bool useVariant = false)
        {
            string output = string.Empty;

            if (v % 3 == 0 || (useVariant && v.ToString().Contains('3')))
                output += "Fizz";

            if (v % 5 == 0 || (useVariant && v.ToString().Contains('5')))
                output += "Buzz";

            return output != string.Empty ? output : v.ToString();
        }
    }
}
