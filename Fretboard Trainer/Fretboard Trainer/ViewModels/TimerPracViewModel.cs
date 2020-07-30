using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Timers;

namespace Fretboard_Trainer.ViewModels
{
    public class TimerPracViewModel : BaseViewModel
    {
        string noteToPlay;
        string stringToPlay;
        public Random rnd = new Random();
        public static Timer pracTimer;
        public List<string> StringsToPlay { get; set; }

        public TimerPracViewModel(List<string> stringsToPlay)
        {
            Title = "TimerPage";
            StringsToPlay = new List<string>(stringsToPlay);
            PickNote();
            PickString();
            SetTimer();
        }

        public void PickString()
        {
            var playstring = rnd.Next(StringsToPlay.Count);
            StringToPlay = StringsToPlay[playstring];
            Console.WriteLine($"STRING {StringToPlay}");
        }

        public void PickNote()
        {
            string[] notes = { "A\u266D", "A", "A\u266F", "B\u266D", "B", "C", "C\u266F", "D\u266D", "D", "D\u266F", "E\u266D", "E", "F", "F\u266F", "G\u266D", "G", "G\u266F" };
            int note = rnd.Next(notes.Length);
            NoteToPlay = notes[note];
            Console.WriteLine($"NOTE {NoteToPlay}");
        }

        private void SetTimer()
        {
            // Create a timer with a 3 second interval.
            pracTimer = new Timer(3000);
            // Hook up the Elapsed event for the timer. 
            pracTimer.Elapsed += OnTimedEvent;
            pracTimer.AutoReset = true;
            pracTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Timer here!");
            PickString();
            PickNote();
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
    }
}
