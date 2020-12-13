using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pomodoro.Models;
using Xamarin.Forms;

namespace Pomodoro.Views
{

    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.About, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                //Navegar entre las paginas del menu !
                switch (id)
                {
                    case (int)MenuItemType.Pomodoro:
                        MenuPages.Add(id, new NavigationPage(new PomodoroPage()));
                        break;
                    case (int)MenuItemType.History:
                        MenuPages.Add(id, new NavigationPage(new HistoryPage()));
                        break;
                    case (int)MenuItemType.Configuration:
                        MenuPages.Add(id, new NavigationPage(new ConfigurationPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}