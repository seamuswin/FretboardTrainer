using System;
using System.Collections.Generic;
using System.Text;

namespace Fretboard_Trainer.Models
{
    public class Instrument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> PlayableStrings { get; set; }

    }
}
