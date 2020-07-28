using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fretboard_Trainer.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // make a list of all the checkboxes and if IsChecked=True
            List<string> strings = new List<string>();
            if (gstring.IsChecked)
                strings.Add("1st");
            if (dstring.IsChecked)
                strings.Add("2nd");
            if (astring.IsChecked)
                strings.Add("3rd");
            if (estring.IsChecked)
                strings.Add("4th");
            if (bstring.IsChecked)
                strings.Add("5th");
            

            var timerPracPage = new TimerPracPage(strings);
            await Navigation.PushAsync(timerPracPage);

        }
    }
}