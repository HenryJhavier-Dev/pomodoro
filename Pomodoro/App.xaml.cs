using Pomodoro.Services;
using Pomodoro.Views;
using Xamarin.Forms;

namespace Pomodoro
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Resources["DefaultStringResources"] = new Resx.AppResources();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
