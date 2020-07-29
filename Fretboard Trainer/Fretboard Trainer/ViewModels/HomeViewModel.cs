using Fretboard_Trainer.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fretboard_Trainer.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Instrument> Instruments { get; set; }
        public Command LoadInstrumentsCommand { get; set; }

        public HomeViewModel()
        {
            Title = "House";
            Instruments = new ObservableCollection<Instrument>();
            LoadInstrumentsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Instruments.Clear();
                var instruments = await InstrumentDataStore.GetItemsAsync(true);
                foreach (var instrument in instruments)
                {
                    Instruments.Add(instrument);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
