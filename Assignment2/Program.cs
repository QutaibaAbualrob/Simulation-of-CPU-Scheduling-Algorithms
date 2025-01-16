using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Timers;

class filler
{

    public static void fillJobsWithArrivalTime(process[] processArray, int processCount, Stopwatch time)
    {




        
        for (int i = 0; i < processCount; i++)
        {
           

            processArray[i].ArrivalTime = time.ElapsedMilliseconds;
            var rand = new Random();
            Thread.Sleep(rand.Next(1,536));
        }
        
    }

    public static void fillJobsWithBurstTime(process[] processArray, int processCount)
    {
        for (int i = 0; i < processCount; i++)
        {
            var rand = new Random();

            processArray[i].BurstTime = rand.Next(47,735) * 3;
        }
    }

    public static void fillJobsWithPriority(process[] processArray, int processCount)
    {
        Random rand = new Random();
        List<int> numbers = Enumerable.Range(1, processCount).ToList();
        numbers = numbers.OrderBy(x => rand.Next()).ToList();

        for (int i = 0; i < processCount; i++)
        {

            processArray[i].ProcessPriority = numbers[i];

        }
    }


}

class print
{
   public static void printJobs(process[] processArray)   {
        int count = 1;
        foreach (var process in processArray)
        {


           var completionTime = process.StartTime + process.BurstTime;
           var turnaroundTime = completionTime - process.ArrivalTime;
           var waitingTime = turnaroundTime - process.BurstTime;
           var responseTime = process.StartTime - process.ArrivalTime;

            Console.WriteLine($"Process id {count}");
            Console.WriteLine($"Arrival time {process.ArrivalTime}ms");
            Console.WriteLine($"Burst time {process.BurstTime}ms");
            Console.WriteLine($"Priority {process.ProcessPriority}");
            Console.WriteLine($"Start Time {process.StartTime}");
            Console.WriteLine($"CT (Completion Time) {completionTime}");
            Console.WriteLine($"TA (Turnaround Time) {turnaroundTime}");
            Console.WriteLine($"WT (Waiting Time) {waitingTime}");
            Console.WriteLine($"RT (Response Time) {responseTime}");


            Console.WriteLine($"______________________________");


            count++;
        }


    }
    

}

class process
{

    /*
            Jobs dictionary where the key is the process ID which is a number from 1 to 5 (5 processes):
            jobs[i][0-2]:

            jobs[i][0] is arrival time
            jobs[i][1] is CPU Burst time
            jobs[i][2] is Process Priority

         */
    long arrivalTime;
    long burstTime;
    long processPriority;
    long startTime;

    public long ArrivalTime
    {
        get
        {
            return arrivalTime;
        }

        set
        {
            this.arrivalTime = value;
        }
    }

    public long BurstTime
    {
        get
        {
            return burstTime;
        }
        
        set
        {
            this.burstTime = value;
        }
    }

    public long ProcessPriority
    {
        get
        {
            return processPriority;
        }

        set
        {
            this.processPriority = value;
        }
    }

    public long StartTime
    {
        get
        {
            return startTime;
        }

        set
        {
            this.startTime = value;
        }
    }


    public process(long arrivalTime, long burstTime, long processPriority, long startTime)
    {
        this.arrivalTime = arrivalTime;
        this.burstTime = burstTime;
        this.processPriority = processPriority;
        this.startTime = startTime;
    }

    public process()
    {
        arrivalTime = 0;
        burstTime = 0;
        processPriority = 0;
        startTime = 0;
    }
}


class FCFS
{
    

    public static void firstComeFirstServe(process[] pArray, Stopwatch time) 
    {
        foreach (var process in pArray)
        {
            process.StartTime = time.ElapsedMilliseconds;
            var rand = new Random();
            Thread.Sleep(Convert.ToInt32(process.BurstTime));
        }

    }

}
class SJF
{
    public static void shortestJobFirst(process[] pArray, Stopwatch time)
    {
        var sortedBasedOnBurstTime = pArray.OrderBy(x => x.BurstTime).ToList();

        foreach(var process in sortedBasedOnBurstTime)
        {
            process.StartTime = time.ElapsedMilliseconds;
            var rand = new Random();
            Thread.Sleep(Convert.ToInt32(process.BurstTime));
        }
    }
}


class Program
{
   
  


    static void Main(string[] args)
    {


        Console.WriteLine("Calculating Time, Please wait!!\n\n\n");
        int n = 5;
        process[] processArray = new process[n];
        for (int i = 0; i < n; i++)
        {
            processArray[i] = new process();
        }

        /*
            Jobs dictionary where the key is the process ID which is a number from 1 to 5 (5 processes):
            jobs[i][0-2]:

            jobs[i][0] is arrival time
            jobs[i][1] is CPU Burst time
            jobs[i][2] is Process Priority

         */

        var time = new Stopwatch();
        time.Start();

        filler.fillJobsWithArrivalTime(processArray, n, time);
        filler.fillJobsWithBurstTime(processArray, n);
        filler.fillJobsWithPriority(processArray, n);

        Thread.Sleep(569);
        //Alogrithims
       // FCFS.firstComeFirstServe(processArray, time);
        //SJF.shortestJobFirst(processArray, time);
        Console.WriteLine("FCFS Alogrithim  :\n");
        print.printJobs(processArray);




        time.Stop();
        
        
    }
}
