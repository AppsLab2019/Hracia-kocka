using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dice.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public Models.Dice dice;
        private string randomNumber;

        public MainViewModel()
        {
            dice = new Models.Dice(6);
            Tapcommand = new Command(Tap);
        }
        public string RandomNumber 
        { 
            get => randomNumber; 
            private set => randomNumber = value; 
        }

        public ICommand Tapcommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventHandler(propertyName));
        private void Tap()
        {
            RandomNumber = dice.Throw();
        }
        public void SwitchOn()
        {
            dice = new Models.Dice(10);
        }
        public void SwitchOff()
        {
            dice = new Models.Dice(6);
        }
    }
}
