internal class Program
{
    private static void Main(string[] args)
    {
        var task = new List<Task<int>>();
        var source = new CancellationTokenSource();
        var token = source.Token;
        int completedIterations = 0;
        for(int n = 1; n <= 20;  n++)
        {
            task.Add(Task.Run(() =>
            {
                int iterations = 0;
                for (int ctr = 1; ctr <= 2_000_000; ctr++)
                {
                    token.ThrowIfCancellationRequested();
                    iterations++;
                }
                Interlocked.Increment(ref completedIterations);
                if (completedIterations >= 10)
                    source.Cancel();
                return iterations;
            }, token));
        }
    }
}