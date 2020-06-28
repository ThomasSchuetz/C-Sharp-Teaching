namespace Asynchronous.Model
{
    using Tools;

    public class Data : ModelBase
    {
        public TaskData SyncTasks { get; } = new TaskData();

        public TaskData AsyncTasks { get; } = new TaskData();

        public TaskData AsyncParallelTasks { get; } = new TaskData();
    }
}