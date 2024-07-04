using System.Globalization;

namespace _07_MailFollowup
{
    public static class MailFollowupLogic
    {
        public static DateTime FollowupPointInTime(DateTime baseDate, string email)
        {
            string endPattern = "@followup.cc";

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email - must not be empty");

            if (!email.EndsWith(endPattern))
                throw new ArgumentException($"Invalid email - has end with \"{endPattern}\"");

            string followupDescription = email[..email.IndexOf(endPattern)];

            if (string.IsNullOrEmpty(followupDescription))
                throw new ArgumentException($"Invalid email - needs a description before \"{endPattern}\"");

            // Try to parse the description directly to DateTime and return it, if it works -> when before given date, add a year
            if (DateTime.TryParseExact(followupDescription, "MMMd-htt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
                return newDate < baseDate ? newDate.AddYears(1) : newDate;

            if (!char.IsDigit(followupDescription[0]) || followupDescription.Any(c => !char.IsLetterOrDigit(c)))
                throw new ArgumentException($"Invalid email - invalid description \"{followupDescription}\" before \"{endPattern}\"");

            string desc = followupDescription;
            Dictionary<string, int> values = new() { { "year", 0 }, { "month", 0 }, { "week", 0 }, { "day", 0 }, { "hour", 0 }, { "min", 0 } };

            bool lastDigit = true;
            string num = string.Empty;
            string value = string.Empty;

            foreach (char c in followupDescription)
            {
                if (char.IsLetter(c))
                {
                    value += c;
                    lastDigit = false;
                }
                else
                {
                    if (!lastDigit)
                    {
                        PutValueIntoDictionary(values, num, value, followupDescription);
                        num = string.Empty + c;
                        value = string.Empty;
                        lastDigit = true;
                    }
                    else
                        num += c;
                }
            }

            PutValueIntoDictionary(values, num, value, followupDescription);

            return baseDate.AddYears(values["year"])
                           .AddMonths(values["month"])
                           .AddDays(values["week"] * 7)
                           .AddDays(values["day"])
                           .AddHours(values["hour"])
                           .AddMinutes(values["min"]);
        }

        private static void PutValueIntoDictionary(Dictionary<string, int> values, string number, string value, string desc)
        {
            int num = int.Parse(number);

            if (num == 0)
                throw new ArgumentException($"Invalid email - number must not be zero within description \"{desc}\"");

            if ((num == 1 && value.EndsWith('s')) || (num > 1 && !value.EndsWith('s')))
                throw new ArgumentException($"Invalid email - invalid combination from number \"{num}\" and value \"{value}\" within description \"{desc}\"");

            string dictValue = value.EndsWith('s') ? value[..^1] : value;

            if (!values.ContainsKey(dictValue))
                throw new ArgumentException($"Invalid email - invalid value \"{value}\" within description \"{desc}\"");

            if (values[dictValue] != 0)
                throw new ArgumentException($"Invalid email - repeated value \"{value}\" within description \"{desc}\"");

            values[dictValue] = num;
        }
    }
}
