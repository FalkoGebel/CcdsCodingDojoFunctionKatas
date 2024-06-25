
namespace _04_HappyNumbers
{
    public static class HappyNumbersLogic
    {
        public static bool IsHappy(int num)
        {
            List<int> founds = [];

            while (!founds.Contains(num))
            {
                founds.Add(num);
                string nStr = num.ToString();
                num = 0;
                foreach (char d in nStr)
                    num += (int)Math.Pow(int.Parse($"{d}"), 2);

                if (num == 1)
                    return true;
            }

            return false;
        }
    }
}
