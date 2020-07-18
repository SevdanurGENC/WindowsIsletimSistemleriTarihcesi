using Mvvm.Helpers;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class CountryDetailsViewModel : ViewModelBase
    {
        public CountryDetailsViewModel()
        {
            XmlCountryRepository countryRepository = new XmlCountryRepository();
            CountryData country = countryRepository.GetCountryById(Navigation.Id);

            DataContext = country;
        }

        private CountryData _dataContext;

        public CountryData DataContext
        {
            get
            {
                return _dataContext;
            }
            set
            {
                if (_dataContext != value)
                {
                    _dataContext = value;
                }

                OnPropertyChanged("DataContext");
            }
        }
    }
}