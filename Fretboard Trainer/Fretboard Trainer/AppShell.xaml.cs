using Fretboard_Trainer.Views;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fretboard_Trainer
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("pracsetuppage", typeof(PracSetupPage));
            Routing.RegisterRoute("timerpracpage", typeof(TimerPracPage));
            Routing.RegisterRoute("addinstrumentpage", typeof(AddInstrumentPage));
        }
    }
}
