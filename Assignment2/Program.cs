using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Timers;


static class filler
{
    
    public static void fillJobsWithArrivalTime(process[] processArray, int processCount, Stopwatch time)
    {



        var rand = new Random();

        for (int i = 0; i < processCount; i++)
        {

            processArray[i].Id = (i+1)+100;
            processArray[i].ArrivalTime = time.ElapsedMilliseconds;
           
            Thread.Sleep(rand.Next(1, 536));
        }

    }

    public static void fillJobsWithBurstTime(process[] processArray, int processCount)
    {
        var rand = new Random();
        for (int i = 0; i < processCount; i++)
        {
           

            processArray[i].BurstTime = rand.Next(1100, 11500);
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

static class print
{
    public static void printJobs(process[] processArray)
    {
        int count = 1;
        foreach (var process in processArray)
        {


            var completionTime = process.StartTime + process.BurstTime;
            var turnaroundTime = completionTime - process.ArrivalTime;
            var waitingTime = turnaroundTime - process.BurstTime;
            var responseTime = process.StartTime - process.ArrivalTime;

            Console.WriteLine($"Process count : {count}");
            Console.WriteLine($"Process id : {process.Id}");
            Console.WriteLine($"Arrival time {process.ArrivalTime}ms");
            Console.WriteLine($"Burst time {process.BurstTime}ms");
            Console.WriteLine($"Priority {process.ProcessPriority}");
            Console.WriteLine($"Start Time {process.StartTime}ms");
            Console.WriteLine($"CT (Completion Time) {completionTime}ms");
            Console.WriteLine($"TA (Turnaround Time) {turnaroundTime}ms");
            Console.WriteLine($"WT (Waiting Time) {waitingTime}ms");
            Console.WriteLine($"RT (Response Time) {responseTime}ms");


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
    int id;
    long arrivalTime;
    long burstTime;
    long processPriority;
    long startTime;

    long completionTime;
    long turnaroundTime;
    long waitingTime;
    long responseTime;


    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            this.id = value;
        }
    }


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


    public long CompletionTime
    {
        get
        {
            return completionTime;
        }

        set
        {
            this.completionTime = value;
        }
    }

    public long TurnaroundTime
    {
        get
        {
            return turnaroundTime;
        }

        set
        {
            this.turnaroundTime = value;
        }
    }

    public long WaitingTime
    {
        get
        {
            return waitingTime;
        }

        set
        {
            this.waitingTime = value;
        }
    }

    public long ResponseTime
    {
        get
        {
            return responseTime;
        }

        set
        {
            this.responseTime = value;
        }
    }


    public process(int id, long arrivalTime, long burstTime, long processPriority, long startTime)
    {
        this.id = id;
        this.arrivalTime = arrivalTime;
        this.burstTime = burstTime;
        this.processPriority = processPriority;
        this.startTime = startTime;
    }

    public process()
    {
        id = -99999;
        arrivalTime = 0;
        burstTime = 0;
        processPriority = 0;
        startTime = 0;
        completionTime = 0;
        turnaroundTime = 0;
        waitingTime = 0;
        responseTime = 0;

    }


    //Copy constructor
    public process (process other)
    {

        this.id = other.Id;
        this.ArrivalTime = other.ArrivalTime;
        this.burstTime = other.BurstTime;
        this.processPriority = other.ProcessPriority;
        this.startTime = other.StartTime;
        this.completionTime = other.CompletionTime;
        this.turnaroundTime = other.TurnaroundTime;
        this.waitingTime = other.WaitingTime;
        this.responseTime = other.ResponseTime;

      
    }


    public long calculateCompletionTime()
    {
        return this.completionTime = this.startTime + this.burstTime;
    }

    public long calculateTurnaroundTime()
    {
        return this.turnaroundTime = this.completionTime - this.arrivalTime;
    }

    public long calculateWaitingTime()
    {
        return this.waitingTime = this.turnaroundTime - this.burstTime;
    }

    public long calculateResponseTime()
    {
        return this.responseTime = this.startTime - this.arrivalTime;
    }

}


static class FCFS
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
static class SJF
{
    public static process[] shortestJobFirst(process[] pArray, Stopwatch time)
    {
        pArray = pArray.OrderBy(x => x.BurstTime).ToArray();

        foreach (var process in pArray)
        {
            process.StartTime = time.ElapsedMilliseconds;
       
            Thread.Sleep(Convert.ToInt32(process.BurstTime));
        }
        return pArray;
    }
}

static class SRTF
{
    public static process[] shortestRemainingTimeFirst(process[] pArray, Stopwatch time)
    {
       
        
        var list = new List<process>();
      
        for (int i = 0; i < pArray.Length; i++)
        {
            //1
            if(pArray[i].BurstTime == 0)
            {
                continue;
            }


            pArray[i].StartTime = time.ElapsedMilliseconds;
            pArray[i].calculateCompletionTime();
            

            for(int j = i + 1; j < pArray.Length; j++)
            {
                if (pArray[i].BurstTime > pArray[j].BurstTime)
                {
                    pArray[j].StartTime = time.ElapsedMilliseconds;
                    pArray[j].calculateCompletionTime();

                    if (pArray[j].BurstTime > 0)
                    {
                        Thread.Sleep(Convert.ToInt32(pArray[j].BurstTime));
                        var temp1 = new process(pArray[j]);
                        list.Add(temp1);
                        pArray[j].BurstTime = 0;
                      
                    }
                        
                }
                   


            }

            var temp2 = new process(pArray[i]);
            list.Add(temp2);

            pArray[i].BurstTime -= 1000;
            if (pArray[i].BurstTime > 0)
            {
                Thread.Sleep(Convert.ToInt32(pArray[i].BurstTime));
                pArray[i].BurstTime = 0;
            }
                
            

        }
        
        

        return list.ToArray();
    }
}

static class PR
{


}

static class Program
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

        int cs = 3;
        switch(cs)
        {
            case 1:
                Console.WriteLine("First Come First Serve Alogrithim (FCFS):\n");
                FCFS.firstComeFirstServe(processArray, time);
                print.printJobs(processArray);
                break;

            case 2:
                Console.WriteLine("Shortest Job First (SJF):\n");
                processArray = SJF.shortestJobFirst(processArray, time);
                print.printJobs(processArray);
                break;

            case 3:
                Console.WriteLine("Shortest Remaining Time First (SRTF):\n");
                processArray = SRTF.shortestRemainingTimeFirst(processArray, time);
                print.printJobs(processArray);
                break;

            case 4:
                Console.WriteLine("Preemptive and Non-Preemptive Priority Scheduling:\n");
                break;

            case 5:
                Console.WriteLine("Round Robin Scheduling (RR):\n");
                break;

            default:
                Console.WriteLine("Invalid Choice\n");
                break;
        }
            
        


       




        time.Stop();


    }
}
