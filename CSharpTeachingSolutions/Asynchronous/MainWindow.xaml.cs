using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Asynchronous
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<int, LongExampleTask> tasks;
        public MainWindow()
        {
            InitializeComponent();

            tasks = new Dictionary<int, LongExampleTask>();
            tasks.Add(1, new LongExampleTask { SleepTime_milliseconds = 100 });
            tasks.Add(2, new LongExampleTask { SleepTime_milliseconds = 100 });
            tasks.Add(3, new LongExampleTask { SleepTime_milliseconds = 400 });
            tasks.Add(4, new LongExampleTask { SleepTime_milliseconds = 400 });
            tasks.Add(5, new LongExampleTask { SleepTime_milliseconds = 1000 });
            tasks.Add(6, new LongExampleTask { SleepTime_milliseconds = 1000 });
        }

        private void btn_startSync_Click(object sender, RoutedEventArgs e)
        {
            list_resultSync.Items.Clear();
            lbl_syncProgress.Content = "";
            lbl_syncTime.Content = "";

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var task in tasks)
            {
                var result = task.Value.Run();
                list_resultSync.Items.Add($"Task: {task.Key}, {result}");
                lbl_syncProgress.Content = $"Finished {task.Key} of {tasks.Count} tasks";
            }
            lbl_syncTime.Content = $"Total time: {stopwatch.ElapsedMilliseconds} ms";
        }

        private async void btn_startAsync_Click(object sender, RoutedEventArgs e)
        {
            list_resultAsync.Items.Clear();
            lbl_asyncProgress.Content = "";
            lbl_asyncTime.Content = "";

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var task in tasks)
            {
                var result = await task.Value.RunAsync();
                list_resultAsync.Items.Add($"Task: {task.Key}, {result}");
                lbl_asyncProgress.Content = $"Finished {task.Key} of {tasks.Count} tasks";
            }
            lbl_asyncTime.Content = $"Total time: {stopwatch.ElapsedMilliseconds} ms";
        }

        private async void btn_startAsyncParallel_Click(object sender, RoutedEventArgs e)
        {
            list_resultAsyncParallel.Items.Clear();
            lbl_asyncParallelProgress.Content = "";
            lbl_asyncParallelTime.Content = "";

            ParallelTaskCounter = 0;

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var tasksToExecute = from task in tasks
                                 select ParallelTask(task.Value, task.Key);
            await Task.WhenAll(tasksToExecute);

            lbl_asyncParallelTime.Content = $"Total time: {stopwatch.ElapsedMilliseconds} ms";
        }

        private int parallelTaskCounter;
        private int ParallelTaskCounter
        {
            get { return parallelTaskCounter; }
            set
            {
                parallelTaskCounter = value;
                lbl_asyncParallelProgress.Content = $"Finished {value} of {tasks.Count} tasks";
            }
        }
        private async Task ParallelTask(LongExampleTask task, int taskNumber)
        {
            var result = await task.RunAsync();
            list_resultAsyncParallel.Items.Add($"Task: {taskNumber}, {result}");
            ParallelTaskCounter++;
        }
    }
}
