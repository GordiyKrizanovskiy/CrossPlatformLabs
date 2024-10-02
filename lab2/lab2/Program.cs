public class Program
{
    public static int MinimumOperations(int N)
    {
        int[] dp = new int[N + 1];
        dp[1] = 0;
        for (int i = 2; i <= N; i++)
        {
            dp[i] = dp[i - 1] + 1;
            if (i % 2 == 0)
            {
                dp[i] = Math.Min(dp[i], dp[i / 2] + 1);
            }
            if (i % 3 == 0)
            {
                dp[i] = Math.Min(dp[i], dp[i / 3] + 1);
            }
        }
        return dp[N];
    }

    public static void Main(string[] args)
    {
        int N = int.Parse(File.ReadAllText("INPUT.TXT"));
        int result = MinimumOperations(N);
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }
}
