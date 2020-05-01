using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous
{
    public class LongExampleTask
    {
        public int SleepTime_milliseconds { get; set; }

        public TaskResults Run()
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var currentThreadID = Thread.CurrentThread.ManagedThreadId;
            var currentProcessorID = Thread.GetCurrentProcessorId();
            Thread.Sleep(SleepTime_milliseconds);

            var elapsedTime_milliseconds = (int)stopwatch.ElapsedMilliseconds;

            return new TaskResults(currentThreadID, currentProcessorID, elapsedTime_milliseconds);
        }

        public async Task<TaskResults> RunAsync() => await Task.Run(() => Run());
    }
}
