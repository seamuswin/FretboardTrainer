using Fretboard_Trainer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace Fretboard_Trainer.Views
{
    [QueryProperty("InstrumentName", "name")]
    public partial class PracSetupPage : ContentPage
    {
        public string InstrumentName
        {
            set => BindingContext = MockInstrumentStore.Instruments.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        }

        public List<string> PracticeStrings;
        public PracSetupPage()
        {
            InitializeComponent();
            PracticeStrings = new List<string>();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var str = string.Join(",", PracticeStrings);
            await Shell.Current.GoToAsync($"timerpracpage?str={str}");

        }
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var practiceString = (string)checkbox.BindingContext;
            if (checkbox.IsChecked)
                PracticeStrings.Add(practiceString);
            else if (PracticeStrings.Contains(practiceString))
                    PracticeStrings.Remove(practiceString);
        }
    }
}