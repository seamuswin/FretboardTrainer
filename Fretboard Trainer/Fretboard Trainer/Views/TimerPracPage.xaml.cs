using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fretboard_Trainer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("Str", "str")]
    public partial class TimerPracPage : ContentPage
{
        public List<string> StringsToPlay;
        public Random rnd = new Random();

        public string strs = "";
        public string Str
        {
            get => strs;
            set
            {
                strs = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
            }
        }

        public TimerPracPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StringsToPlay = Str.Split(',').ToList();
            StringsToPlay.ForEach(Console.WriteLine);

            notetoplay.Text = PickNote();
            var stp = PickString();
            Console.Write(stp);
            stringtoplay.Text = $"{stp} string";

            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    notetoplay.Text = PickNote();
                    stp = PickString();
                    stringtoplay.Text = $"{stp} string";
                });
                return true;
            });
        }
        public string PickString()
        {
            var playstring = rnd.Next(StringsToPlay.Count);
            return StringsToPlay[playstring];
        }

        public string PickNote() 
        {
            string[] notes = { "A\u266D", "A", "A\u266F", "B\u266D", "B", "C", "C\u266F", "D\u266D", "D", "D\u266F", "E\u266D", "E", "F", "F\u266F", "G\u266D", "G", "G\u266F" };
            int note = rnd.Next(notes.Length);
            return notes[note];
        }
}
}