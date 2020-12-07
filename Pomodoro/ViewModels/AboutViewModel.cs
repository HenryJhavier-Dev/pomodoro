using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Pomodoro.Helpers;


namespace Pomodoro.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}