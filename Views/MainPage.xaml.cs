using SafetyCheckApp.ViewModels;
using Microsoft.Maui.Controls;

namespace SafetyCheckApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();  // Set the ViewModel as the BindingContext
        }
    }
}
