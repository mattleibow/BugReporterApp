using System;
using System.Collections.Generic;
using BugReporterApp.ViewModels;
using BugReporterApp.Views;
using Xamarin.Forms;

namespace BugReporterApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            
            Routing.RegisterRoute(nameof(BugReportPage), typeof(BugReportPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
