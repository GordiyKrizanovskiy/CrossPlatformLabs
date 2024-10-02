using Xunit;
using System;

namespace lab2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_N1_Returns0()
        {
            Console.WriteLine("Test for N = 1");
            int result = Program.MinimumOperations(1);
            Console.WriteLine($"Expected result: 0, Actual result: {result}");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_N5_Returns3()
        {
            Console.WriteLine("Test for N = 5");
            int result = Program.MinimumOperations(5);
            Console.WriteLine($"Expected result: 3, Actual result: {result}");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test_N10_Returns3()
        {
            Console.WriteLine("Test for N = 10");
            int result = Program.MinimumOperations(10);
            Console.WriteLine($"Expected result: 3, Actual result: {result}");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test_N15_Returns4()
        {
            Console.WriteLine("Test for N = 15");
            int result = Program.MinimumOperations(15);
            Console.WriteLine($"Expected result: 4, Actual result: {result}");
            Assert.Equal(4, result);
        }

        [Fact]
        public void Test_N20_Returns4()
        {
            Console.WriteLine("Test for N = 20");
            int result = Program.MinimumOperations(20);
            Console.WriteLine($"Expected result: 4, Actual result: {result}");
            Assert.Equal(4, result);
        }
    }
}
