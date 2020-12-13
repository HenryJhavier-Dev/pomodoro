using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Pomodoro.Helpers;
using Pomodoro.Models;
using Pomodoro.Resx;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class HistoryPageViewModel : BaseViewModel
    {
        #region properties
        private ObservableCollection<ListPomodoro> pomodoros;
        public ObservableCollection<ListPomodoro> Pomodoros
        {
            get { return pomodoros; }
            set {
                pomodoros = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClearListCommand { get; set; }


        #endregion
        public HistoryPageViewModel()
        {
            LoadHistory();

            ClearListCommand = new Command(async => ClearListCommandExecute());

        }

        private async void ClearListCommandExecute()
        {
            if (Pomodoros != null)
            {

                Application.Current.Properties.Clear();
                Pomodoros.Clear();
                await Application.Current.SavePropertiesAsync();

            }
            else {

                await Application.Current.MainPage.DisplayAlert(
                    AppResources.title_error_alert,
                     AppResources.message_error_clear_lista,
                     AppResources.ok);
            }



        }

        private void LoadHistory()
        {
            if (Application.Current.Properties.ContainsKey(Literals.History)) {

                var json = Application.Current.Properties[Literals.History].ToString();

                var history = JsonConvert.DeserializeObject<List<ListPomodoro>>(json);

                Pomodoros = new ObservableCollection<ListPomodoro>(history);
                    
            }
        }
    }
}
