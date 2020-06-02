using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
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
        private readonly List<int> throws;
        private string lastThrows;
        private string sixEdgeDice;
        private string tenEdgeDice;

        public MainViewModel()
        {
            Tapcommand = new Command(Tap);
            throws = new List<int>();

            Accelerometer.Start(SensorSpeed.Game);
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
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

        public ICommand Tapcommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                
        public void Tap()
        {
            RandomNumber = dice.Throw();
            SixEdgeDice();
            TenEdgeDice();
            AddLastThrowToHistory();
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

        private void Accelerometer_ShakeDetected(object sender, System.EventArgs e)
        {
                Tap();
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
        
        private void TenEdgeDice()
        {
            PropertyTenEdgeDice = Picture;
            Picture = picturesTenEdgeDice[RandomNumber];
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

    }
}
