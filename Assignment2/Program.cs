using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;

class filler
{

    public static void fillJobsWithArrivalTime(process[] processArray, int processCount)
    {




        var time = new Stopwatch();
        time.Start();
        for (int i = 0; i < processCount; i++)
        {
           

            processArray[i].ArrivalTime = time.ElapsedMilliseconds;
            var rand = new Random();
            Thread.Sleep(rand.Next(1,500));
        }
        time.Stop();
    }

    public static void fillJobsWithBurstTime(process[] processArray, int processCount)
    {
        for (int i = 0; i < processCount; i++)
        {
            processArray[i].BurstTime = processArray[i].ArrivalTime * 10;
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
            

            Console.WriteLine($"Process id {count}");
            Console.WriteLine($"This is process Arrival time {process.ArrivalTime}ms");
            Console.WriteLine($"This is process Burst time {process.BurstTime}ms");
            Console.WriteLine($"This is process Priority {process.ProcessPriority}");
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




    public process(int arrivalTime, int burstTime, int processPriority)
    {
        this.arrivalTime = arrivalTime;
        this.burstTime = burstTime;
        this.processPriority = processPriority;
    }

    public process()
    {
        arrivalTime = 0;
        burstTime = 0;
        processPriority = 0;
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


        filler.fillJobsWithArrivalTime(processArray, n);
        filler.fillJobsWithBurstTime(processArray, n);
        filler.fillJobsWithPriority(processArray, n);




        print.printJobs(processArray);
        
    }
}
