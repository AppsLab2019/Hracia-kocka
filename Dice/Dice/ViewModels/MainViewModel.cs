using Dice.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dice.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Models.Dice dice;
        private string randomNumber;
        private bool switchMethod;
        private Models.SixEdgeDiceDictionary sixDictionary;
        private string dictionaryProperty;


        public MainViewModel()
        {
            dice = new Models.Dice(6);
            Tapcommand = new Command(Tap);
            switchMethod = true;
        }
        public string RandomNumber
        {
            get => randomNumber;
            private set
            {
                if (Equals(randomNumber, value)) return;
                randomNumber = value;
                OnPropertyChanged();
            }
        }
        public bool SwitchProperty
        {
            get => switchMethod;
            set
            {
                if (Equals(switchMethod, value)) return;

                switchMethod = value;
                Switch();
                OnPropertyChanged();
            }
        }
        public string DictionaryProperty
        {
            get => dictionaryProperty;
            set
            {
                if (Equals(dictionaryProperty, value)) return;
                dictionaryProperty = value;
                if (Equals(randomNumber, value)) return;
                randomNumber = value;
                
                SixDictionary();

            }
        }
        public ICommand Tapcommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private void Tap()
        {
            RandomNumber = dice.Throw();
        }
        public void Switch()
        {
            if (switchMethod == true)
            {
                dice = new Models.Dice(6);
            }
            else
                dice = new Models.Dice(10);
        }
        public void SixDictionary()
        {
            if(switchMethod == true)
            {
                sixDictionary = new SixEdgeDiceDictionary();
            }
        }   
    }
}
