using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dice.ViewModels
{
    class SixEdgeDiceViewModel : INotifyPropertyChanged
    {
        private readonly Models.Dice dice;
        private readonly Dictionary<int, string> picturesSixEdgeDice;
        private readonly List<int> throws;
        private string lastThrows;
        private string sixEdgeDice;

        public SixEdgeDiceViewModel()
        {
            Tapcommand = new Command(Tap);
            dice = new Models.Dice(6);
            picturesSixEdgeDice = new Dictionary<int, string>
            {
                { 1, "Dice1.jpg" },
                { 2, "Dice2.jpg" },
                { 3, "Dice3.jpg" },
                { 4, "Dice4.jpg" },
                { 5, "Dice5.jpg" },
                { 6, "Dice6.jpg" },
            };
            throws = new List<int>();
            
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        public int RandomNumber { get; set; }
        
        public string Picture { get; set; }
        
        public string PropertySixEdgeDice
        {
            get => sixEdgeDice;
            set
            {
                if (Equals(sixEdgeDice, value)) return;
                sixEdgeDice = value;
                OnPropertyChanged();
            }
        }

        public string PropertyHistoryLastForThrows
        {
            get => lastThrows;
            set
            {
                if (Equals(lastThrows, value)) return;
                lastThrows = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand Tapcommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Tap()
        {
            RandomNumber = dice.Throw();
            SixEdgeDice();
            AddLastThrowToHistory();
        }

        public void Accelerometer_ShakeDetected(object sender, System.EventArgs e)
        {
            Tap();
        }

        public void AddLastThrowToHistory()
        {
            throws.Add(RandomNumber);
            if (throws.Count > 3)
                throws.RemoveAt(0);
            PropertyHistoryLastForThrows = string.Join(", ", throws);
        }
        
        private void SixEdgeDice()
        {
            Picture = picturesSixEdgeDice[RandomNumber];
            PropertySixEdgeDice = Picture;
        }
    }
}
