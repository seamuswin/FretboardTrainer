using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fretboard_Trainer.Services;
using Fretboard_Trainer.Views;

namespace Fretboard_Trainer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockInstrumentStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
