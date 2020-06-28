namespace Asynchronous.ViewModel
{
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Model;
    using Tools;

    public class ViewModel : ModelBase
    {
        private const int NumberOfTasks = 10;

        public ViewModel(Data data)
        {
            this.Data = data;
            this.StartSyncTasksCommand = new RelayCommand(this.StartSyncTasksExecuted);
            this.StartAsyncTasksCommand = new RelayCommand(this.StartAsyncTasksExecuted);
            this.StartAsyncParallelTasksCommand = new RelayCommand(this.StartAsyncParallelTasksExecuted);
        }

        public RelayCommand StartSyncTasksCommand { get; }

        public RelayCommand StartAsyncTasksCommand { get; }

        public RelayCommand StartAsyncParallelTasksCommand { get; }

        public Data Data { get; }

        private void StartSyncTasksExecuted(object obj)
        {
            var taskData = this.Data.SyncTasks;
            taskData.Clear();

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < ViewModel.NumberOfTasks; ++i)
            {
                var task = new LongExampleTask($"T-{i + 1}", 100 * (i + 1));
                taskData.Tasks.Add(task);

                task.Run();

                taskData.Progress = $"Finished {i + 1} of {ViewModel.NumberOfTasks} tasks";
                taskData.Time = stopwatch.ElapsedMilliseconds;
            }
        }

        private async void StartAsyncTasksExecuted(object obj)
        {
            var taskData = this.Data.AsyncTasks;
            taskData.Clear();

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < ViewModel.NumberOfTasks; ++i)
            {
                var task = new LongExampleTask($"T-{i + 1}", 100 * (i + 1));
                taskData.Tasks.Add(task);

                /*
                 * 
                 * Your code belongs here!
                 * 
                 */

                taskData.Progress = $"Finished {i + 1} of {ViewModel.NumberOfTasks} tasks";
                taskData.Time = stopwatch.ElapsedMilliseconds;
            }
        }

        private async void StartAsyncParallelTasksExecuted(object obj)
        {
            var taskData = this.Data.AsyncParallelTasks;
            taskData.Clear();

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < ViewModel.NumberOfTasks; ++i)
            {
                var task = new LongExampleTask($"T-{i + 1}", 100 * (i + 1));
                taskData.Tasks.Add(task);
            }

            /*
             * 
             * Your code belongs here!
             * 
             */

            taskData.Progress = $"Finished all of {ViewModel.NumberOfTasks} tasks";
            taskData.Time = stopwatch.ElapsedMilliseconds;
        }
    }
}