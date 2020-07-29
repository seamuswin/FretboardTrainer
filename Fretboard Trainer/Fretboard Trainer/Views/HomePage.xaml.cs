using Fretboard_Trainer.Models;
using Fretboard_Trainer.ViewModels;
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
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Instruments.Count == 0)
                viewModel.IsBusy = true;
            InstrumentsColView.SelectedItem = null;

        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InstrumentsColView.SelectedItem != null)
            {
                string instrument = (e.CurrentSelection.FirstOrDefault() as Instrument).Name;
                await Shell.Current.GoToAsync($"pracsetuppage?name={instrument}");
            }
                
            

        }
    }
}