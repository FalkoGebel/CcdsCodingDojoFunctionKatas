namespace _09_RussianPeasantMultiplication
{
    public static class RussianPeasantMultiplicationLogic
    {
        public static int Mul(int first, int second)
        {
            if (first <= 0 || second <= 0)
                throw new ArgumentException("Both factors has to be positive");

            if (first == 1)
                return second;

            int output = 0;

            do
            {
                if (first % 2 == 1)
                    output += second;

                first /= 2;
                second *= 2;

            } while (first > 1);

            return output + second;
        }
    }
}