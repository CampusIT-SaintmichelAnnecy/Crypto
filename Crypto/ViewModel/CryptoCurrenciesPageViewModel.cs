using System.Collections.ObjectModel;
using Crypto.Model;

namespace Crypto.ViewModel
{
    public class CryptocurrenciesPageViewModel
    {
        public ObservableCollection<Root> Cryptos { get; set; }

        public CryptocurrenciesPageViewModel()
        {
            Cryptos = new ObservableCollection<Root>();
        }
    }
}
