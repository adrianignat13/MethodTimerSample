using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MethodTimer;

namespace MethodTimerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AsyncDelay().Wait();
                
            }
            catch
            {

            }

            try
            {
                AsyncDelayWithTimer().Wait();
            }
            catch
            {

            }
        }

        [Time]
        public static async Task AsyncDelay()
        {
            await Task.Delay(1000);

            throw new Exception();
        }

        public static async Task AsyncDelayWithTimer()
        {
            var sw = Stopwatch.StartNew();

            try
            {
                await Task.Delay(1000);
                throw new Exception();
            }
            finally
            {
                sw.Stop();
                Trace.WriteLine($"Program.AsyncDelayWithTimer {sw.Elapsed.TotalMilliseconds}ms");
            }

        }

    }
}
