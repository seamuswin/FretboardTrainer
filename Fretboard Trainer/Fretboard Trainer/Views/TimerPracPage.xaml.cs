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
public partial class TimerPracPage : ContentPage
{
        public List<string> StringsToPlay;
    public TimerPracPage(List<string> stringsToPlay)
    {
        InitializeComponent();
            this.StringsToPlay = stringsToPlay;
            notetoplay.Text = PickNote();
            var stp = PickString();
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
            Random rnd = new Random();
            string[] playstring = StringsToPlay.ToArray();
            int usestring = rnd.Next(playstring.Length);
            Console.WriteLine("{0}", playstring[usestring]);
            return playstring[usestring];
        }

        public string PickNote() 
        {
            Random rnd = new Random();
            string[] notes = { "A\u266D", "A", "A\u266F", "B\u266D", "B", "C", "C\u266F", "D\u266D", "D", "D\u266F", "E\u266D", "E", "F", "F\u266F", "G\u266D", "G", "G\u266F" };
            int note = rnd.Next(notes.Length);
            Console.WriteLine("{0}", notes[note]);
            return notes[note];
        }
}
}