using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace Dice.ViewModels
{
    class TenEdgeDiceViewModel : INotifyPropertyChanged
    {
        private readonly Models.Dice dice;
        private readonly Dictionary<int, string> picturesTenEdgeDice;
        private readonly List<int> throws;
        private string lastThrows;
        private string tenEdgeDice;

        public TenEdgeDiceViewModel()
        {
            Tapcommand = new Command(Tap);
            dice = new Models.Dice(10);
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
            throws = new List<int>();

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        public int RandomNumber { get; set; }

        public string Picture { get; set; }

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
        
        public string PropertyTenEdgeDice
        {
            get => tenEdgeDice;
            set
            {
                if (Equals(tenEdgeDice, value)) return;
                tenEdgeDice = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand Tapcommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void Tap()
        {
            RandomNumber = dice.Throw();
            TenEdgeDice();
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
        
        private void TenEdgeDice()
        {
            Picture = picturesTenEdgeDice[RandomNumber];
            PropertyTenEdgeDice = Picture;
        }
    }
}