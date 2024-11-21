using Crypto.API;
using Crypto.Model;
using Crypto.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crypto.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Root> Cryptos { get; set; }
        public ICommand ShowCryptocurrenciesCommand { get; set; }
        public ICommand CloseWindow { get; set; }
        public object CurrentView { get; set; }

        public MainPageViewModel()
        {
            Cryptos = new ObservableCollection<Root>();
            ShowCryptocurrenciesCommand = new RelayCommand(ShowCryptocurrencies);
            CloseWindow = new RelayCommand(CloseApp);
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var data = await CryptoApiService.GetCryptoCurrenciesAsync();
            foreach (var item in data)
            {
                Cryptos.Add(item);
            }
        }

        private void ShowCryptocurrencies()
        {
            CurrentView = new CryptoPage() { DataContext = this };
            OnPropertyChanged(nameof(CurrentView));
        }

        private void CloseApp()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
