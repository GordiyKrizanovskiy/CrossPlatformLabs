using System;
using System.IO;
using System.Collections.Generic;
using GK; // Підключення простору імен для CityDistanceCalculator

namespace Library
{
    public static class Lab3Runner
    {
        public static void Run(string[] args)
        {
            string inputPath = GetFilePath(args, "-I", "--input");
            string outputPath = GetFilePath(args, "-o", "--output");

            Console.WriteLine("Запуск Lab3...");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл введення не знайдено.");
                return;
            }

            // Зчитуємо дані з INPUT.TXT та обробляємо координати міст
            string[] lines = File.ReadAllLines(inputPath);
            int N = int.Parse(lines[0]); // Перша лінія – кількість міст

            // Зберігаємо координати міст у масиві
            double[][] cities = new double[N][];
            for (int i = 0; i < N; i++)
            {
                string[] parts = lines[i + 1].Split();
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);
                cities[i] = new double[] { x, y };
            }

            // Викликаємо FindMinimumRadius для обчислення мінімального радіуса
            double result = CityDistanceCalculator.FindMinimumRadius(cities, N);

            // Записуємо результат у файл OUTPUT.TXT
            File.WriteAllText(outputPath, result.ToString("F6")); // Форматування до 6 знаків після коми
            Console.WriteLine($"Результат збережено в {outputPath}");
        }

        private static string GetFilePath(string[] args, string shortArg, string longArg)
        {
            int index = Array.IndexOf(args, shortArg);
            if (index == -1) index = Array.IndexOf(args, longArg);

            if (index != -1 && index + 1 < args.Length)
                return args[index + 1];

            return Path.Combine(Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "INPUT.TXT");
        }
    }
}
