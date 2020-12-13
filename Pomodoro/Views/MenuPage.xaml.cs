using Pomodoro.Helpers;
using Pomodoro.Models;
using Pomodoro.Resx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro.Views
{
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About,
                    Title= AppResources.about },
                new HomeMenuItem {Id = MenuItemType.Configuration,
                    Title= AppResources.configuration },
                new HomeMenuItem {Id = MenuItemType.Pomodoro,
                    Title= AppResources.app_name },
                new HomeMenuItem {Id = MenuItemType.History,
                    Title= AppResources.historical}

            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                //Condifión para verificar si se configuro el pomodoro
                //antes de iniciar el pomodoro
                await VerificateCondition((HomeMenuItem)e.SelectedItem);

            };
        }

        //Verifica si la configuracion ya esta establecida sino te manda a
        //la pantalla de configuracion
        private async Task VerificateCondition(HomeMenuItem menuItem)
        {
            //Si seleccionas la pestaña pomodoro verifica que ya este configurado
            if (menuItem.Title.Equals(AppResources.app_name))
            {
                if (!Application.Current.Properties.ContainsKey(Literals.PomodoroDuration) &&
                   !Application.Current.Properties.ContainsKey(Literals.BreakDuration))
                {
                    await DisplayAlert(AppResources.title_error_alert,
                        AppResources.configuration_break_duration,
                        AppResources.ok);

                }

            }
            else {

                var id = (int)menuItem.Id;
                await RootPage.NavigateFromMenu(id);
            }
        }
    }
}