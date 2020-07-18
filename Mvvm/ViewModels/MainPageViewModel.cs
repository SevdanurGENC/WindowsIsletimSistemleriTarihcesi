using System.Collections.Generic;
using System.Windows.Input;
using Mvvm.Helpers;
using Mvvm.Models;
using Mvvm.ViewModels.Commands;

namespace Mvvm.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            XmlCountryRepository countryRepository = new XmlCountryRepository();
            ListItemsSource = countryRepository.GetCountryList();
        }

        private IList<CountryData> _listItemsSource;

        public IList<CountryData> ListItemsSource
        {
            get
            {
                return _listItemsSource;
            }
            set
            {
                if (_listItemsSource != value)
                {
                    _listItemsSource = value;
                }

                OnPropertyChanged("ListItemsSource");
            }
        }

        private int _listSelectedIndex = -1;

        public int ListSelectedIndex
        {
            get
            {
                return _listSelectedIndex;
            }
            set
            {
                if (_listSelectedIndex != value)
                {
                    _listSelectedIndex = value;
                }

                OnPropertyChanged("ListSelectedIndex");
            }
        }

        #region Commands

        public ICommand SetCountryIdCommand
        {
            get
            {
                return new DelegateCommand(SetCountryId, CanSetCountryId);
            }
        }

        private void SetCountryId(object parameter)
        {
            CountryData selectedItemData = parameter as CountryData;

            if (selectedItemData != null)
            {
                Navigation.Id = selectedItemData.ID;
            }

            ListSelectedIndex = -1;
        }

        private bool CanSetCountryId(object parameter)
        {
            return true;
        }

        #endregion

    }
}