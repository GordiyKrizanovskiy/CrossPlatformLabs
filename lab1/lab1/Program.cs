using System;
using System.Collections.Generic;

namespace lab1;
public class Program
{
    static Dictionary<(long, long, long), long> memo = new Dictionary<(long, long, long), long>();

    public static long F(long a, long b, long c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return 1;
        if (a > 20 || b > 20 || c > 20)
            return F(20, 20, 20);

        if (memo.ContainsKey((a, b, c)))
            return memo[(a, b, c)];

        long result;
        if (a < b && b < c)
            result = F(a, b, c - 1) + F(a, b - 1, c - 1) - F(a, b - 1, c);
        else
            result = F(a - 1, b, c) + F(a - 1, b - 1, c) + F(a - 1, b, c - 1) - F(a - 1, b - 1, c - 1);

        memo[(a, b, c)] = result;
        return result;
    }

    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("INPUT.TXT");
        string[] parts = input[0].Split();
        long a = long.Parse(parts[0]);
        long b = long.Parse(parts[1]);
        long c = long.Parse(parts[2]);

        long result = F(a, b, c);

        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }
}
