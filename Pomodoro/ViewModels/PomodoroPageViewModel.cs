using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Newtonsoft.Json;
using Pomodoro.Helpers;
using Pomodoro.Models;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class PomodoroPageViewModel:BaseViewModel
    {
        // IsRunning y IsInBreak son properties
        // guardadas en el BaseViewModel por ser
        // pontencialmente reutilizables

        #region properties

        private Timer timers;
        private int pomodoroDuration;
        private int breakDuration;

        // Verifica cuanto avanzo en el tiempo
        private TimeSpan ellapsed;

        public TimeSpan Ellapsed
        {
            get { return ellapsed; }
            set {
                ellapsed = value;
                OnPropertyChanged();
            }
        }

        // Binding para enlazar el circular Progress
        private int duration;
        public int Duration
        {
            get { return duration; }
            set {
                duration = value;
                OnPropertyChanged();
            }
        }


        public ICommand StartOrPauseCommand { get; set; }

        #endregion
        public PomodoroPageViewModel()
        {
            InitializationTimer();
            LoadConfiguredValues();
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
        }

        private void LoadConfiguredValues()
        {

            Duration         = pomodoroDuration * 60;
            pomodoroDuration = (int)Application.Current.Properties[Literals.PomodoroDuration];
            breakDuration    = (int)Application.Current.Properties[Literals.BreakDuration];
        }

        private void StartOrPauseCommandExecute()
        {
                
            if (IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }

        }

        private void InitializationTimer()
        {
            timers = new Timer();
            timers.Interval = 100;
            timers.Elapsed += Timers_Elapsed;

        }

        private async void Timers_Elapsed(object sender, ElapsedEventArgs e)
        {
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));

            // Si esta corriendo y estamos en break
            if (IsRunning && Ellapsed.TotalSeconds == pomodoroDuration * 60) {
                IsRunning = false;
                IsInBreak = true;
                Ellapsed  = TimeSpan.Zero;

                await SavePomodoroAsync();
            }

            if (IsInBreak && Ellapsed.TotalSeconds == breakDuration * 60) {
                IsRunning = true;
                IsInBreak = false;
                Ellapsed = TimeSpan.Zero;
            }

        }

        private async Task SavePomodoroAsync()
        {
            List<ListPomodoro> history;

            // Si existe añade sino crea la lista de promodoro

            if (Application.Current.Properties.ContainsKey(Literals.History))
            {

                var json_history = Application.Current.Properties[Literals.History].ToString();

                history = JsonConvert.DeserializeObject<List<ListPomodoro>>(json_history);

            }   
            else {

                history = new List<ListPomodoro>();

            }

            var add_history = new ListPomodoro {
                date = DateTime.Now,
                item_count = history.Count
            };

            history.Add(add_history);

            var serializeObject = JsonConvert.SerializeObject(history);

            Application.Current.Properties[Literals.History] = serializeObject;

            await Application.Current.SavePropertiesAsync();

        }

        private void StartTimer() {
            timers.Start();
            IsRunning = true;
        }
        private void StopTimer()
        {
            timers.Stop();
            IsRunning = false;
        }


    }
}
