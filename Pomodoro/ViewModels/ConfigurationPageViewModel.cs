using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pomodoro.Helpers;
using Pomodoro.Resx;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class ConfigurationPageViewModel : BaseViewModel
    {
        #region properties

        private ObservableCollection<int> pomodoroDurations;
        public ObservableCollection<int> PomodoroDurations {
            get { return pomodoroDurations; }
            set {
                pomodoroDurations = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> breakDurations;
        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set {
                breakDurations = value;
                OnPropertyChanged();
            }
        }

        private int selectedPomodoroDuration;
        public int SelectedPomodoroDuration
        {
            get { return selectedPomodoroDuration; }
            set{
                selectedPomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private int selectedBreakDuration;
        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set {
                selectedBreakDuration = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        #endregion

        public ConfigurationPageViewModel()
        {
            SaveCommand = new Command(async => SaveCommandExecute());
            LoadPomodoroDurations();
            LoadBreakDurations();
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(Literals.PomodoroDuration)){
                SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            }

            if (Application.Current.Properties.ContainsKey(Literals.BreakDuration)){
                selectedBreakDuration = (int)Application.Current.Properties[Literals.BreakDuration];
            }
        }

        private void LoadBreakDurations()
        {
            BreakDurations = new ObservableCollection<int>()
            {
                1,2,3
            };
        }

        private void LoadPomodoroDurations()
        {
            PomodoroDurations = new ObservableCollection<int>()
            {
                1,2,3
            };
        }

  
        private async void SaveCommandExecute()
        {
            Application.Current.Properties[Literals.PomodoroDuration] = SelectedPomodoroDuration;
            Application.Current.Properties[Literals.BreakDuration] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();

            await Application.Current.MainPage.DisplayAlert(
                    AppResources.title_succes,
                     AppResources.title_go_tab_pomodoro,
                     AppResources.ok);
        }
    }
}
