using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace Fretboard_Trainer.ViewModels
{
    public class TimerPracViewModel : BaseViewModel
    {
        string noteToPlay;
        string stringToPlay;
        int seconds = 0;
        public Command PlayPauseCommand { get; set; }
        public Random rnd = new Random();
        public static Timer pracTimer;
        public bool Paused = true;
        public List<string> StringsToPlay { get; set; }

        public TimerPracViewModel(List<string> stringsToPlay)
        {
            Title = "TimerPage";
            StringsToPlay = new List<string>(stringsToPlay);
            PlayPauseCommand = new Command(() => ExecutePlayPauseCommand());
            SetTimer();
        }

        void ExecutePlayPauseCommand()
        {
            Paused = !Paused;
            pracTimer.Enabled = !Paused;
        }

        public void PickString()
        {
            var playstring = rnd.Next(StringsToPlay.Count);
            StringToPlay = StringsToPlay[playstring];
        }

        public void PickNote()
        {
            string[] notes = { "A\u266D", "A", "A\u266F", "B\u266D", "B", "C", "C\u266F", "D\u266D", "D", "D\u266F", "E\u266D", "E", "F", "F\u266F", "G\u266D", "G", "G\u266F" };
            int note = rnd.Next(notes.Length);
            NoteToPlay = notes[note];
        }

        private void SetTimer()
        {
            // Create a timer with a 3 second interval.
            pracTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            pracTimer.Elapsed += OnTimedEvent;
            pracTimer.AutoReset = true;
            pracTimer.Enabled = !Paused;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Seconds += 1;
            PickNewNote();
        }

        private void PickNewNote()
        {
            if (Seconds == 3)
            {
                Seconds = 0; 
                PickString();
                PickNote();
            }
        }

        public string NoteToPlay { 
            get 
            {
                return noteToPlay;
            } 
            set
            {
                if (noteToPlay != value)
                {
                    noteToPlay = value;
                    OnPropertyChanged("NoteToPlay");
                }
            }
        }
        public string StringToPlay {
            get
            {
                return stringToPlay;
            }
            set
            {
                if (stringToPlay != value)
                {
                    stringToPlay = value;
                    OnPropertyChanged("StringToPlay");
                }
            }
        }
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (seconds != value)
                {
                    seconds = value;
                    OnPropertyChanged("Seconds");
                }
            }
        }
    }
}
