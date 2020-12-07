using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Pomodoro.Helpers;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class HistoryPageViewModel : BaseViewModel
    {
        #region properties
        private ObservableCollection<DateTime> pomodoros;
        public ObservableCollection<DateTime> Pomodoros
        {
            get { return pomodoros; }
            set {
                pomodoros = value;
                OnPropertyChanged();
            }
        }

        #endregion
        public HistoryPageViewModel()
        {
            LoadHistory();
        }

        private void LoadHistory()
        {
            if (Application.Current.Properties.ContainsKey(Literals.History)) {

                var json = Application.Current.Properties[Literals.History].ToString();

                var history = JsonConvert.DeserializeObject<List<DateTime>>(json);

                Pomodoros = new ObservableCollection<DateTime>(history);
                    
            }
        }
    }
}
