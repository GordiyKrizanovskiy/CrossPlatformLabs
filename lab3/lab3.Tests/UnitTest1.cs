using System;
using Xunit;
using GK;

namespace lab3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestSmallExample1()
        {
            Console.WriteLine("Test 1: Testing with a small number of cities");
            double[][] cities = {
                new double[] { 0, 0 },
                new double[] { 2, 0 },
                new double[] { 0, 2 },
                new double[] { 2, 3 }
            };

            double result = CityDistanceCalculator.FindMinimumRadius(cities, cities.Length); 
            Console.WriteLine($"Expected result: 2.24, Actual result: {result:F2}");
            Assert.Equal(2.24, result, 2);
        }

        [Fact]
        public void TestSmallExample2()
        {
            Console.WriteLine("Test 2: Testing with another small number of cities");
            double[][] cities = {
                new double[] { 2, 0 },
                new double[] { 0, 2 },
                new double[] { 4, 2 }
            };

            double result = CityDistanceCalculator.FindMinimumRadius(cities, cities.Length);
            Console.WriteLine($"Expected result: 2.83, Actual result: {result:F2}");
            Assert.Equal(2.83, result, 2);
        }

        [Fact]
        public void TestLargeExample()
        {
            Console.WriteLine("Test 3: Testing with a larger number of cities");
            double[][] cities = {
                new double[] { 0, 0 },
                new double[] { 10, 0 },
                new double[] { 0, 10 },
                new double[] { 10, 10 },
                new double[] { 5, 5 }
            };

            double result = CityDistanceCalculator.FindMinimumRadius(cities, cities.Length);
            Console.WriteLine($"Expected result: 7.07, Actual result: {result:F2}");
            Assert.Equal(7.07, result, 2);
        }

        [Fact]
        public void TestIdenticalCoordinates()
        {
            Console.WriteLine("Test 4: Testing with identical city coordinates");
            double[][] cities = {
                new double[] { 0, 0 },
                new double[] { 0, 0 },
                new double[] { 0, 0 }
            };

            double result = CityDistanceCalculator.FindMinimumRadius(cities, cities.Length);
            Console.WriteLine($"Expected result: 0.00, Actual result: {result:F2}");
            Assert.Equal(0.00, result, 2);
        }

        [Fact]
        public void TestOneCity()
        {
            Console.WriteLine("Test 5: Testing with one city");
            double[][] cities = {
                new double[] { 0, 0 }
            };

            double result = CityDistanceCalculator.FindMinimumRadius(cities, cities.Length); 
            Console.WriteLine($"Expected result: 0.00, Actual result: {result:F2}");
            Assert.Equal(0.00, result, 2);
        }
    }
}
