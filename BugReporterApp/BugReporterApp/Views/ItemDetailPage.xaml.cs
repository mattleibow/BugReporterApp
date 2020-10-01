using System.ComponentModel;
using Xamarin.Forms;
using BugReporterApp.ViewModels;

namespace BugReporterApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}