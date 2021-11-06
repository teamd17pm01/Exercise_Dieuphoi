/**
* bt[]: ds burst time
* at[]: ds Arrival time: Thời giàn đến 
* wt[]: ds Wating time: Thời gian đợi
* tat[]: ds Turn around time
*/

using System;


namespace Exercise_DieuPhoi
{
    public class FIFO
    {
        private int[] process { get; set; }
        private int n { get; set; }
        private int[] arriavle_time { get; set; }
        private int[] burst_time { get; set; }

        public FIFO()
        {
            this.process = new int[5] { 1, 2, 3, 4, 5 };
            this.n = process.Length;
            this.arriavle_time = new int[5] { 0, 1, 2, 3, 4 };
            this.burst_time = new int[5] { 10, 29, 3, 7, 12 };
        }

        public void findWaitingTime(int[] bt, int[] wt, int[] at)
        {
            int[] service_time = new int[this.n];
            service_time[0] = 0;
            wt[0] = 0;

            for (int i = 1; i < this.n; i++)
            {
                service_time[i] = service_time[i - 1] + bt[i - 1];
                wt[i] = service_time[i] - at[i];

                if (wt[i] < 0)
                {
                    wt[i] = 0;
                }
            }
        }

        public void findTurnAroundTime(int[] bt, int[] wt, int[] tat)
        {
            for (int i = 0; i < this.n; i++)
            {
                tat[i] = bt[i] + wt[i];
            }
        }

        public void findAVGTime(int[] bt, int[] at)
        {
            int[] wt = new int[this.n];
            int[] tat = new int[this.n];

            findWaitingTime(bt, wt, at);
            findTurnAroundTime(bt, wt, tat);

            Console.WriteLine("Processes| " + " Burst Time| " + " Arrival Time| " + " Waiting time| " + " Turn-Around Time| " + " Completion Time| ");
            int total_wt = 0, total_tat = 0;
            for (int i = 0; i < this.n; i++)
            {
                total_wt = total_wt + wt[i];
                total_tat = total_tat + tat[i];

                int compl_time = tat[i] + at[i];
                Console.WriteLine(i + 1 + "\t\t" + bt[i] + "\t\t" + at[i] + "\t\t" + wt[i] + "\t\t" + tat[i] + "\t\t" + compl_time);
            }

            Console.WriteLine("Average waiting time = " + (float)total_wt / (float)this.n);
            Console.WriteLine("Average turn around tie = " + (float)total_tat / (float)this.n);
        }

        public void mainRun()
        {
            findAVGTime(this.burst_time, this.arriavle_time);
            Console.ReadLine();
        }
    }
}
