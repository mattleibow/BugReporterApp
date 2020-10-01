using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BugReporterApp.ViewModels
{
    public class BugReportViewModel : BaseViewModel
    {
        private string screenshot;

        public BugReportViewModel()
        {
            var path = Path.Combine(FileSystem.CacheDirectory, "bug-report-screenshot.png");

            Screenshot = path;
        }

        public string Screenshot
        {
            get => screenshot;
            set => SetProperty(ref screenshot, value, onChanged: OnScreenshotChanged);
        }

        public async void OnScreenshotChanged()
        {
        }
    }
}
