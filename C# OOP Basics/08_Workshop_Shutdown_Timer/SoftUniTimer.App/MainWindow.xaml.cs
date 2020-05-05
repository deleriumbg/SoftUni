using System.Diagnostics;
using System.Windows;


namespace Shutdown_Timer.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// System.Speech -> voice recognition app
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Shutdown(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess($"/s /t {seconds}");
            Process.Start(processStartInfo);
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo processStartInfo = GetProcess("/a");
            Process.Start(processStartInfo);
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess("/r /t 3600");
            Process.Start(processStartInfo);
        }
        
        private void Hibernate(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();
            ProcessStartInfo processStartInfo = GetProcess("/h /t 3600");
            Process.Start(processStartInfo);
        }

        private static ProcessStartInfo GetProcess(string command)
        {
            return new ProcessStartInfo("shutdown", command)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }

        private int GetSeconds()
        {
            var currentTime = timeList.SelectionBoxItem.ToString();

            int time = int.Parse(currentTime.TrimEnd('h', 'm'));

            if (currentTime.EndsWith("h"))
            {
                time *= 60 * 60;
            }
            else if (currentTime.EndsWith("m"))
            {
                time *= 60;
            }

            return time;
        }
    }
}
