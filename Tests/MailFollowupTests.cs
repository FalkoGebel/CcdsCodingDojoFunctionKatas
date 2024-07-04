using _07_MailFollowup;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class MailFollowupTests
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow("email")]
        [DataRow("@followup.cc")]
        [DataRow("email@followup.cc")]
        [DataRow("augu15-9am@followup.cc")]
        [DataRow("june15-9am@followup.cc")]
        [DataRow("1date@followup.cc")]
        [DataRow("1days@followup.cc")]
        [DataRow("2month@followup.cc")]
        [DataRow("2months0hour@followup.cc")]
        [DataRow("2months3months@followup.cc")]
        public void Given_Input_is_not_a_valid_mail_followup_email_address_and_argument_exception(string email)
        {
            Action act = () => MailFollowupLogic.FollowupPointInTime(DateTime.Today, email);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Input_7days_as_description_and_returns_correct_datetime_2()
        {
            DateTime now = DateTime.Now;
            DateTime expected = now.AddDays(7);
            MailFollowupLogic.FollowupPointInTime(now, "7days@followup.cc").Should().Be(expected);
        }

        [TestMethod]
        public void Input_1day_as_description_and_returns_correct_datetime_2()
        {
            DateTime now = DateTime.Now;
            DateTime expected = now.AddDays(1);
            MailFollowupLogic.FollowupPointInTime(now, "1day@followup.cc").Should().Be(expected);
        }

        [TestMethod]
        public void Input_2Weeks1day_as_description_and_returns_correct_datetime_2()
        {
            DateTime now = DateTime.Now;
            DateTime expected = now.AddDays(14).AddDays(1);
            MailFollowupLogic.FollowupPointInTime(now, "2weeks1day@followup.cc").Should().Be(expected);
        }

        [TestMethod]
        public void Input_1Year2Weeks1day_as_description_and_returns_correct_datetime_2()
        {
            DateTime now = DateTime.Now;
            DateTime expected = now.AddYears(1).AddDays(14).AddDays(1);
            MailFollowupLogic.FollowupPointInTime(now, "1year2weeks1day@followup.cc").Should().Be(expected);
        }

        [TestMethod]
        public void Input_2Years3Months2Weeks1day12hours15mins_as_description_and_returns_correct_datetime_2()
        {
            DateTime now = DateTime.Now;
            DateTime expected = now.AddYears(2).AddMonths(3).AddDays(14).AddDays(1).AddHours(12).AddMinutes(15);
            MailFollowupLogic.FollowupPointInTime(now, "2years3months2weeks1day12hours15mins@followup.cc").Should().Be(expected);
        }
    }
}
