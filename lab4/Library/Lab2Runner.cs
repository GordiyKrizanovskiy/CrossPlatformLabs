using System;
using System.IO;
using lab2; // Підключення простору імен для Lab2

namespace Library
{
    public static class Lab2Runner
    {
        public static void Run(string[] args)
        {
            string inputPath = GetFilePath(args, "-I", "--input", "INPUT.TXT");
            string outputPath = GetFilePath(args, "-o", "--output", "OUTPUT.TXT");

            Console.WriteLine("Запуск Lab2...");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Файл введення не знайдено.");
                return;
            }

            // Зчитуємо число N із файлу INPUT.TXT
            int N = int.Parse(File.ReadAllText(inputPath));

            // Викликаємо метод MinimumOperations з Lab2 для обчислень
            int result = Program.MinimumOperations(N);

            // Записуємо результат у файл OUTPUT.TXT
            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine($"Результат збережено в {outputPath}");
        }

        private static string GetFilePath(string[] args, string shortArg, string longArg, string defaultFileName)
        {
            int index = Array.IndexOf(args, shortArg);
            if (index == -1) index = Array.IndexOf(args, longArg);

            if (index != -1 && index + 1 < args.Length)
                return args[index + 1];

            return Path.Combine(Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), defaultFileName);
        }
    }
}
