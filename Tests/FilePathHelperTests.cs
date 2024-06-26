﻿using _06_FilePathHelper;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class FilePathHelperTests
    {
        [DataTestMethod]
        [DataRow($"~\\Downloads\\mountains.jpg", "\\Downloads\\mountains.jpg")]
        public void Input_valid_relative_path_and_get_absolute_home_path(string input, string expected)
        {
            List<string> parts = [.. Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).Split(Path.DirectorySeparatorChar)];

            foreach (string p in expected.Split(Path.DirectorySeparatorChar))
                parts.Add(p);

            expected = Path.Join([.. parts]);

            FilePathHelperLogic.GetAbsolutePath(input).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(".\\Downloads\\mountains.jpg", "\\Downloads\\mountains.jpg")]
        public void Input_valid_relative_path_and_get_absolute_working_path(string input, string expected)
        {
            List<string> parts = [.. Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar)];

            foreach (string p in expected.Split(Path.DirectorySeparatorChar))
                parts.Add(p);

            expected = Path.Join([.. parts]);

            FilePathHelperLogic.GetAbsolutePath(input).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("\\Downloads\\Projects\\ETF\\..\\mountains.jpg", "\\Downloads\\Projects\\mountains.jpg")]
        [DataRow("\\Downloads\\Projects\\ETF\\..\\..\\mountains.jpg", "\\Downloads\\Projects\\mountains.jpg")]
        [DataRow("\\Downloads\\..\\Projects\\ETF\\..\\mountains.jpg", "\\Projects\\mountains.jpg")]
        public void Input_valid_relative_path_and_get_shortened_path(string input, string expected)
        {
            List<string> parts = [];

            foreach (string p in expected.Split(Path.DirectorySeparatorChar))
                parts.Add(p);

            expected = Path.DirectorySeparatorChar + Path.Join([.. parts]);

            FilePathHelperLogic.GetAbsolutePath(input).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow("C:\\Downloads\\Projects\\ETF\\..\\mountains.jpg", "C:\\Downloads\\Projects\\mountains.jpg")]
        [DataRow("C:\\Downloads\\Projects\\ETF\\..\\..\\mountains.jpg", "C:\\Downloads\\Projects\\mountains.jpg")]
        [DataRow("C:\\Downloads\\..\\Projects\\ETF\\..\\mountains.jpg", "C:\\Projects\\mountains.jpg")]
        public void Input_valid_absolute_path_and_get_shortened_path(string input, string expected)
        {
            List<string> parts = [];

            foreach (string p in expected.Split(Path.DirectorySeparatorChar))
                parts.Add(p);

            expected = Path.Join([.. parts]);

            FilePathHelperLogic.GetAbsolutePath(input).Should().Be(expected);
        }

        [DataTestMethod]
        [DataRow(".\\...\\mountains.jpg")]
        [DataRow("~\\.\\mountains.jpg")]
        [DataRow(".\\.\\mountains.jpg")]
        [DataRow("~abc\\path\\mountains.jpg")]
        [DataRow(".abc\\path\\mountains.jpg")]
        [DataRow("abc")]
        [DataRow("~~\\path\\mountains.jpg")]
        public void Input_invalid_relative_path_and_get_argument_exception(string input)
        {
            Action act = () => FilePathHelperLogic.GetAbsolutePath(input);
            act.Should().Throw<ArgumentException>();
        }
    }
}