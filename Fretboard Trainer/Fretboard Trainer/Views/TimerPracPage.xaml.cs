using Fretboard_Trainer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fretboard_Trainer.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("Str", "str")]
    public partial class TimerPracPage : ContentPage
{
        public List<string> StringsToPlay;

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

        public TimerPracViewModel vm;

        public TimerPracPage()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var stringstoplay = strs.Split(',').ToList();
            BindingContext = vm = new TimerPracViewModel(stringstoplay);
        }
    }
}