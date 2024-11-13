using System;
using Library;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintUsage();
                return;
            }

            switch (args[0])
            {
                case "version":
                    Console.WriteLine("Автор: Ваше Ім'я");
                    Console.WriteLine("Версія: 1.0.0");
                    break;
                
                case "run":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Будь ласка, вкажіть яку лабораторну роботу запустити (lab1, lab2, або lab3).");
                        return;
                    }
                    RunLab(args[1], args);
                    break;

                case "set-path":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Будь ласка, вкажіть шлях за допомогою параметра -p або --path.");
                        return;
                    }
                    SetLabPath(args[2]);
                    break;

                default:
                    PrintUsage();
                    break;
            }
        }

        static void PrintUsage()
        {
            Console.WriteLine("Використання:");
            Console.WriteLine(" dotnettool version                   - відображає версію програми");
            Console.WriteLine(" dotnettool run <lab1|lab2|lab3> [-I <input file>] [-o <output file>] - запуск лабораторної роботи");
            Console.WriteLine(" dotnettool set-path -p <path>       - встановлює шлях до папки з інпут та аутпут файлами");
        }

        static void RunLab(string lab, string[] args)
        {
            switch (lab.ToLower())
            {
                case "lab1":
                    Lab1Runner.Run(args);
                    break;
                case "lab2":
                    Lab2Runner.Run(args);
                    break;
                case "lab3":
                    Lab3Runner.Run(args);
                    break;
                default:
                    Console.WriteLine("Невідома лабораторна робота. Доступні варіанти: lab1, lab2, lab3.");
                    break;
            }
        }

        static void SetLabPath(string path)
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path);
            Console.WriteLine($"LAB_PATH встановлено на {path}");
        }
    }
}
