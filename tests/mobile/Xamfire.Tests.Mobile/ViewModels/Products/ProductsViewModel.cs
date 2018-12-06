using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Prism.Navigation;
using Xamfire.Tests.Common.Contexts;
using Xamfire.Tests.Common.Models;

namespace Xamfire.Tests.Mobile.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly ProductContext _productContext;

        private ObservableCollection<Product> _items = new ObservableCollection<Product>();

        public ObservableCollection<Product> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ProductsViewModel(INavigationService navigationService, ProductContext productContext) : base(navigationService)
        {
            _productContext = productContext;
        }

        public override async Task InitalizeAsync()
        {
            _items = new ObservableCollection<Product>(await _productContext.GetAllAsync());
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
