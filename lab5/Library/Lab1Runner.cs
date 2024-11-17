using System;
using System.IO;
using lab1; // Підключення простору імен для Lab1

namespace Library
{
    public static class Lab1Runner
    {
        public static void Run(string[] args)
        {
            string inputPath = GetFilePath(args, "-I", "--input");
            string outputPath = GetFilePath(args, "-o", "--output");

            Console.WriteLine("Запуск Lab1...");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл введення не знайдено.");
                return;
            }

            // Зчитуємо дані з input.txt
            string[] input = File.ReadAllLines(inputPath);
            string[] parts = input[0].Split();
            long a = long.Parse(parts[0]);
            long b = long.Parse(parts[1]);
            long c = long.Parse(parts[2]);

            // Виклик методу F з Lab1
            long result = Program.F(a, b, c);

            // Записуємо оброблені дані у output.txt
            File.WriteAllText(outputPath, result.ToString());
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
