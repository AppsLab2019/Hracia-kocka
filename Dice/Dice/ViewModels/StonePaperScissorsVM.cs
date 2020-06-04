using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dice.ViewModels
{
    class StonePaperScissorsVM : INotifyPropertyChanged
    {
        private readonly Models.Dice dice;
        private readonly Dictionary<int, string> picturesForStonePaperScissors;
        private string stonePaperScissors;

        public StonePaperScissorsVM()
        {
            Tapcommand = new Command(Tap);
            dice = new Models.Dice(3);
            picturesForStonePaperScissors = new Dictionary<int, string>
            {
                { 1, "Paper.jpg" },
                { 2, "Scissors.jpg" },
                { 3, "Stone.jpg" },
            };

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        public int RandomNumber { get; set; }

        public string Picture { get; set; }

        public string PropertyStonePaperScissors
        {
            get => stonePaperScissors;
            set
            {
                if (Equals(stonePaperScissors, value)) return;
                stonePaperScissors = value;
                OnPropertyChanged();
            }
        }

        public ICommand Tapcommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Tap()
        {
            RandomNumber = dice.Throw();
            StonePaperScissors();
        }

        public void Accelerometer_ShakeDetected(object sender, System.EventArgs e)
        {
            Tap();
        }

        private void StonePaperScissors()
        {
            Picture = picturesForStonePaperScissors[RandomNumber];
            PropertyStonePaperScissors = Picture;
        }
    }
}
