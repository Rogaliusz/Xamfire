using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamfire.Tests.Common.Contexts;
using Xamfire.Tests.Common.Models;

namespace Xamfire.Tests.Mobile.ViewModels.Products
{
    public class ProductNewViewModel : ViewModelBase
    {
        private readonly ProductContext _productContext;

        private Product _product = new Product();

        public Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ICommand SaveNewProductCommand => new DelegateCommand(async () => await SaveNewProductAsync());

        public ProductNewViewModel(INavigationService navigationService, ProductContext productContext) : base(navigationService)
        {
            _productContext = productContext;
        }

        private async Task SaveNewProductAsync()
        {
            await _productContext.InsertOrUpdateAsync(Product);

            var navigationParameter = new NavigationParameters
            {
                { "product", Product }
            };

            await _navigationService.GoBackAsync();
        }


    }
}
