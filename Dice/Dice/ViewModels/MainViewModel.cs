using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Dice.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public Models.Dice dice;
        private string randomNumber;
        private bool switchMethod;
        private string nameDice;
        private bool switchToNameDice;


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
                //NameDice();
                OnPropertyChanged();
            }
        }
        public bool SwitchToNameDice
        {
            get => switchToNameDice;
            set
            {
                if (Equals(switchToNameDice, value)) return;
                switchToNameDice = value;
                NameDice();
                OnPropertyChanged();
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
        public void NameDice()
        {
            if (switchMethod == true)
            {
                nameDice = "test";
            }
        }    
    }
}
