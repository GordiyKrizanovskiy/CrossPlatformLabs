using System;
using System.IO;
using GK;

namespace lab3;
public class Program
{
    public static void Main()
    {
        string[] input = File.ReadAllLines("INPUT.TXT");
        int N = int.Parse(input[0]);
        double[][] cities = new double[N][];
        
        for (int i = 1; i <= N; i++)
        {
            string[] coordinates = input[i].Split();
            cities[i - 1] = new double[] { double.Parse(coordinates[0]), double.Parse(coordinates[1]) };
        }

        double minRadius = CityDistanceCalculator.FindMinimumRadius(cities, N);

        File.WriteAllText("OUTPUT.TXT", minRadius.ToString("F2"));
    }
}
