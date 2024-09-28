using Xunit;
using System;
using lab1;

namespace lab1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_F_LargeValues()
        {
            long expected = Program.F(20, 20, 20);
            long actual = Program.F(21, 21, 21);

            Console.WriteLine($"Test_F_LargeValues: expected = {expected}, actual = {actual}");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_F_SimpleCase()
        {
            long result = Program.F(10, 5, 6);

            Console.WriteLine($"Test_F_SimpleCase: result = {result}");

            Assert.Equal(result, Program.F(10, 5, 6));
        }

        [Fact]
        public void Test_F_NegativeValues()
        {
            long result1 = Program.F(-1, 0, 0);
            long result2 = Program.F(0, 0, 0);
            long result3 = Program.F(0, -5, 0);

            Console.WriteLine($"Test_F_NegativeValues: result1 = {result1}, result2 = {result2}, result3 = {result3}");

            Assert.Equal(1, result1);
            Assert.Equal(1, result2);
            Assert.Equal(1, result3);
        }

        [Fact]
        public void Test_F_BoundaryValues()
        {
            long result = Program.F(20, 20, 20);

            Console.WriteLine($"Test_F_BoundaryValues: result = {result}");

            Assert.Equal(result, Program.F(20, 20, 20));
        }

        [Fact]
        public void Test_F_ComplexCase()
        {
            long result = Program.F(15, 20, 10);

            Console.WriteLine($"Test_F_ComplexCase: result = {result}");

            Assert.Equal(result, Program.F(15, 20, 10));
        }
    }
}
