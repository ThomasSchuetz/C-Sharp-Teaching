namespace Asynchronous.Model
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Tools;

    public class LongExampleTask : ModelBase
    {
        private readonly int sleepTimeMilliseconds;

        private long elapsedTimeMilliseconds;

        private int processorId;

        private int threadId;

        public LongExampleTask(string name, int sleepTimeMilliseconds)
        {
            this.Name = name;
            this.sleepTimeMilliseconds = sleepTimeMilliseconds;
        }

        public int ThreadId
        {
            get => this.threadId;
            set => this.SetField(ref this.threadId, value);
        }

        public int ProcessorId
        {
            get => this.processorId;
            set => this.SetField(ref this.processorId, value);
        }

        public long ElapsedTimeMilliseconds
        {
            get => this.elapsedTimeMilliseconds;
            set => this.SetField(ref this.elapsedTimeMilliseconds, value);
        }

        public string Name { get; }

        public void Run()
        {
            var stopwatch = Stopwatch.StartNew();

            this.ThreadId = Thread.CurrentThread.ManagedThreadId;
            this.ProcessorId = Thread.GetCurrentProcessorId();
            Thread.Sleep(this.sleepTimeMilliseconds);

            this.ElapsedTimeMilliseconds = stopwatch.ElapsedMilliseconds;
        }

        public async Task RunAsync() => await Task.Run(this.Run);
    }
}