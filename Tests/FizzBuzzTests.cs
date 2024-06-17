using _02_FizzBuzz;
using FluentAssertions;

namespace Tests
{
    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        public void Input_1_and_get_1()
        {
            FizzBuzzLogic.FizzBuzz(1).Should().Be(1.ToString());
        }

        [TestMethod]
        public void Input_2_and_get_2()
        {
            FizzBuzzLogic.FizzBuzz(2).Should().Be(2.ToString());
        }

        [TestMethod]
        public void Input_3_and_get_Fizz()
        {
            FizzBuzzLogic.FizzBuzz(3).Should().Be("Fizz");
        }

        [TestMethod]
        public void Input_4_and_get_4()
        {
            FizzBuzzLogic.FizzBuzz(4).Should().Be(4.ToString());
        }

        [TestMethod]
        public void Input_5_and_get_Buzz()
        {
            FizzBuzzLogic.FizzBuzz(5).Should().Be("Buzz");
        }

        [TestMethod]
        public void Input_6_and_get_Fizz()
        {
            FizzBuzzLogic.FizzBuzz(6).Should().Be("Fizz");
        }

        [TestMethod]
        public void Input_7_and_get_7()
        {
            FizzBuzzLogic.FizzBuzz(7).Should().Be(7.ToString());
        }

        [TestMethod]
        public void Input_10_and_get_Buzz()
        {
            FizzBuzzLogic.FizzBuzz(10).Should().Be("Buzz");
        }

        [TestMethod]
        public void Input_14_and_get_14()
        {
            FizzBuzzLogic.FizzBuzz(14).Should().Be(14.ToString());
        }

        [TestMethod]
        public void Input_15_and_get_FizzBuzz()
        {
            FizzBuzzLogic.FizzBuzz(15).Should().Be("FizzBuzz");
        }

        [TestMethod]
        public void Input_25_and_get_Buzz()
        {
            FizzBuzzLogic.FizzBuzz(25).Should().Be("Buzz");
        }

        [TestMethod]
        public void Input_30_and_get_FizzBuzz()
        {
            FizzBuzzLogic.FizzBuzz(30).Should().Be("FizzBuzz");
        }

        [TestMethod]
        public void Input_35_and_get_Buzz()
        {
            FizzBuzzLogic.FizzBuzz(35).Should().Be("Buzz");
        }
    }

    [TestClass]
    public class FizzBuzzVariantTests
    {
        [TestMethod]
        public void Input_1_and_get_1()
        {
            FizzBuzzLogic.FizzBuzz(1, true).Should().Be(1.ToString());
        }

        [TestMethod]
        public void Input_2_and_get_2()
        {
            FizzBuzzLogic.FizzBuzz(2, true).Should().Be(2.ToString());
        }

        [TestMethod]
        public void Input_3_and_get_Fizz()
        {
            FizzBuzzLogic.FizzBuzz(3, true).Should().Be("Fizz");
        }

        [TestMethod]
        public void Input_13_and_get_Fizz()
        {
            FizzBuzzLogic.FizzBuzz(13, true).Should().Be("Fizz");
        }

        [TestMethod]
        public void Input_35_and_get_FizzBuzz()
        {
            FizzBuzzLogic.FizzBuzz(35, true).Should().Be("FizzBuzz");
        }

        [TestMethod]
        public void Input_52_and_get_Buzz()
        {
            FizzBuzzLogic.FizzBuzz(52, true).Should().Be("Buzz");
        }
    }
}
