using System.Collections.Concurrent;
using System.Diagnostics;

internal class Program
{
    // GetPrimeList retuns Prime numbers by using sequential ForEach
    private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();  

    //GetPrimeListWithParallel returns Prime numbers by using Parallel.Foreach
    private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
    {
        var primeNumbers = new ConcurrentBag<int>();
        Parallel.ForEach(numbers, number =>
        {
            if (IsPrime(number)) primeNumbers.Add(number);
        });
        return primeNumbers.ToList();
    }


    // IsPrime retuns true if number is Prime, else false
    private static bool IsPrime(int number)
    {
        bool result = true;
        if(number < 2)
        {
            result = false;
        }
        for(var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
        {
            if(number % divisor == 0)
            {
                return false;
            }
        }
        return result;
    }


    private static void Main(string[] args)
    {
        // 2 milion
        var limit = 2_000_000;
        var numbers = Enumerable.Range(0, limit).ToList();

        var watch = Stopwatch.StartNew();
        var primeNumbersFromForeach = GetPrimeList(numbers);
        watch.Start();

        var watchForParallel = Stopwatch.StartNew();
        var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
        watchForParallel.Stop();

        Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time taken: {watch.ElapsedMilliseconds} ms.");
        
        Console.WriteLine($"Parallel.ForEach loop | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time taken: {watchForParallel.ElapsedMilliseconds} ms.");
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
    }
}