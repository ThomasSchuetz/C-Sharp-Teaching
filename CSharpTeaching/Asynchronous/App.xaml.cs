namespace Asynchronous
{
    using System.Windows;
    using Model;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Data data = new Data();

        public static ViewModel.ViewModel ViewModel { get; private set; }

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            App.ViewModel = new ViewModel.ViewModel(this.data);

            base.OnStartup(e);
        }
    }
}