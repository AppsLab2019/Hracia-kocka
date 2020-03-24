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
        private int randomNumber;
        private bool switchMethod;
        private string picture;
        private readonly Dictionary<int, string> pictures;

        public MainViewModel()
        {
            dice = new Models.Dice(6);
            Tapcommand = new Command(Tap);
            switchMethod = true;
            pictures = new Dictionary<int, string>
            {
                { 1, "Dice1.jpg" },
                { 2, "Dice2.jpg" },
                { 3, "Dice3.jpg" },
                { 4, "Dice4.jpg" },
                { 5, "Dice5.jpg" },
                { 6, "Dice6.jpg" },
            };
        }

        public int RandomNumber
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

        public string Picture
        {
            get => picture;
            set
            {
                if (Equals(picture, value)) return;
                picture = value;
                OnPropertyChanged();
            }
        }

        public ICommand Tapcommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        private void Tap()
        {
            RandomNumber = dice.Throw();
            Picture = pictures[RandomNumber];
        }
        
        public void Switch()
        {
            if (switchMethod)
            {
                dice = new Models.Dice(6);
            }
            else
                dice = new Models.Dice(10);
        }   
    }
}
