namespace _03_FromRomanNumerals
{
    public class RomanNumeralsLogic
    {
        readonly private static string[] _romanNumerals = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];
        readonly private static int[] _romanValues = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];

        public static int GetDecimalFromRomanNumeral(string romanNumeral)
        {
            int output = 0;
            string numeral = romanNumeral;

            for (int i = 0; i < _romanNumerals.Length; i++)
            {
                int counter = 0,
                    skip = 0;

                while (numeral.StartsWith(_romanNumerals[i]))
                {
                    if (_romanNumerals[i].Length == 2 && counter > 0)
                        ThrowInvalidRomanNumeralException(romanNumeral);

                    output += _romanValues[i];
                    numeral = numeral[_romanNumerals[i].Length..];
                    counter++;
                    skip = _romanNumerals[i] == "IX" || _romanNumerals[i] == "XC" || _romanNumerals[i] == "CM"
                        ? 3
                        : _romanNumerals[i].Length == 2 ? 1 : 0;
                }

                if (counter > 3)
                    ThrowInvalidRomanNumeralException(romanNumeral);

                i += skip;
            }

            if (numeral != string.Empty)
                ThrowInvalidRomanNumeralException(romanNumeral);

            if (output > 3000)
                throw new ArgumentException($"Only roman numerals between \"I\" and \"MMM\" allowed");

            return output;
        }

        private static void ThrowInvalidRomanNumeralException(string romanNumeral)
        {
            throw new ArgumentException($"\"{romanNumeral}\" is not a valid roman numeral");
        }
    }
}