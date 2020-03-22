using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppShel.Services;
using AppShel.Views;

namespace AppShel
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
