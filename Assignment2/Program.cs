using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

class filler
{

    public static void fillJobsWithArrivalTime(Dictionary<int, long[]> jobs, int processCount)
    {




        var time = new Stopwatch();
        time.Start();
        for (int i = 0; i < processCount; i++)
        {
            jobs[i][0] = time.ElapsedMilliseconds;
            Thread.Sleep(339);
        }
        time.Stop();
    }

    public static void fillJobsWithBurstTime(Dictionary<int, long[]> jobs, int processCount)
    {
        for (int i = 0; i < processCount; i++)
        {
            jobs[i][1] = jobs[i][0] * 10;
        }
    }

    public static void fillJobsWithPriority(Dictionary<int, long[]> jobs, int processCount)
    {
        Random rand = new Random();
        List<int> numbers = Enumerable.Range(1, processCount).ToList();
        numbers = numbers.OrderBy(x => rand.Next()).ToList();

        for (int i = 0; i < processCount; i++)
        {

            jobs[i][2] = numbers[i];

        }
    }


}

class print
{
   public static void printJobs(Dictionary<int, long[]> jobs)
    {
        int count = 1;
        foreach (var job in jobs)
        {
            var value = job.Value;

            Console.WriteLine($"Process id {count}");
            Console.WriteLine($"This is process arrival time {value[0]}ms");
            Console.WriteLine($"This is process burst time {value[1]}ms");
            Console.WriteLine($"This is process priority {value[2]}");
            Console.WriteLine($"______________________________");


            count++;
        }


    }
    

}




class FCFS
{
    

    public static void firstComeFirstServe(Dictionary<int, long[]>jobs) 
    {


    }

}

class Program
{
   
  


    static void Main(string[] args)
    {
        

        var jobs = new Dictionary<int, long[]>();
        int n = 5;
        for (int i = 0; i< n; i++) 
        {
            jobs[i]= new long[n];
        }


        /*
            Jobs dictionary where the key is the process ID which is a number from 1 to 5 (5 processes):
            jobs[i][0-2]:

            jobs[i][0] is arrival time
            jobs[i][1] is CPU Burst time
            jobs[i][2] is Process Priority

         */



        filler.fillJobsWithArrivalTime(jobs, n);
        filler.fillJobsWithBurstTime(jobs, n);
        filler.fillJobsWithPriority(jobs, n);




        print.printJobs(jobs);
        
    }
}
