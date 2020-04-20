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
        private readonly Dictionary<int, string> picturesSixEdgeDice;
        private readonly Dictionary<int, string> picturesTenEdgeDice;
        //private bool switchPropertyForProcessThrow;
        //private Models.DetectShake shake;

        public MainViewModel()
        {
            Tapcommand = new Command(Tap);
            dice = new Models.Dice(6);
            switchMethod = true;
            picturesSixEdgeDice = new Dictionary<int, string>
            {
                { 1, "Dice1.jpg" },
                { 2, "Dice2.jpg" },
                { 3, "Dice3.jpg" },
                { 4, "Dice4.jpg" },
                { 5, "Dice5.jpg" },
                { 6, "Dice6.jpg" },
            };
            picturesTenEdgeDice = new Dictionary<int, string>
            {
                {1,"TenSidedDice1.png" },
                {2,"TenSidedDice2.png" },
                {3,"TenSidedDice3.png" },
                {4,"TenSidedDice4.png" },
                {5,"TenSidedDice5.png" },
                {6,"TenSidedDice6.png" },
                {7,"TenSidedDice7.png" },
                {8,"TenSidedDice8.png" },
                {9,"TenSidedDice9.png" },
                {10,"TenSidedDice10.png" },
            };
        }

        public int RandomNumber
        {
            get => randomNumber;
            set
            {
                if (Equals(randomNumber, value)) return;
                randomNumber = value;
                OnPropertyChanged();
            }
        }
        
        public bool SwitchPropertyForThrow
        {
            get => switchMethod;
            set
            {
                if (Equals(switchMethod, value)) return;

                switchMethod = value;
                SwitchForThrow();
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
        //public bool SwitchPropertyForProcessThrow
        //{
        //    get => switchPropertyForProcessThrow;
        //    set
        //    {
        //        if (Equals(switchPropertyForProcessThrow, value)) return;
        //        switchPropertyForProcessThrow = value;
        //        SwitchForProcessThrow();
        //        OnPropertyChanged();
        //    }

        //}

        public ICommand Tapcommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        public void Tap()
        {
            RandomNumber = dice.Throw();
            if (switchMethod == true)
                Picture = picturesSixEdgeDice[RandomNumber];
            else
                Picture = picturesTenEdgeDice[RandomNumber];
        }

        public void SwitchForThrow()
        {
            if (switchMethod)
                dice = new Models.Dice(6);
            else
                dice = new Models.Dice(10);
        }
        //public void SwitchForProcessThrow()
        //{
        //    if (switchPropertyForProcessThrow == true)
        //        Tapcommand = new Command(Tap);
        //    else
        //        shake = new Models.DetectShake();
        //}
    }
}
