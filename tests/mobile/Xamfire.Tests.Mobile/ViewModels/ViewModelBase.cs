using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Xamfire.Tests.Mobile.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected readonly INavigationService _navigationService;

        protected ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;

            InitalizeAsync();
        }

        public virtual async Task InitalizeAsync()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        protected async Task NavigateToViewModel<TViewModel>(IDictionary<string, object> @params = null)
            where TViewModel : ViewModelBase
        {
            var uriBuilder = new UriBuilder(typeof(TViewModel).Name);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var param in @params)
                query[param.Key] = param.Value.ToString();

            uriBuilder.Query = query.ToString();

            await _navigationService.NavigateAsync(uriBuilder.Uri);
        }
    }
}
