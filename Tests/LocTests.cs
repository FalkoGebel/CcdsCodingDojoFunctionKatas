using _05_Loc;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class LocTests
    {
        [TestMethod]
        public void Input_Empty_Code_String_and_get_Zero()
        {
            string sourceCode = string.Empty;
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(0);
        }

        [TestMethod]
        public void Input_One_Line_Excecutable_Code_and_get_1()
        {
            string sourceCode = "return 1;";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(1);
        }

        [TestMethod]
        public void Input_One_Line_Code_only_space_and_get_0()
        {
            string sourceCode = " ";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(0);
        }

        [TestMethod]
        public void Input_One_Line_Code_only_tab_and_get_0()
        {
            string sourceCode = "\t";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(0);
        }

        [TestMethod]
        public void Input_One_Line_Code_only_whitespaces_and_get_0()
        {
            string sourceCode = " \t \t";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(0);
        }

        [TestMethod]
        public void Input_Two_Line_Code_one_only_whitespaces_and_one_executable_and_get_1()
        {
            string sourceCode = " \t \t\nreturn 1";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(1);
        }

        [TestMethod]
        public void Input_Two_Line_Code_one_whitespaces_and_other_and_one_executable_and_get_2()
        {
            string sourceCode = " \t \tint i = 0;\nreturn 1";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(2);
        }

        [TestMethod]
        public void Input_Two_Line_Code_one_comment_and_one_executable_and_get_1()
        {
            string sourceCode = "//int i = 0;\nreturn 1";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(1);
        }

        [TestMethod]
        public void Input_Two_Line_Code_one_line_with_comment_and_one_executable_and_get_2()
        {
            string sourceCode = "int i = 0; // init\nreturn 1";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(2);
        }

        [TestMethod]
        public void Input_Two_Line_Code_one_line_with_open_close_comment_and_one_executable_and_get_1()
        {
            string sourceCode = "/* init */\nreturn 1";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(1);
        }

        [TestMethod]
        public void Input_Two_Line_Code_with_two_line_comment_get_0()
        {
            string sourceCode = "/* init \nreturn 1*/";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(0);
        }

        [TestMethod]
        public void Input_Four_Line_Code_with_two_line_comment_and_two_executables_get_2()
        {
            string sourceCode = "int i = 0;\n/* init \nreturn 1*/\nreturn -1;";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(2);
        }

        [TestMethod]
        public void Input_Four_Line_Code_with_comment_in_string_get_4()
        {
            string sourceCode = "int i = 0;\nstring a = \"/* init\"\nreturn \"1 - */\"\nreturn -1;";
            LocLogic.GetNumberOfLoc(sourceCode).Should().Be(4);
        }
    }
}
