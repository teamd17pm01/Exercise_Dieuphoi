using System;

namespace Exercise_DieuPhoi
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            FIFO f = new FIFO();
            RoundRobin rr = new RoundRobin();
            //f.mainRun();
            rr.mainRun();
            Console.ReadLine();

        }
    }
}
