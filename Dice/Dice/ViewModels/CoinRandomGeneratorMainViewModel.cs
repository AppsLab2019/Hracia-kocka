using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace Dice.ViewModels
{
    class CoinRandomGeneratorMainViewModel : INotifyPropertyChanged
    {
        private readonly Models.Dice dice;
        private readonly Dictionary<int, string> coinPictures;
        private readonly List<int> throws;
        private string lastThrows;
        private string coin;

        public CoinRandomGeneratorMainViewModel()
        {
            Tapcommand = new Command(Tap);
            dice = new Models.Dice(2);
            coinPictures = new Dictionary<int, string>
            {
                {1,"CoinSymbol.jpg" },
                {2,"CoinHead.jpg" },
            };
            throws = new List<int>();

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        public int RandomNumber { get; set; }

        public string Picture { get; set; }

        public string PropertyForCoin
        {
            get => coin;
            set
            {
                if (Equals(coin, value)) return;
                coin = value;
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
            Coin();
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

        private void Coin()
        {
            Picture = coinPictures[RandomNumber];
            PropertyForCoin = Picture;
        }
    }
}
