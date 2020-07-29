using Fretboard_Trainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fretboard_Trainer.Services
{
    public class MockInstrumentStore : IDataStore<Instrument>
    {
        public static List<Instrument> Instruments { get; private set; }

        public MockInstrumentStore()
        {
            Instruments = new List<Instrument>()
            {
                new Instrument {Id = Guid.NewGuid().ToString(), Name = "5 String Bass", PlayableStrings = new List<string>{"B","E","A","D","G"} },
                new Instrument {Id = Guid.NewGuid().ToString(), Name = "Standard Bass", PlayableStrings = new List<string>{"E","A","D","G"} }
            };
        }

        public async Task<bool> AddItemAsync(Instrument instrument)
        {
            Instruments.Add(instrument);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Instrument instrument)
        {
            var oldItem = Instruments.Where((Instrument arg) => arg.Id == instrument.Id).FirstOrDefault();
            Instruments.Remove(oldItem);
            Instruments.Add(instrument);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Instruments.Where((Instrument arg) => arg.Id == id).FirstOrDefault();
            Instruments.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Instrument> GetItemAsync(string id)
        {
            return await Task.FromResult(Instruments.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Instrument>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Instruments);
        }
    }
}
