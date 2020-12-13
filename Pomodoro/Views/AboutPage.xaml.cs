using System;
using Pomodoro.Resx;
using Xamarin.Forms;

namespace Pomodoro.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Console.WriteLine($"------{AppResources.prueba}");
        }
    }
}