using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Prism.Navigation;
using Xamfire.Tests.Mobile.Models;

namespace Xamfire.Tests.Mobile.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _items = new ObservableCollection<Product>();

        public ObservableCollection<Product> Items
        {
            get => _items;
            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public ProductsViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            var product = parameters.GetValue<Product>("product");

            if(product != null)
            {
                Items.Add(product);
            }

        }


    }
}
