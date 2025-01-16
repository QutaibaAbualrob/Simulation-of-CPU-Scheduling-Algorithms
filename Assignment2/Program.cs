using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;


class print
{
   public static void printJobs(Dictionary<int, long[]> jobs)
    {
        int count = 0;
        foreach (var job in jobs)
        {
            var value = job.Value;

            Console.WriteLine($"Process id {count}");
            Console.WriteLine($"This is process arrival time {value[0]}ms");
            Console.WriteLine($"This is process burst time {value[1]}ms");
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
   
    public static void fillJobsWithArrivalTime(Dictionary<int, long[]>jobs)
    {

        /*
            Jobs dictionary where the key is the process ID which is a number from 1 to 5 (5 processes):

            jobs[i][0-2]:

            jobs[i][0] is arrival time

         */


        var time = new Stopwatch();
        time.Start();
        for (int i = 0; i < 5; i++) 
        {
            jobs[i][0] = time.ElapsedMilliseconds;
            Thread.Sleep(339);
        }
        time.Stop();
    }

    public static void fillJobsWithBurstTime(Dictionary<int, long[]>jobs) 
    {   
        for(int i = 0;i < 5;i++)
        {
            jobs[i][1] = jobs[i][0] * 10;
        }
    }

    static void Main(string[] args)
    {
        


       var jobs = new Dictionary<int, long[]>();
        for (int i = 0; i< 5; i++) 
        {
            jobs[i]= new long[3];
        }


        fillJobsWithArrivalTime(jobs);
        fillJobsWithBurstTime(jobs);


        print.printJobs(jobs);
        
    }
}
