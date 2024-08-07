namespace _13_ToRomanNumerals
{
    public static class ToRomanNumeralsLogic
    {
        readonly private static string[] _romanNumerals = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
        readonly private static int[] _romanValues = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];

        public static string GetRomanNumeralFromDecimal(string decimalNumber)
        {
            if (int.TryParse(decimalNumber, out int number))
            {
                if (number < 1 || number > 3000)
                    throw new ArgumentException("Invalid input - integer not between 1 and 3000");

                string output = string.Empty;

                for (int i = 0; i < _romanValues.Length; i++)
                {
                    while (number >= _romanValues[i])
                    {
                        output += _romanNumerals[i];
                        number -= _romanValues[i];
                    }

                    if (number == 0)
                        break;
                }

                return output;
            }
            else
            {
                throw new ArgumentException("Invalid input - not an integer");
            }
        }
    }
}
