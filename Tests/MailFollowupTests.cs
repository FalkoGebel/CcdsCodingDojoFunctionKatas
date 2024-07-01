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
        public void Given_Input_is_not_a_valid_mail_followup_email_address_and_argument_exception(string email)
        {
            Action act = () => MailFollowupLogic.FollowupPointInTime(DateTime.Today, email);
            act.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Input_valid_date_as_description_and_returns_correct_datetime_1()
        {
            MailFollowupLogic.FollowupPointInTime(DateTime.Today, "aug15-9am@followup.cc").Should().Be(new DateTime(2024, 08, 15, 9, 0, 0));
        }

        [TestMethod]
        public void Input_valid_date_as_description_and_returns_correct_datetime_2()
        {
            MailFollowupLogic.FollowupPointInTime(DateTime.Today, "jun15-9am@followup.cc").Should().Be(new DateTime(2024, 06, 15, 9, 0, 0));
        }
    }
}
