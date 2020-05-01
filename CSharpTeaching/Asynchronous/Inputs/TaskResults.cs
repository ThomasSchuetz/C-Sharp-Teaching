namespace Asynchronous
{
    public struct TaskResults
    {
        public int ThreadID { get; }
        public int ProcessorID { get; }
        public int TotalExecutionTime { get; }

        public TaskResults(int threadID, int processorID, int totalExecutionTime)
        {
            ThreadID = threadID;
            ProcessorID = processorID;
            TotalExecutionTime = totalExecutionTime;
        }

        public override string ToString() => 
            $"Time used: {TotalExecutionTime} ms, Thread ID: {ThreadID}, Processor ID: {ProcessorID}";
    }
}
