using System;
namespace Exercise_DieuPhoi
{
    public class RoundRobin
    {
        private int[] process { get; set; }
        private int[] arriavle_time { get; set; }
        private int[] burst_time { get; set; }
        private  int quantum { get; set; }

        public RoundRobin()
        {
            this.process = new int[4] { 1, 2, 3, 4 };
            this.arriavle_time = new int[4] { 0,1,2,3 };
            this.burst_time = new int[4] { 10, 4, 5, 3 };
            this.quantum = 3;
        }

        public void initData(int[] res_at, int[] res_bt)
        {
            for (int i = 0; i < this.burst_time.Length; i++)
            {
                res_at[i] = this.arriavle_time[i];
                res_bt[i] = this.burst_time[i];
            }
        }

        public void roundRobin(int[] at, int[] bt)
        {
            int res = 0;
            int resc = 0;
            String seq = "";

            int[] res_bt = new int[bt.Length];
            int[] res_at = new int[at.Length];
            initData(res_at, res_bt);

            int t = 0;
            int[] w = new int[this.process.Length];
            int[] compl = new int[this.process.Length];

            while (true)
            {
                Boolean flag = true;
                for (int i = 0; i < this.process.Length; i++)
                {
                    if (res_at[i] <= t)
                    {
                        if (res_at[i] <= this.quantum)
                        {
                            if (res_bt[i] > 0)
                            {
                                flag = false;
                                if (res_bt[i] > this.quantum)
                                {
                                    t += this.quantum;
                                    res_bt[i] -= this.quantum;
                                    res_at[i] += this.quantum;
                                    seq += "=>" + this.process[i];
                                }
                                else
                                {
                                    t += res_bt[i];
                                    compl[i] = t - bt[i];
                                    w[i] = t - bt[i] - at[i];
                                    res_bt[i] = 0;

                                    seq += "=>" + this.process[i];

                                }
                            }
                        }
                        else if (res_at[i] > this.quantum)
                        {
                            for (int j = 0; j < this.process.Length; j++)
                            {
                                if (res_at[i] > res_at[j])
                                {
                                    if (res_bt[j] > 0)
                                    {
                                        flag = false;
                                        if (res_bt[j] > this.quantum)
                                        {
                                            t += this.quantum;
                                            res_bt[j] -= this.quantum;
                                            res_at[j] += this.quantum;
                                            seq += "=>" + this.process[j];
                                        }
                                        else
                                        {
                                            t += res_bt[j];
                                            compl[j] = t - bt[j];
                                            w[j] = t - bt[j] - at[j];
                                            res_bt[j] = 0;
                                            seq += "=>" + this.process[j];
                                        }
                                    }
                                }
                            }

                            if (res_bt[i] > 0)
                            {
                                flag = false;
                                if (res_bt[i] > this.quantum)
                                {
                                    t += this.quantum;
                                    res_bt[i] -= this.quantum;
                                    res_at[i] += this.quantum;
                                    seq += "=>" + this.process[i];
                                }
                                else
                                {
                                    t += res_bt[i];
                                    compl[i] = t - bt[i];
                                    w[i] = t - bt[i] - at[i];
                                    res_bt[i] = 0;

                                    seq += "=>" + this.process[i];
                                }
                            }
                        }
                    }

                    else if (res_at[i] > t)
                    {
                        t++;
                        i--;
                    }
                }

                if (flag)
                {
                    break;
                }
            }


            Console.WriteLine("name | ctime | wtime");
            for (int i = 0; i < this.process.Length; i++)
            {
                Console.WriteLine(" " + this.process[i] + "\t" + compl[i] + "\t" + w[i]);
                res += w[i];
                resc += compl[i];
            }

            Console.WriteLine("AVG waiting time is " + (float)res / this.process.Length);
            Console.WriteLine("AVG compiling time is " + (float)resc / this.process.Length);
            Console.WriteLine("Sequences is like that  " + seq);
        }

        public void mainRun()
        {
            roundRobin(this.arriavle_time, this.burst_time);
        }
    }
}
