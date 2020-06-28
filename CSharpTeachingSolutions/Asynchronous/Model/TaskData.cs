namespace Asynchronous.Model
{
    using System.Collections.ObjectModel;
    using Tools;

    public class TaskData : ModelBase
    {
        private string progress;

        private long time;

        public string Progress
        {
            get => this.progress;
            set => this.SetField(ref this.progress, value);
        }

        public long Time
        {
            get => this.time;
            set => this.SetField(ref this.time, value);
        }

        public ObservableCollection<LongExampleTask> Tasks { get; } = new ObservableCollection<LongExampleTask>();

        public void Clear()
        {
            this.Tasks.Clear();
            this.Progress = string.Empty;
            this.Time = 0;
        }
    }
}