namespace Asynchronous
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Model;

    /// <summary>
    ///     Interaction logic for TaskViewerControl.xaml
    /// </summary>
    public partial class TaskViewerControl : UserControl
    {
        public static readonly DependencyProperty TaskDataProperty = DependencyProperty.Register(
            nameof(TaskViewerControl.TaskData),
            typeof(TaskData),
            typeof(TaskViewerControl),
            new PropertyMetadata(default(TaskData)));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(TaskViewerControl.Title),
            typeof(string),
            typeof(TaskViewerControl),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty StartCommandProperty = DependencyProperty.Register(
            nameof(TaskViewerControl.StartCommand),
            typeof(ICommand),
            typeof(TaskViewerControl),
            new PropertyMetadata(default(ICommand)));

        public TaskViewerControl()
        {
            this.InitializeComponent();
        }

        public TaskData TaskData
        {
            get => (TaskData)this.GetValue(TaskViewerControl.TaskDataProperty);
            set => this.SetValue(TaskViewerControl.TaskDataProperty, value);
        }

        public string Title
        {
            get => (string)this.GetValue(TaskViewerControl.TitleProperty);
            set => this.SetValue(TaskViewerControl.TitleProperty, value);
        }

        public ICommand StartCommand
        {
            get => (ICommand)this.GetValue(TaskViewerControl.StartCommandProperty);
            set => this.SetValue(TaskViewerControl.StartCommandProperty, value);
        }
    }
}