﻿internal class Program
{
    private static void Main(string[] args)
    {
        // Wait for all task  to complete.
        Task[] tasks = new Task[5];
        string taskData = "Hello";
        for(int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                Console.WriteLine($"Task={Task.CurrentId}, obj={taskData}, ThreadId={Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });
        }
        try
        {
            Task.WaitAll(tasks);
        }catch(AggregateException ex)
        {
            Console.WriteLine("One or more exceptions occurred: ");
            foreach(var e in ex.Flatten().InnerExceptions)
            {
                Console.WriteLine("    {0}", e.Message);
            }
            Console.WriteLine("Status of completed tasks:");
            foreach(var t in tasks)
            {
                Console.WriteLine("    Task #{0}: {1}", t.Id, t.Status);
            }
        }
    }
}