
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

            // Try to parse the description directly to DateTime and return it, if it works
            if (DateTime.TryParseExact(followupDescription, "MMMd-htt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDate))
                return newDate;

            if (!char.IsDigit(followupDescription[0]))
                throw new ArgumentException($"Invalid email - invalid description {followupDescription} before \"{endPattern}\"");

            // TODO - year, month, week, day, hour, min -> start with number

            throw new ArgumentException($"Invalid email - invalid description {followupDescription} before \"{endPattern}\"");
        }
    }
}
