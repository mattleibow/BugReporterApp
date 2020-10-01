using BugReporterApp.Services;
using BugReporterApp.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BugReporterApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Accelerometer.ShakeDetected += OnShaken;
            Accelerometer.Start(SensorSpeed.UI);
        }

        protected override void OnSleep()
        {
            Accelerometer.Stop();
            Accelerometer.ShakeDetected -= OnShaken;
        }

        protected override void OnResume()
        {
            Accelerometer.ShakeDetected += OnShaken;
            Accelerometer.Start(SensorSpeed.UI);
        }

        private async void OnShaken(object sender, EventArgs e)
        {
            var path = Path.Combine(FileSystem.CacheDirectory, "bug-report-screenshot.png");

            var screenshot = await Screenshot.CaptureAsync();

            using (var stream = await screenshot.OpenReadAsync())
            using (var dest = File.Create(path))
                await stream.CopyToAsync(dest);

            await Shell.Current.GoToAsync(nameof(BugReportPage));
        }
    }
}
